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
    private CharacterController controller;
    [SerializeField] private LayerMask groundMask;
    public float gravity = -9.81f;
    private Vector3 velocity;

    [SerializeField] private bool CanMove;

    public Vector3 LastTouchedPosition;
    [SerializeField] private float lowestPosition;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(CanMove)
        {
            Move();
            Jump();
        }

        //restPosition();
        if (!CanMove)
        {
            controller.enabled = false;
        }
        else
        {
            controller.enabled = true;
        }
        if(isGrounded)
        {
            CanMove = true;
        }
    }
    [SerializeField] float goingUp,goingRight,goingForward;
    private void restPosition()
    {
        if(!CanMove )//&& not reached last touched position + (0,1,0)
        {
            if(transform.position.y <= LastTouchedPosition.y+1)
            {
                transform.Translate(new Vector3(0f, 1f, 0f) * speedModifier * Time.deltaTime);
                goingUp = 1;
            }
            else
            {
                goingUp = 2;
            }
            if(goingUp==2)
            {
                if (transform.position.x != LastTouchedPosition.x && goingRight!=3)
                {
                    if (transform.position.x > LastTouchedPosition.x && goingRight != 1)
                    {
                        goingRight = 0;
                        transform.Translate(new Vector3(-1f, 0f, 0f) * speedModifier * Time.deltaTime);
                    }
                    else if (transform.position.x < LastTouchedPosition.x && goingRight != 0)
                    {
                        goingRight = 1;
                        transform.Translate(new Vector3(1f, 0f, 0f) * speedModifier * Time.deltaTime);
                    }
                    else 
                    {
                        goingRight = 3;
                    }
                }


                if (transform.position.x != LastTouchedPosition.x && goingForward != 3)
                {
                    if (transform.position.x > LastTouchedPosition.x && goingForward != 1)
                    {
                        goingForward = 0;
                        transform.Translate(new Vector3(0f, 0f, -1f) * speedModifier * Time.deltaTime);
                    }
                    else if (transform.position.x < LastTouchedPosition.x && goingForward != 0)
                    {
                        goingForward = 1;
                        transform.Translate(new Vector3(0f, 0f, 1f) * speedModifier * Time.deltaTime);
                    }
                    else
                    {
                        goingForward = 3;
                    }
                }
            }
            if(goingUp == 2 && goingForward == 3 && goingRight == 3)
            {
                CanMove = true;
            }
        }
    }
    private void LateUpdate()
    {
        LastPosition();
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

    float speedModifier=5f;
    void LastPosition()
    {
        if(isGrounded)
        {
            LastTouchedPosition = transform.position;
        }
        else if(transform.position.y<lowestPosition ) 
        {
            //Debug.Log("teleporting");
            controller.transform.position = LastTouchedPosition;
            //CanMove = false;  
            goingUp = 2;
            goingRight = 2;
            goingForward = 2;
        }
        else
        {
            Debug.Log("more");
        }
    }
}