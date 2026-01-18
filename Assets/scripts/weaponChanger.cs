using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class weaponChanger : MonoBehaviour
{

    Animator animator;
    public GameObject pistolObject;
    public GameObject shotgunObject;
    public GameObject Radius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    public void DiactivatePistol()
    {
        pistolObject.SetActive(false);
    }
    public void DiactivateShotgun()
    {
        shotgunObject.SetActive(false);
    }

    public void ActivatePistol()
    {
        pistolObject.SetActive(true);
    }
    public void ActivateShotgun()
    {
        shotgunObject.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("TakeShotgun");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("TakePistol");
        }
    }
    public void reload()
    {
        if (pistolObject.activeSelf)
        {
            pistolObject.GetComponent<pistolController>().reload();
        }
        else if (shotgunObject.activeSelf)
        {
            shotgunObject.GetComponent<shotgunController>().reloadShotgun();
        }
    }

    
    
    
    
}
