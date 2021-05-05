using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalking;
    int IsJumping;
    int IsBackwards;

    public Rigidbody Rigidbody;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public CharacterController controller;

    private float lastY;
    public float FallingThreshold = -10f;
    public bool IsFalling;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;
    bool ShiftSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalking = Animator.StringToHash("IsWalking");
        IsJumping = Animator.StringToHash("IsJumping");
        IsBackwards = Animator.StringToHash("IsBackwards");

        lastY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        bool IsWalking = animator.GetBool("IsWalking");
        bool forwardpressed = Input.GetKey("w") && isGrounded;
        bool IsJumping = Input.GetKey("space") && isGrounded;
        bool IsBackwards = Input.GetKey("s") && isGrounded;
        bool IsSprinting = Input.GetKey("left shift") && (Input.GetKey("w")) && isGrounded;

        float distancePerSecondSinceLastFrame = (transform.position.y - lastY) * Time.deltaTime;
        lastY = transform.position.y;
        
        if (Rigidbody.velocity.y < FallingThreshold)
        {
            IsFalling = true;
        }
        else
        {
            IsFalling = false;
        }

        if (IsFalling && !isGrounded)
        {
            animator.SetBool("IsFalling", true);
        }

        if (!IsFalling)
        {
            animator.SetBool("IsFalling", false);
        }




        if (!IsWalking && forwardpressed)
        {
            animator.SetBool("IsWalking", true);
        }

        if (IsWalking && !forwardpressed)
        {
            animator.SetBool("IsWalking", false);
        }

        if (IsJumping)
        {
            animator.SetBool("IsJumping", true);
        }

        if (!IsJumping)
        {
            animator.SetBool("IsJumping", false);
        }

        if (IsBackwards)
        {
            animator.SetBool("IsBackwards", true);
        }

        if (!IsBackwards)
        {
            animator.SetBool("IsBackwards", false);
        }

        if (IsSprinting)
        {
            animator.SetBool("IsSprinting", true);
        }

        if (!IsSprinting)
        {
            animator.SetBool("IsSprinting", false);
        }

        
    }    

}
