using UnityEditor;
using UnityEngine;


public class pistolController : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletPlace;

    public AudioSource  boomSound;

    public AudioSource boBoomSound;

    public LayerMask aimPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    Vector3 GetCrosshairDirection()
    {
        Transform cameraTransform = Camera.main.transform;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, cameraTransform.forward, out hit))
        {
            Vector3 dir = (hit.point - transform.position).normalized;
            return dir;
        }

        return transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 dir = GetCrosshairDirection();
            GameObject bulletObj = Instantiate(bullet, bulletPlace.position, Quaternion.Euler(dir));
            bulletObj.transform.forward = dir;



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

