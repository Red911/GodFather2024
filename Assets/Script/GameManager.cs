using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GameManager : MonoBehaviour
{

    [Header("PassFail")] 
    public GameObject PassFailObject;
    public Material neutralMat;
    public Material failMat;
    public Material passMat;
    
    [Header("Ending")] 
    public GameObject leaderBoard;
    public TextMeshProUGUI totalScoreTxt;
    public int endingHours = 19;
    
    [Header("Spawner Robot")]
    public GameObject robotPrefab;
    public Transform spawnerRobot;
    
    [Header("Rotation Robot")]
    [HideInInspector]public Transform robotTrans;
    public float rotationSpeed;

    [Header("Score")] 
    public int score;
    public TextMeshProUGUI scoreTxt;

    [Header("Sounds")]
    public AudioSource audioSource;
    public AudioClip passAudio;
    public AudioClip failAudio;

    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        
    }

    private void Start()
    {
        RobotManagement();
    }

    private void Update()
    {
        if (robotTrans != null)
        {
            float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
            robotTrans.Rotate(Vector3.up * -rotX, Space.Self);
        }

        if (Timer._instance.hours == endingHours)
        {
            leaderBoard.SetActive(true);
            Timer._instance.isEnded = true;
            totalScoreTxt.text = "Total Score : " + score;
        }

        scoreTxt.text = score.ToString();

    }

    public void RobotManagement()
    {
        //Spawn
        GameObject robotInst = Instantiate(robotPrefab, spawnerRobot);
        RandomSpawnRobotScript ranRobot = robotInst.GetComponentInChildren<RandomSpawnRobotScript>();
        AssembleRobotScript assRobot = robotInst.GetComponentInChildren<AssembleRobotScript>();
        

        ranRobot.nextRobot = true;
        assRobot.assemble = true;

       robotTrans = robotInst.transform;
    }

    public void ApplyNeutralMat()
    {
        PassFailObject.GetComponent<MeshRenderer>().material = neutralMat;
    }
    
    public void ApplyFailMat()
    {
        PassFailObject.GetComponent<MeshRenderer>().material = failMat;
        audioSource.PlayOneShot(failAudio);
    }
    
    public void ApplyPassMat()
    {
        PassFailObject.GetComponent<MeshRenderer>().material = passMat;
        audioSource.PlayOneShot(passAudio);
    }
    
    
}
