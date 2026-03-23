using StarterAssets;
using System.Collections;
using UnityEngine;

public class kotyakrock : MonoBehaviour
{

    public float distance = 100;

    public float speedPrisos = 10;

    public KeyCode pullKey = KeyCode.Q;

    public LayerMask layermask;

    FirstPersonController  fpc;

    Vector3 playerPullPoint;
    void PullAnimation()
    {

    }

    void PullObjectToPlayer()
    {

    }

    

    void BothCooking()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fpc = GetComponent<FirstPersonController>();
    }

    IEnumerator PullPlayerToObject()
    {
        print(": puk playir");
        fpc.enabled = false;
        while(Vector3.Distance(transform.position, playerPullPoint) > 5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPullPoint, speedPrisos * Time.deltaTime);
            Debug.LogError("Distance: " + Vector3.Distance(transform.position, playerPullPoint));
            yield return null;
        }
        fpc.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pullKey))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit, distance, layermask))
            {

                print("popal");
                Pullablya pullable;
                if(hit.collider.TryGetComponent(out pullable))
                {
                    switch (pullable.pulltype)
                    {
                        case PullType.PullObjectToPlayer:
                            PullObjectToPlayer();
                            break;
                        case PullType.PullPlayerToObject:
                            playerPullPoint = hit.point;
                            StartCoroutine("PullPlayerToObject");  
                            break;
                        case PullType.BothCooking:
                            BothCooking();
                            break;
                    }
                }
            }
        }
    }
}
