using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;

    public float health;

    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject,5);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
