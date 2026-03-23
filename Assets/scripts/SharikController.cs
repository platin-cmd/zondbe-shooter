using UnityEngine;

public class SharikController : MonoBehaviour
{

    Rigidbody rb;
    public float flyBackSpeed = 10;
    public float moveSpeed = 100;
    public AudioSource sound;

    Transform player;
    public void FlyBack()
    {
        player = null;
        rb.AddForce(Camera.main.transform.forward * flyBackSpeed, ForceMode.Impulse);
        sound.Play();
        rb.useGravity = true;
        Destroy(gameObject, 5);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = Camera.main.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            rb.linearVelocity = dir * moveSpeed;
            rb.linearVelocity = dir * moveSpeed;
        }
    }
}
