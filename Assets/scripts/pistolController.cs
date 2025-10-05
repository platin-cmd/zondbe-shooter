using UnityEngine;


public class pistolController : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPlace;

    public AudioClip  boomSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletPlace.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(boomSound, bulletPlace.position);
        }
    }
}
