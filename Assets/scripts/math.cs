using System;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class math : MonoBehaviour
{
    int dasha = 10;
    int masha = 20;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (dasha > masha)
        {
            int babax = (dasha - masha) / 2;
            print(babax);
            print("dasha");
        }
        else
        {
            int bubux = (masha - dasha) / 2;
            print(bubux);
            print("masha");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
