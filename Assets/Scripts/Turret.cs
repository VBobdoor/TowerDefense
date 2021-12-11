using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCoolDown;

    private Transform target;
    private bool ableToShoot = true;

    private void OnTriggerStay(Collider other)
    {
        if (target == null)
            target = other.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        target = null;
    }

    private void Update()
    {
        if (target != null)
        {
            LookAtTarget();

            if (ableToShoot)
            {
                StartCoroutine(SetShootCoolDown());
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        Bullet currentBulletScript = currentBullet.GetComponent<Bullet>();
        if(currentBulletScript != null)
        {
            currentBulletScript.Target = target;
        }

    }

    private IEnumerator SetShootCoolDown()
    {
        ableToShoot = false;
        yield return new WaitForSeconds(shootCoolDown);
        ableToShoot = true;
    }

    private void LookAtTarget()
    {
        Vector3 targetDirection = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        Vector3 rotation = lookRotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
}
