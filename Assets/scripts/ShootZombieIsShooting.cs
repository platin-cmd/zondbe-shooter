using UnityEngine;

public class ShootZombieIsShooting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject bullet;

    public Transform bulletPlaceSpawn;



    public void Shoot()
    {
        Instantiate(bullet, bulletPlaceSpawn.position, Quaternion.identity);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
