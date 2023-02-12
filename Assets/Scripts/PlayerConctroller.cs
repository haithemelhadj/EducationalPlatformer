using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConctroller : MonoBehaviour
{
    [SerializeField] private Collider playerCollider;                   //player collideer for collisions
    
    [SerializeField] private Rigidbody rb;                              //player rigidbody for physics
    //[SerializeField][Range(0f,100f)]private float speed;                //player movement speed
        
                              
    
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        //CameraControl();
        Movement();
        CheckGrounded();
        jump();
    }
    
    /*
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    float turnSmoothVelocity;
    public float turnSmoothTime=0.1f;
    */
    /*
    void Update()
    {
        CheckGrounded();
        //jump();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);//.normalized;


        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; controller.Move(moveDir * speed * Time.deltaTime);
        if (direction.magnitude >= 0.1f)
        {
            //controller.Move(moveDir.normalized * speed * Time.deltaTime);
            transform.Translate(moveDir.normalized * Time.deltaTime * speed);
        }
    }
    */
    /*
    //camera variables
    [SerializeField] private Camera playerCamera;                       //player collideer for collisions
    [SerializeField][Range(400f,2000f)]private float cameraSpeed;          //player camera movement speed
    [SerializeField] private bool invertX, invertY;
    #region CameraControl
    //invert camera on both x and y axis    
    //3rd person camera control function
    //rotate camera around player
    void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * cameraSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * cameraSpeed * Time.deltaTime;
        if(playerCamera.transform.position.y>=0)
        {
            if (invertY)
            {
                playerCamera.transform.RotateAround(transform.position, Vector3.left, -mouseY);
            }
            else
            {
                playerCamera.transform.RotateAround(transform.position, Vector3.left, mouseY);
            }
        }else
        {
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x,0f,playerCamera.transform.position.z);
        }
        
        if(invertX)
        {
            transform.RotateAround(transform.position, Vector3.up, -mouseX);
        }
        else
        {
            transform.RotateAround(transform.position, Vector3.up, mouseX);
        }

        
        playerCamera.transform.LookAt(transform.position);
    }
    #endregion
    */

    public float speed = 6;//---
    public CharacterController controller;//----
    public Transform cam;//-----
    float turnSmoothVelocity;//-------
    public float turnSmoothTime = 0.1f;//-----
    #region Movement
    //player movement function
    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    #endregion

    #region Jump
    // jumping logic
    [SerializeField] private bool isGrounded; //returns if player is on the ground
    //check if player is on the ground
    void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerCollider.bounds.extents.y + 0.1f);
    }
    [SerializeField][Range(0f, 100f)] private float jumpForce; //player's jump force
    //player jump function
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    #endregion

}
