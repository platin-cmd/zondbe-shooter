using UnityEngine;
using System.Collections;


public enum EnemyState
{
    Stand,
    Attack
}
public class enemyTurret : MonoBehaviour
{
    EnemyState state = EnemyState.Stand;

    public LayerMask castLayer;

    public float distance = 100000;

    public GameObject player;

    public float shootTime = 0.5f;

    public Transform bulletPlace;

    public GameObject bullet;

    public float bulletForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();

        Vector3 dir;

        switch (state)
        {
            case EnemyState.Stand:
                dir = (player.transform.position - transform.position).normalized;
                if(Physics.Raycast(transform.position,dir, out hit, distance, castLayer))
                {
                    state = EnemyState.Attack;
                    StartCoroutine("ShootTimer");
                }
                break;
            case EnemyState.Attack:
                transform.LookAt(player.transform.position);

                dir = (player.transform.position - transform.position).normalized;

                if(!Physics.Raycast(transform.position,dir,out hit, distance, castLayer))
                {
                    state = EnemyState.Stand;
                    StopAllCoroutines();
                    
                }

                break;
            default:
                break;    
        }
    }

    IEnumerator ShootTimer()
    {
        while (true)
        {
            GameObject newBullet = Instantiate(bullet,bulletPlace.position,Quaternion.identity);
            newBullet.transform.LookAt(player.transform.position);
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward*bulletForce,ForceMode.Impulse);
            Destroy(newBullet,5);

            yield return new WaitForSeconds(shootTime);
        }
    }
}
