using UnityEngine;


public class pistolController : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPlace;

    public AudioSource  boomSound;

    public AudioSource boBoomSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, bulletPlace.position, transform.rotation);

            boomSound.PlayOneShot(boomSound.clip);
        }

        if (Input.GetMouseButtonDown(1))
        {
            boBoomSound.PlayOneShot(boBoomSound.clip);
            for (int i = 0; i < 200; i++)
            {
                Instantiate(bullet, bulletPlace.position, transform.rotation);


            }

            

        }
    }
}
