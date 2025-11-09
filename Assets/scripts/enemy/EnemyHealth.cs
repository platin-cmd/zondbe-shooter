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

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        animator = GetComponentInChildren<Animator>();
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            IsAlive = false;
            animator.SetTrigger("Death");
            Invoke("AddRB", 0.583f);

        }
    }
    
    void AddRB()
    {
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
