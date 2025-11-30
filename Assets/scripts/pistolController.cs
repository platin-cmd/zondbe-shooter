using UnityEditor;
using UnityEngine;


public class pistolController : MonoBehaviour
{

    public GameObject bullet;

    public GameObject muzzleFlash;

    public Transform muzzlePlace;

    public Transform bulletPlace;

    public AudioSource  boomSound;

    public AudioSource boBoomSound;

    public LayerMask aimPlayer;

    public Animator animator;

    public GameObject bullet2;
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

        
        
        

        if (Input.GetMouseButtonDown(1))
        {
            boBoomSound.PlayOneShot(boBoomSound.clip);
            for (int i = 0; i < 200; i++)
            {

                
                Instantiate(bullet2, bulletPlace.position, transform.rotation);


            }



        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("flex");
        }
    }

   
    }

