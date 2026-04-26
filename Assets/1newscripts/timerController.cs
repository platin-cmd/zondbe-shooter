using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class timerController : MonoBehaviour
{

    public TMP_Text timer;

    public int timerSeconds;

    public int seconds;



    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RunEverySecond());
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public IEnumerator RunEverySecond()
    {
        yield return new WaitForSeconds(1f);
        seconds += 1;
        timer.text = "Timer:" + seconds;
        StartCoroutine(RunEverySecond());

    }
}
