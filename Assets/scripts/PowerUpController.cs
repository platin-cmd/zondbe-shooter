using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject powerUp;

    int airJumpMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            Destroy(powerUp);
            airJumpMax = 1;
            print(airJumpMax);
        }
    }
}
