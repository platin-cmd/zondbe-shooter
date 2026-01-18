using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


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

    public int magazineMax=6;

    int magazineCurrent = 6;

    public Text ammoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magazineCurrent = magazineMax;
        ammoText.text = magazineCurrent + "/"+ magazineMax;
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
            if (magazineCurrent == 0)
            {
                //добавь звук дебик
                animator.SetTrigger("reload");
                return;
            } 

            boBoomSound.PlayOneShot(boBoomSound.clip);
            for (int i = 0; i < 200; i++)
            {

                
                Instantiate(bullet2, bulletPlace.position, transform.rotation);


            }
            magazineCurrent--;
            ammoText.text = magazineCurrent + "/"+ magazineMax;



        }

    

        if (Input.GetKeyDown(KeyCode.T))
        {
            animator.SetTrigger("flex");
        }

        
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("reload");
        }


       
    }

    public void reload()
    {
        magazineCurrent = magazineMax;
        ammoText.text = magazineCurrent + "/"+ magazineMax;
    }

   
    }

