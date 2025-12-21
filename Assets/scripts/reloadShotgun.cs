using UnityEngine;

public class reloadShotgun : MonoBehaviour
{
    Animator animator;

    int bullets = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("please");
        }
        
    }
}
