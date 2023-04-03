using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    public float jumpForce = 5f; // The force applied to the character when jumping
    public Animator animator; // The Animator component for the character
    [SerializeField] private bool isGrounded; // Whether the character is currently grounded
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private CharacterController controller;
    [SerializeField] private LayerMask groundMask;
    public float gravity = -9.81f;
    private Vector3 velocity;

    public Vector3 LastTouchedPosition;
    [SerializeField] private float lowestPosition;
    public Transform Respawn;

    //[SerializeField] private bool CanMove=true;
    //[SerializeField] float goingUp,goingRight,goingForward;
    private void Start()
    {
        //controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
            Move();
            Jump();
    }
    private void LateUpdate()
    {
        LastPosition();
    }

    public void LastPosition()
    {
        if(isGrounded)
        {
            LastTouchedPosition = transform.position + new Vector3(0, 2, 0);
        }
        if(transform.position.y< lowestPosition)
        {
            //transform.position = LastTouchedPosition;
            transform.position = Respawn.position;
        }
    }
    private void Move()
    {
        // Get the horizontal and vertical input values
        float moveHorizontal = -Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");

        // Create a Vector3 movement vector based on the input values
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // Normalize the movement vector to prevent faster diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1f);

        // Rotate the character towards the movement vector
        if (movement.magnitude > 0.1f)
        {
            transform.LookAt(transform.position + movement);
            animator.SetFloat("Speed",1);//movement.magnitude
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        // Apply the movement vector to the character controller
        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        // Jump if the character is on the ground and the jump button is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("isJumping");
            velocity.y = Mathf.Sqrt(jumpForce * -3.0f * gravity);
            
        }

        // Apply gravity to the character controller
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            Respawn = other.transform;
        }
    }
}