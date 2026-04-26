using UnityEngine;

public class pistolAnimations : MonoBehaviour
{

    public KeyCode osmotrKey = KeyCode.P;

    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(osmotrKey))
        {
            

        }
    }
}
