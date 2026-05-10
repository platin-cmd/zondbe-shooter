using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PistolController : MonoBehaviour
{

    public Animator animator;

    public KeyCode osmotrKey = KeyCode.T;

    public KeyCode reloadKey = KeyCode.R;

    public float bullet = 7;

    public float maxBullet = 7;

    public TMP_Text bulletsText;

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
            animator.Play("shoot");
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

        if (bullet == 0)
        {
            //добавь звук дебик
            animator.Play("reload");
            return;
        } 
        
        bullet -= 1;

    }
}
