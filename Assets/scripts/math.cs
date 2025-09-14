using System;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class math : MonoBehaviour
{
    float jumpSpeed = 5.2f;
    float gravitation = 9.8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float Result = jumpSpeed * 1.6f - 0.5f * gravitation * (1.6f * 1.6f);
        print(Result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
