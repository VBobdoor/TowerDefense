using UnityEngine;

public class Lives : MonoBehaviour
{
    public static Lives lives; 

    [SerializeField] private GameObject loseScreen;
    private float health = 5;
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
        if (lives != null)
        {
            Debug.LogError("two LivesComponent shop on level");
            return;
        }
        lives = this;  
    }

    private void Start()
    {
        RefreshText();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        RefreshText();
    }

    private void RefreshText()
    {
        UITextManager.uITextManager.SetLivesText(Health.ToString());
    }

    private void Death()
    {
        loseScreen.SetActive(true);
    }
}
