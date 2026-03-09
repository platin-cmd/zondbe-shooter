using UnityEngine;

public class katanaHitCVontroller : MonoBehaviour
{

    public int Kdamage = 200;

    [Header("Hit Settings")]
    public float radius = 1;
    public Vector3 offset = Vector3.zero;

    public void CheckAttackSphere()
    {
        print("mama katana");
        Collider[] colliders = Physics.OverlapSphere(Camera.main.transform.position + offset, radius);
        foreach (var col in colliders)
        {
            if (col.tag == "enemy")
            {
                col.GetComponent<EnemyHealth>().TakeDamage(Kdamage);
            }
            else if (col.tag == "Sharik")
            {
                col.GetComponent<SharikController>().FlyBack();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Camera.main.transform.position + offset, radius);
    }
}
