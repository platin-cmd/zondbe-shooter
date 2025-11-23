using System;
using UnityEngine;

public class dashCheckCollision : MonoBehaviour
{

    public slide sl;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") && sl.isDashing)
        {
            print("бабах");
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1000);
            sl.Dash();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
