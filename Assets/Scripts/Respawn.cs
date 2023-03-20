using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public float threshold;
    [SerializeField] float xpoint;
    [SerializeField] float ypoint;
    [SerializeField] float zpoint;


    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = new Vector3(xpoint, ypoint, zpoint);
        }
    }
   
}
