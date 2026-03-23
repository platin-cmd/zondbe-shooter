using UnityEngine;

public class bochkaBumBumBadabum : MonoBehaviour
{

    public GameObject explosion;

    public int Bdamage = 400;

    public float radius = 1f;

    public Vector3 offset = Vector3.zero;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            print("mama bochka");
            Collider[] colliders = Physics.OverlapSphere(Camera.main.transform.position + offset, radius);
            foreach (var col in colliders)
            {
                if (col.tag == "enemy")
                {
                    col.GetComponent<EnemyHealth>().TakeDamage(Bdamage);
                }
                else if (col.tag == "Sharik")
                {
                    col.GetComponent<SharikController>().FlyBack();
                }
                else if (col.tag == "Player")
                {
                    col.GetComponent<PlayerHealth>().TimeToDie();

                }
                
            }
            enabled = false;
            
        }
    }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + offset, radius);
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

        // Update is called once per frame
        void Update()
        {

        }
    
}


