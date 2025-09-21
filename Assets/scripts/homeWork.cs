using System;
using UnityEngine;

public class homeWork : MonoBehaviour
{
  
    public int  N = 60;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (N <= 100)
        {
            N = N * 3;
        }
        else
        {
            N = 300 + (N - 100) * 2;
        }
        print(N);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
