using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;
    //Detta är values för olika delar av movementet
    
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    //Detta är det som bestämmer när spelaren är på marken

    Vector3 velocity;
    bool isGrounded;
    bool ShiftSpeed;


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Detta är hur spelet detekterar att spelaren är på marken

        ShiftSpeed = Input.GetKey("left shift") && (Input.GetKey("w"));

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Detta är koden för att röra på sig

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (ShiftSpeed)
        {
            speed = 75f;
        }

        if (!ShiftSpeed)
        {
            speed = 12f;
        }
    } //Detta är koden för att sprinta
}