using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonCharacterController : MonoBehaviour
{
    //Movement
    public Rigidbody rb;
    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.2f;
    float speedSmoothVelocity;
    float currentSpeed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputDir = input.normalized;

        bool running = Input.GetKey(KeyCode.LeftShift);                             //actually moving the player
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
    }
}