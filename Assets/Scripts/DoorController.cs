using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KeySystem
{
    public class DoorController : MonoBehaviour
    {
        public GameObject door;
        public bool doorIsOpen;


        void Update()
        {
            if (doorIsOpen == true)
            {
                door.transform.Translate(Vector3.up * Time.deltaTime * 5);
                //if bool is true opens door
            }
            if (door.transform.position.y > 19.5f)
            {
                doorIsOpen = false;
                //if the y is greater then 19.5 we want to stop the movement
            }
        }
        //Detect the mouse click
        void OnMouseDown()
        {
            doorIsOpen = true;

        }
    }
}