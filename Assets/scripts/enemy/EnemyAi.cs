using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    NavMeshAgent agent;

    string state = "chase";

    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
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

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (state == "chase" && distance < 2.0f)
        {
            state = "attack";
        }
        else if (state == "attack" && distance >= 2.0f)
        {
            state = "chase";
        }
        
    }
}
