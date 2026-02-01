using UnityEngine;
using UnityEditor;
using System.Collections;



public class KatanaController : MonoBehaviour
{

    public Animator animator;


    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StopAllCoroutines();
        animator.SetInteger("ComboIndex",0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            
            string CurrentAnimName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;

            if(CurrentAnimName == "idle")
            {
                animator.SetTrigger("attack");
            }

            else if(CurrentAnimName == "attack1")
            {
                animator.SetTrigger("attack");
                animator.SetInteger("ComboIndex",2);
            }

            else if(CurrentAnimName == "attack2")
            {
                animator.SetTrigger("attack");
                animator.SetInteger("ComboIndex", 3);
            }

            else if(CurrentAnimName == "attack3")
            {
                animator.SetTrigger("attack");
                animator.SetInteger("ComboIndex",1);
            }

            

            // if(animator.GetInteger("ComboIndex") == 3)
            // {
            //     animator.SetInteger("ComboIndex",0);
            // }
            StartCoroutine("ComboTimer");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("flexxx");
        }
    }

    IEnumerator ComboTimer()
    {
        yield return new WaitForSeconds(1.5f);
        animator.SetInteger("ComboIndex",0);
    }
}
