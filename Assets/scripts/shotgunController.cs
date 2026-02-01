using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using StarterAssets;
using UnityEditor.Experimental.GraphView;

public class shotgunController : MonoBehaviour
{

    public int magazineMaxShotgun = 2;

    int magazineCurrentShotgun;

    public Text ammoTextShotgun;

    public Animator animator;

    public FirstPersonController fpc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magazineCurrentShotgun = magazineMaxShotgun;
        ammoTextShotgun.text = magazineCurrentShotgun + "/"+ magazineMaxShotgun;
        fpc = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && fpc.Grounded != true)
        {
            fpc.Gravity = -145;
        }
        if (Input.GetMouseButtonDown(1))
        {

            if (magazineCurrentShotgun == 0)
            {
                //добавь звук дебик
                animator.SetTrigger("reloadShotgun");
                return;
            } 

           
            animator.SetTrigger("shootShotgun");
            magazineCurrentShotgun--;
            ammoTextShotgun.text = magazineCurrentShotgun + "/"+ magazineMaxShotgun;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("reloadShotgun");
        }
    }
    public void reloadShotgun()
    {
        magazineCurrentShotgun = magazineMaxShotgun;
        ammoTextShotgun.text = magazineCurrentShotgun + "/"+ magazineMaxShotgun;
        
    }
    

    

}
