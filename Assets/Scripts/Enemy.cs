using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float priceForMurder = 5;
    private Animator animator;
    private float health = 3;
    private float Health
    {
        set
        {
            if (value <= 0)
                Death();
            else
                health = value;
        }
        get
        {
            return health;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }

    public void Destroy()
    {
        TurretsShop.turretsShop.Money += priceForMurder;
        Destroy(gameObject);
    } 

    private void Death()
    {
        animator.SetTrigger("Death");
    }
}
