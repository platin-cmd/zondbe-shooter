using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    NavMeshAgent agent;

    string state = "chase";

    GameObject player;

    EnemyHealth enemyHealth;

    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "chase")
        {
            agent.SetDestination(player.transform.position);
        }
        else if (state == "attack")
        {
            agent.ResetPath();
            animator.SetBool("Attack", true);
        }
        else if (state == "death")
        {
            agent.ResetPath();
            agent.enabled = false;
            enabled = false;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (state == "chase" && distance < 2.5f)
        {
            state = "attack";
            animator.SetBool("Attack", true);
            player.GetComponent<PlayerHealth> ().TimeToDie();
        }
        else if (state == "attack" && distance >= 2.5f)
        {
            state = "chase";
            animator.SetBool("Attack", false);
            player.GetComponent<PlayerHealth>().StopAllCoroutines();
        }
        if (enemyHealth.health <= 0)
        {
            state = "death"; 
        }
        
    }
}

