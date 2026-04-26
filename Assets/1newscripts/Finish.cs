using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public timerController timer;

    public GameObject winCanvas;

    public GameObject defCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            timer.StopAllCoroutines();
            winCanvas.SetActive(true);
            defCanvas.SetActive(false);

        }
    }

    

       
    
}
