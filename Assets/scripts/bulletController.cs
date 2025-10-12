using UnityEngine;

public class bullet : MonoBehaviour
{

    Rigidbody rb;

    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "map")
        {
            Destroy(gameObject);
         }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
