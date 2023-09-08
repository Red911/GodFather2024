using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangePositionScript : MonoBehaviour
{

    private Camera _camera;

    public AudioRobotScript audioRobotScript;

    [SerializeField] private Transform _positionTop;
    [SerializeField] private Transform _positionBot;

    [SerializeField] private float _distanceHautBas;

    [SerializeField] private float _cameraSpeed;

    private Transform lastCameraPosition;
    private Transform nextCameraPosition;

    private bool _inChangePositionCoroutine;

    public AnimationCurve animCurv;


    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        _positionBot = GameObject.Find("PositionBot").GetComponentInChildren<Transform>();
        _positionTop = GameObject.Find("PositionTop").GetComponentInChildren<Transform>();

        _positionBot.transform.position = new Vector3(_positionBot.position.x, _positionTop.position.y - _distanceHautBas, _positionBot.position.z);

        _cameraSpeed = 1f;

        lastCameraPosition = _positionTop;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (lastCameraPosition == _positionTop && _inChangePositionCoroutine == false)
            {
                lastCameraPosition = _positionBot;
                nextCameraPosition = _positionTop;
                StartCoroutine(GoToPositionCoroutine());
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (lastCameraPosition == _positionBot && _inChangePositionCoroutine == false)
            {
                lastCameraPosition = _positionTop;
                nextCameraPosition = _positionBot;
                StartCoroutine(GoToPositionCoroutine());
            }
        }
                
        
    }

    //Coroutine qui déplace le gameObject attaché vers nextCameraPosition
    IEnumerator GoToPositionCoroutine()
    {
        audioRobotScript.MakeCameraSound();
        float t = 0f;
        
        _inChangePositionCoroutine = true;

        Vector3 cameraDirection = new Vector3(0, lastCameraPosition.position.y - transform.position.y, 0).normalized;

        while ((lastCameraPosition == _positionTop && transform.position.y < lastCameraPosition.position.y)||(lastCameraPosition == _positionBot && transform.position.y > lastCameraPosition.position.y)) //Tant que le gameObject n'est pas en dessous ou au dessus (en fonction) du repère de position
        {
            float tCurve = animCurv.Evaluate(t); //tCurve est une courbe qui monte puis redescend

            float smoothSpeed = Mathf.Lerp(_cameraSpeed / 5, _cameraSpeed, tCurve);

            transform.Translate(Time.deltaTime * smoothSpeed * cameraDirection); //Déplace le gameOcject avec la nouvelle vitesse à chaque frame

            if (lastCameraPosition == _positionTop && transform.position.y > lastCameraPosition.position.y) //Si le gameobject dépace le repère, remet le gameobject à la position exacte du repère
            {
                transform.position = lastCameraPosition.position;
            }
            else
            {
                if (lastCameraPosition == _positionBot && transform.position.y < lastCameraPosition.position.y) //Si le gameobject dépace le repère, remet le gameobject à la position exacte du repère
                {
                    transform.position = lastCameraPosition.position;
                }
            }
            
            t += Time.deltaTime; //Augmente le temps t (abscisse de la tCurve)
            yield return null;
        }
        _inChangePositionCoroutine = false;
        yield return null;
    }
}
