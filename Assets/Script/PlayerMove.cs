using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public int speed = 10;
    public float jumpPower = 20f;

    public PlayerControls playerControls;
    private InputAction move;
    private InputAction jump;

    private Vector3 movement;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        //move = playerControls.Movement.Move;
        move.Enable();

        move.performed += ctx => print(ctx.ReadValue<Vector3>());

        //jump = playerControls.Movement.Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    

    private void Update()
    {
        //movement = move.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void FixUpdate()
    {
        rb.velocity = new Vector3(movement.x * speed * Time.deltaTime, 0.0f, movement.z * speed * Time.deltaTime);
        

    }



    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed && IsGrounded())
        {
            rb.AddForce(new Vector3(0.0f, jumpPower, 0.0F), ForceMode.Impulse);
        }   
    }
}
