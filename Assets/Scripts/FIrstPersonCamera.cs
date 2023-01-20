using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FIrstPersonCamera : MonoBehaviour
{
    public Transform camera;
    public Rigidbody rb;

    public float camRotationSpeed = 5f;
    public float cameraMinY = -60f;
    public float cameraMaxY = 75f;
    public float rotationSmoothSpeed = 10f;

    public float walkSpeed = 15f;
    public float runSpeed = 25f;
    public float maxSpeed = 35f;
    public float jumpPower = 45f;

    public float extraGravity=10;

    float bodyRotationX;
    float camRotationY;
    Vector3 directionIntentY;
    Vector3 directionIntentX;
    float speed;
    public bool grounded;
    //private bool dbljump = true;


    // Update is called once per frame
    void Update()
    {
        LookRotation();
        Movement();
        ExtraGravity();
        GroundCheck();
        
        if(grounded || Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }
    void LookRotation()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;

        //Get camera and vody rotational vcalues
        bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
        camRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;

        //Stop our Dcamera from rotating 360 degres
        camRotationY = Mathf.Clamp(camRotationY, cameraMinY, cameraMaxY);

        //Create rotation target and hanfle orotoaion of the body and camera
        Quaternion camTargetRotation = Quaternion.Euler(-camRotationY, 0, 0);   
        Quaternion bodyTargetRotation = Quaternion.Euler(0,bodyRotationX, 0);

        //handle rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRotation, Time.deltaTime * rotationSmoothSpeed);
        camera.localRotation = Quaternion.Lerp(camera.localRotation, camTargetRotation, Time.deltaTime * walkSpeed);
    }
    void Movement()
    {
        //We got to match our direction to camera direction
        directionIntentX = camera.right;
        directionIntentX.y = 0;
        directionIntentX.Normalize();

        directionIntentY = camera.forward;
        directionIntentY.y = 0;
        directionIntentX.Normalize();


        //Change our character velocity in this direction
        rb.velocity = directionIntentY * Input.GetAxis("Vertical") * speed + directionIntentX * Input.GetAxis("Horizontal") * speed + Vector3.up * rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        //Control our speed based on our movemnt state
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }
    }
    void ExtraGravity()
    {
        rb.AddForce(Vector3.down * extraGravity);
    }
    void GroundCheck()
    {
        RaycastHit groundHit;
        grounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 1.25f);
        //if (grounded==false)
        //{
        //    dbljump = true;

        //}
       // Debug.Log("You have Landed");
    }
    void Jump()
    {
        
           rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
           
        
        
        
        
       // Debug.Log("You have Jumped");

        //rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);
        //I am trying some double JUmp that is not working out at the moment
        //    if(grounded == true)
        //{
        //    rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        //    grounded = false;
        //    Debug.Log(" JUmp");

        //}
        //else if(!grounded && dbljump)
        //{
        //    rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        //    dbljump = false;
        //    Debug.Log("Double JUmp");
        //}
    }
}
