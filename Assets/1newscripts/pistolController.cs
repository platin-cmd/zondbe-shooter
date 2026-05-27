using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PistolController : MonoBehaviour
{

    public Animator animator;

    public KeyCode osmotrKey = KeyCode.T;

    public KeyCode reloadKey = KeyCode.R;

    public float bullet = 7;

    public float maxBullet = 7;

    public TMP_Text bulletsText;

    public LayerMask mellstroi;

    public GameObject hitRockEffect;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bulletsText.text = bullet + "/" + maxBullet;

        if (Input.GetMouseButtonDown(0))
        {
            if (bullet == 0)
            {
                string bebe  = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
                //добавь звук дебик
                if (bebe != "prezaruadka")
                {
                    animator.Play("reload");
                }
                return;
            }
            else
            {
                animator.Play("shoot");
            }
            
        }

        if (Input.GetKeyDown(osmotrKey))
        {
            animator.Play("osmotr");
        }

        if (Input.GetKeyDown(reloadKey))
        {
            animator.Play("reload");
        }

        
    }

    public void reloadComplete()
    {
        bullet = maxBullet;
    }

    public void shootComplete()
    {

        

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, 1000, mellstroi))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Untagged"))
            {
                Vector3 pos = hit.point + hit.normal * 0.01f;
                Quaternion rot = Quaternion.LookRotation(hit.normal);
                Instantiate(hitRockEffect,pos,rot); 
            }
        }

        bullet -= 1;

    }
}
