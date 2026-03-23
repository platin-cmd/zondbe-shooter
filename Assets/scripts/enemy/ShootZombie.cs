using GLTFast;
using UnityEditor.Rendering;
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

    public Vector3 playerCheckOffset;


    float distance;

    
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

        distance = Vector3.Distance(transform.position,player.position + playerCheckOffset);

        Vision();
        switch (state)
        {
            case "chase":
                agent.SetDestination(player.position);

                

                if (seePlayer && distance > runDistance)
                {
                    state = "shoot";
                    animator.SetBool("attack",true);
                }

                if(distance < runDistance)
                {
                    state = "runaway";
                }

                transform.GetComponentInChildren<Animator>().transform.LookAt(player.position);
                break;
            case "shoot":
                agent.ResetPath();
                animator.SetBool("attack",true);
                
                
                if(!seePlayer && distance > runDistance)
                {
                    state="chase";
                    animator.SetBool("attack",false);
                }

                if(distance < runDistance)
                {
                    state = "runaway";
                }



                break;
            case "runaway":
            animator.SetBool("attack",false);
            Vector3 dir = (player.position + playerCheckOffset - transform.position).normalized;

            agent.SetDestination(transform.position - dir);
            distance = Vector3.Distance(transform.position,player.position);

            if (distance > runDistance)
                {
                    if (seePlayer)
                    {
                        state = "shoot";
                    }
                    else
                    {
                        state = "chase";
                    }
                }
            break;
        }
    }

    void Vision()
    {
        Vector3 dir = (player.position + playerCheckOffset - transform.position).normalized;
        RaycastHit hit;
        Physics.Raycast(transform.position,dir,out hit, 10000,layerMask);

        seePlayer = hit.collider.transform.parent.gameObject == player.gameObject;
        if (seePlayer)
        {
            print(gameObject.name + "видит игрока");
        }
        else
        {
            print(gameObject.name + "не видит игрока");
        }
    }
}
