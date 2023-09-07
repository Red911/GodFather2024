using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    public AnimationCurve robotEntryAnimCurve;
    public AnimationCurve robotValidateAnimCurve;
    public float robotCancelSpeed;
    public float robotCancelRotationSpeed;
    public float distanceMonter = 100;
    private Vector3 basePos;
    private Vector3 validatePos;
    private Vector3 path;
    private bool isTraveling;
    private bool isCanceled = false;
    private float time;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        basePos = gameObject.transform.position;
        validatePos.y = basePos.y + (distanceMonter*2);
        StartCoroutine(MoveRobotStart());
    }

    void Update()
    {
        if (isCanceled)
        {
            transform.Rotate(0, 0, robotCancelRotationSpeed * Time.deltaTime);
        }
    }

    public void Validate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && GetComponentInChildren<RandomSpawnRobotScript>().isAGoodRobot)
        {
            GameManager._instance.ApplyPassMat();
            StartCoroutine(MoveRobotValidate());
        }
    }

    public void Cancel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && !GetComponentInChildren<RandomSpawnRobotScript>().isAGoodRobot)
        {
            GameManager._instance.ApplyFailMat();
            StartCoroutine(MoveRobotCancel());
        }
    }

    IEnumerator MoveRobotStart()
    {
        isTraveling = true;

        while (isTraveling)
        {
            time += Time.deltaTime;
            float tCurve = robotEntryAnimCurve.Evaluate(time);
            path = new Vector3(Mathf.Lerp(basePos.x, basePos.x, tCurve), Mathf.Lerp(basePos.y, basePos.y + distanceMonter, tCurve), Mathf.Lerp(basePos.z, basePos.z, tCurve));
            
            gameObject.transform.position = new Vector3(path.x, path.y, path.z);

            if(gameObject.transform.position.y == basePos.y + distanceMonter || gameObject.transform.position.y == basePos.y + (distanceMonter*2))
            {
                isTraveling = false;
            }
            yield return null;
        }
        time = 0;
        yield return null;
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator MoveRobotValidate()
    {
        isTraveling = true;

        while (isTraveling)
        {
            time += Time.deltaTime;
            float tCurve = robotValidateAnimCurve.Evaluate(time);

            path = new Vector3(Mathf.Lerp(gameObject.transform.position.x, validatePos.x, tCurve), Mathf.Lerp(gameObject.transform.position.y, validatePos.y, tCurve), Mathf.Lerp(gameObject.transform.position.z, validatePos.z, tCurve));

            gameObject.transform.position = new Vector3(path.x, path.y, path.z);

            if (gameObject.transform.position.y == basePos.y + distanceMonter || gameObject.transform.position.y == basePos.y + (distanceMonter*2))
            {
                isTraveling = false;
            }
            yield return null;
            if (time >= 3f)
            {
                GameManager._instance.score += 100;
                GameManager._instance.ApplyNeutralMat();
                GameManager._instance.RobotManagement();
                Destroy(this.gameObject);
                
            }
           
            
        }
        time = 0;
        yield return new WaitForSeconds(3f);
        GameManager._instance.score += 100;
        GameManager._instance.ApplyNeutralMat();
        GameManager._instance.RobotManagement();
        Destroy(this.gameObject);
        
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator MoveRobotCancel()
    {
        isTraveling = true;

        while (isTraveling)
        {
            Vector3 v = Quaternion.AngleAxis(Random.Range(-75.0f, 75.0f), Vector3.forward) * Vector3.up;
            rb.velocity = v * robotCancelSpeed * Time.deltaTime;
            isCanceled = true;
            isTraveling = false;
        }
        
        yield return new WaitForSeconds(3f);
        GameManager._instance.score += 100;
        GameManager._instance.ApplyNeutralMat();
        GameManager._instance.RobotManagement();
        Destroy(this.gameObject);
        
    }
}
