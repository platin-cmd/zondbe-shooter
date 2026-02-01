using StarterAssets;
using UnityEngine;
using System.Collections;

public class SpeedReset : MonoBehaviour
{

    public FirstPersonController fpc;

    public bool isResetting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    IEnumerator ResetTimer()
    {
        isResetting = true;
        yield return new WaitForSeconds(1);
        fpc.MoveSpeed = 25;
        isResetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fpc.Grounded == true && isResetting == false)
        {
            StartCoroutine("ResetTimer");
        }

        if(fpc.Grounded == false && isResetting == true)
        {
            isResetting = false;
            StopAllCoroutines();
        }
    }
}
