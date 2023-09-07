using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    public AnimationCurve robotEntryAnimCurve;
    public AnimationCurve robotValidateAnimCurve;
    public float robotCancelSpeed;
    public float robotCancelRotationSpeed;
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
        validatePos.y = basePos.y + 20;
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
        if (ctx.performed)
        {
            StartCoroutine(MoveRobotValidate());
        }
    }

    public void Cancel(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
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
            path = new Vector3(Mathf.Lerp(basePos.x, basePos.x, tCurve), Mathf.Lerp(basePos.y, basePos.y + 10, tCurve), Mathf.Lerp(basePos.z, basePos.z, tCurve));
            
            gameObject.transform.position = new Vector3(path.x, path.y, path.z);

            if(gameObject.transform.position.y == basePos.y + 10 || gameObject.transform.position.y == basePos.y + 20)
            {
                isTraveling = false;
            }
            yield return null;
        }
        time = 0;
        yield return null;
    }

    IEnumerator MoveRobotValidate()
    {
        isTraveling = true;

        while (isTraveling)
        {
            time += Time.deltaTime;
            float tCurve = robotValidateAnimCurve.Evaluate(time);

            path = new Vector3(Mathf.Lerp(gameObject.transform.position.x, validatePos.x, tCurve), Mathf.Lerp(gameObject.transform.position.y, validatePos.y, tCurve), Mathf.Lerp(gameObject.transform.position.z, validatePos.z, tCurve));

            gameObject.transform.position = new Vector3(path.x, path.y, path.z);

            if (gameObject.transform.position.y == basePos.y + 10 || gameObject.transform.position.y == basePos.y + 20)
            {
                isTraveling = false;
            }
            yield return null;
        }
        time = 0;
        yield return null;
    }

    IEnumerator MoveRobotCancel()
    {
        isTraveling = true;

        while (isTraveling)
        {
            /*time += Time.deltaTime;
            float tCurve = robotEntryAnimCurve.Evaluate(time);
            path = new Vector3(Mathf.Lerp(gameObject.transform.position.x, basePos.x, tCurve), Mathf.Lerp(gameObject.transform.position.y, basePos.y, tCurve), Mathf.Lerp(gameObject.transform.position.z, basePos.z, tCurve));
            gameObject.transform.position = new Vector3(path.x, path.y, path.z);

            if (gameObject.transform.position.y == basePos.y)
            {
                isTraveling = false;
            }
            yield return null;*/

            Vector3 v = Quaternion.AngleAxis(Random.Range(-75.0f, 75.0f), Vector3.forward) * Vector3.up;
            rb.velocity = v * robotCancelSpeed * Time.deltaTime;
            isCanceled = true;
            isTraveling = false;
        }
        time = 0;
        yield return null;
    }
}
