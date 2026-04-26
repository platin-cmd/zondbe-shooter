using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer.GetComponent<timerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
        }
    }

       
    
}
