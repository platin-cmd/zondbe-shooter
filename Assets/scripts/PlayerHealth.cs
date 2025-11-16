using UnityEngine;
using System.Collections;
using Cinemachine;


public class PlayerHealth : MonoBehaviour
{

    public float deadSeconds = 0.15f;

    public GameObject deadPlayer;

    public CinemachineVirtualCamera virtualCamera;

    public GameObject Text;

    public GameObject pricel;

    public void TimeToDie()
    {
        StartCoroutine("Dead");
    }
    public IEnumerator Dead()
    {
        yield return new WaitForSeconds(deadSeconds);
        Destroy(gameObject);
        GameObject dead = Instantiate(deadPlayer, transform.position, transform.rotation);
        GameObject cameraRoot = dead.GetComponentInChildren<CameraRoot>().gameObject;
        virtualCamera.Follow = cameraRoot.transform;
        Text.SetActive(true);
        pricel.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
