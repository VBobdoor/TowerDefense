using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target;
    private float damage = 1;

    public Transform Target
    {
        set
        {
            target = value;
        }
    }

    private void Update()
    {
        if (target == null)
            Destroy(gameObject);
        else
            CheckDistaceAndMove();
        
    }

    private void CheckDistaceAndMove()
    {
        Vector3 bulletDirection = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (bulletDirection.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(bulletDirection.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        Enemy enemy = target.parent.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
