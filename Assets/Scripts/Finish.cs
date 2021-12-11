using UnityEngine;

public class Finish : MonoBehaviour
{
    private float damagePerUnit = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Lives.lives.TakeDamage(damagePerUnit);
    }

}
