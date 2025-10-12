using UnityEngine;

public class HouseBabaxController : MonoBehaviour
{

    public GameObject house;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        house.SetActive(false);
    }
}
