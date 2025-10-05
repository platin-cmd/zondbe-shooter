using System;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class math : MonoBehaviour
{
    int h1 = 7;
    int m1 = 20;
    int h2 = 12;
    int m2 = 46;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int goingOuth1 = h1 * 60;
        h2 = h2 * 60;
        int goingOut = goingOuth1 + m1;
        int travel = h2 + m2;
        int timePassed = goingOut + travel;
        float timePassedM = timePassed / 60;
        float result = timePassedM % 24;
        print(result);
        float minutes = timePassedM / 24;
        print(minutes);

     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
