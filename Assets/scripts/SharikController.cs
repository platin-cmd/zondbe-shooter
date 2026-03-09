using UnityEngine;

public class SharikController : MonoBehaviour
{
    Rigidbody rb;
    public float flyBackSpeed = 10;
    public AudioSource sound;
    public void FlyBack()
    {
        rb.AddForce(Camera.main.transform.forward * flyBackSpeed, ForceMode.Impulse);
        sound.Play();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
