
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaminaController : MonoBehaviour
{
    public Image stamina1; 

    public Image stamina2; 

    public float stamina;

    public float staminaSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stamina =2;
        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            stamina += staminaSpeed;
            stamina = Mathf.Clamp(stamina,0,2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina > 1)
        {
            stamina1.fillAmount=1;
            stamina2.fillAmount=stamina-1;

        }
        else
        {
            stamina2.fillAmount=0;
            stamina1.fillAmount=stamina;
        }
    }
}
