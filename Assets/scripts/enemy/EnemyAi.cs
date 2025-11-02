using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    NavMeshAgent agent;

    string state = "chase";

    GameObject player;

    EnemyHealth enemyHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
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
        }
        else if (state == "death")
        {
            agent.ResetPath();
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (state == "chase" && distance < 2.0f)
        {
            state = "attack";
        }
        else if (state == "attack" && distance >= 2.0f)
        {
            state = "chase";
        }
        if (enemyHealth.health <= 0)
        {
            state = "death";
        }
        
    }
}
