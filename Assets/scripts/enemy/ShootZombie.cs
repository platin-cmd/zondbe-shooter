using GLTFast;
using UnityEngine;
using UnityEngine.AI;

public class ShootZombie : MonoBehaviour
{
    
    string state;

    NavMeshAgent agent;

    Transform player;

    Animator animator;

    bool seePlayer = false;

    public float runDistance = 10;

    public LayerMask layerMask;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = "chase";
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vision();
        switch (state)
        {
            case "chase":
                agent.SetDestination(player.position);

                float distance = Vector3.Distance(transform.position, player.position);

                if (seePlayer && distance > runDistance)
                {
                    state = "shoot";
                    animator.SetBool("attack",true);
                }
                break;
            case "shoot":
                agent.ResetPath();
                
                distance = Vector3.Distance(transform.position, player.position);
                if(!seePlayer && distance > runDistance)
                {
                    state="chase";
                    animator.SetBool("attack",false);
                }



                break;
            case "runaway":
                break;
        }
    }

    void Vision()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        seePlayer = Physics.Raycast(transform.position,dir,10000,layerMask);
    }
}
