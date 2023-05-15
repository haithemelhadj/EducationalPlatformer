using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // The speed at which the character moves
    public float jumpForce = 5f; // The force applied to the character when jumping
    public Animator animator; // The Animator component for the character
    public bool isGrounded; // Whether the character is currently grounded
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private CharacterController controller;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool RespawnNextFrame = false;
    [SerializeField] private TMP_Text lifeText;
    public int lifePoints = 5;
    [SerializeField] private bool isHit = false;
    public bool isAttacking = false;
    public bool isAttacked = false;

    public float gravity = -9.81f;
    private Vector3 velocity;

    public Vector3 LastTouchedPosition;
    [SerializeField] private float lowestPosition;
    public Transform Respawn;
    public Transform mainCamera;

    //[SerializeField] private bool CanMove=true;
    //[SerializeField] float goingUp,goingRight,goingForward;
    private void Start()
    {
        //controller = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Move();
        Jump();
        Attack();
        LifePoints(lifePoints);
        if (isAttacked)
        {
            StartCoroutine(Freeze(2.0f));
        }

    }
    private void LateUpdate()
    {
        LastPosition();
    }

    public void LastPosition()
    {
        if (RespawnNextFrame)
        {
            transform.position = Respawn.position;
            transform.rotation = Respawn.rotation;
            RespawnNextFrame = false;
            //return isHit to false
            StartCoroutine(SetFalseHit(1f));
        }
        if (transform.position.y < lowestPosition)
        {
            transform.position = Respawn.position;
        }
    }


    private void Move()
    {
        // Get the horizontal and vertical input values
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Create a Vector3 movement vector based on the input values
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // Normalize the movement vector to prevent faster diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1f);

        //--------------
        Vector3 cameraForward = mainCamera.forward;
        Vector3 cameraRight = mainCamera.right;

        // Zero out the y components of the vectors to keep the movement in the XZ plane
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Combine the vectors to get the movement relative to the camera
        movement = cameraForward * moveVertical + cameraRight * moveHorizontal;
        movement = Vector3.ClampMagnitude(movement, 1f);
        //---------------







        // Rotate the character towards the movement vector
        if (movement.magnitude > 0.1f)
        {
            transform.LookAt(transform.position + movement);
            animator.SetFloat("Speed", 1);//movement.magnitude
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

    private void Attack()
    {

        if (Input.GetMouseButtonDown(0) && !isAttacked)
        {
            animator.SetTrigger("isAttack");
            isAttacking = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ResetAttack(1.5f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Respawn = other.transform;
        }
        if (other.CompareTag("Spike") && !isHit)
        {
            isHit = true;
            RespawnNextFrame = true;
            LifePoints(lifePoints - 1);
        }

    }
    public void LifePoints(int lifePt)
    {
        lifePoints = lifePt;
        lifeText.SetText("X" + lifePoints.ToString());
    }

    IEnumerator SetFalseHit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isHit = false;
    }
    IEnumerator Freeze(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        moveSpeed = 20f;
        isAttacked = false;
    }
    IEnumerator ResetAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isAttacking = false;
    }

    //OntriggerEnter 
    //if player collides with spikes -Life points 

}