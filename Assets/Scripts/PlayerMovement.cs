using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
     

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hello From Start");
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        float horizonatalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizonatalInput * movementSpeed, rb.velocity.y, VerticalInput * movementSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        ////Jump Button
        //if (Input.GetKeyDown("space"))
        //{
        //    Debug.Log("You have pressed jump");
        //    GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
        //}
        ////Movement up
        //if (Input.GetKey(KeyCode.W))
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 5);

        //}
        ////Movement LEft
        //if (Input.GetKey(KeyCode.A))
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(-5, 0, 0);

        //}
        ////Movement Down

        //if (Input.GetKey(KeyCode.S))
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -5);

        //}
        ////Movemnt Right
        //if (Input.GetKey(KeyCode.D))
        //{
        //    GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 0);

        //}
    }
}
