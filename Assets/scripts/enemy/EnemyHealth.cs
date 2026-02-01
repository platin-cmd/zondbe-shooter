using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;

    public float health;

    Animator animator;
    bool IsAlive = true;

    Rigidbody rb;

    public GameObject zombiePrefab;

    public GameObject ShotgunBullets;

    public float stunTime = 1; //лысеет  

    NavMeshAgent meshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        animator = GetComponentInChildren<Animator>();
        meshAgent = GetComponent<NavMeshAgent>();
        
    }

    IEnumerator StunTimer()
    {
        meshAgent.enabled=false;
        animator.speed = 0;
        yield return new WaitForSeconds(stunTime);
        meshAgent.enabled = true;
        animator.speed = 1;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0 && IsAlive)
        {
            IsAlive = false;
            animator.SetTrigger("Death");
            Invoke("AddRB", 0.583f);

        }
        else
        {
            StartCoroutine("StunTimer");
        }
    }
    
    void AddRB()
    {
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    
}
