using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GameManager : MonoBehaviour
{
    [Header("Spawner Robot")]
    public GameObject robotPrefab;
    public Transform spawnerRobot;
    
    [Header("Rotation Robot")]
    public Transform robotTrans;
    public float rotationSpeed;

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
}
