using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class GameManager : MonoBehaviour
{
    public Transform robotTrans;
    public float rotationSpeed;
    private Vector2 rot;
    
    
    public PlayerControls playerControls;
    private InputAction valve;
    
    void Awake()
    {
        playerControls = new PlayerControls();

        
    }

    private void OnEnable()
    {
        valve = playerControls.LeverAndValve.Valve;
        valve.Enable();
    }

    private void OnDisable()
    {
        valve.Disable();
    }

    private void Start()
    {
        // valve.performed += ctx => rot = ctx.ReadValue<Vector2>();
        // valve.canceled += ctx => rot = Vector2.zero;
    }

    private void Update()
    {
        // if (Keyboard.current.rKey.isPressed)
        // {
        //     robotTrans.Rotate(Vector3.up * (1f * rotationSpeed));
        // }
        // else if (Keyboard.current.nKey.isPressed)
        // {
        //     robotTrans.Rotate(Vector3.down * (1f * rotationSpeed));
        // }

        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad;
        robotTrans.Rotate(Vector3.up * -rotX, Space.Self);

    }
}
