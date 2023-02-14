using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
    //public AudioSource clickSource;
    public bool failSafe = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fkey"))
        {
            Debug.Log("F Key is Pressed");
            if(!isOn && !failSafe)
            {
                failSafe = true;
                lightSource.SetActive(true);
                //clickSource.Play();
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && !failSafe)
            {
                lightSource.SetActive(false);
                //clickSource.Play();
                isOn = false;
                StartCoroutine(FailSafe());

            }
        }
    }
    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(.25f);
        failSafe = false;
    }
}
