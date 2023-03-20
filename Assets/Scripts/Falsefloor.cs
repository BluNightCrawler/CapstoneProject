using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falsefloor : MonoBehaviour
{
    // Start is called before the first frame update
    bool isFalse;
    Renderer myRend;
    [SerializeField] Falsefloor[] group;
    Rigidbody myRB;
    [SerializeField] bool revealPath;
    

    private void OnEnable()
    {
        myRend = GetComponent<Renderer>();
        myRB = GetComponent<Rigidbody>();
    }

    void Start()
    {
       if(group.Length == 0)
        {
            return;
        }
        int pathIndex = Random.Range(0, group.Length);
        for(int i = 0; i < group.Length; i++)
        {
            if (pathIndex == i)
            {
                group[i].SetPath();
            }
            else
            {
                group[i].setFalsePath();
            }
        }
    }
    public void SetPath()
    {
        isFalse = false;
        myRB.isKinematic = true;
        if (revealPath)
        {
            myRend.material.SetColor(name, Color.red);
        }
    }
    public void setFalsePath()
    {
        isFalse = true;
        myRB.isKinematic = false;
        if (revealPath)
        {
            myRend.material.SetColor(name, Color.blue);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag =="Player")
        {
            if (isFalse)
            {
                myRend.material.SetColor(name, Color.blue);
            }
            else
            {
                myRend.material.SetColor(name, Color.red);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
