using Unity.VisualScripting;
using UnityEngine;

public class katanaHitCVontroller : MonoBehaviour
{

    public int Kdamage = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other .gameObject.tag == "enemy")
        {
            EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(Kdamage);
            

            

            
            
        }
    }
}
