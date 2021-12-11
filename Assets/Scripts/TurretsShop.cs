using UnityEngine;

public class TurretsShop : MonoBehaviour
{
    public static TurretsShop turretsShop;

    [SerializeField] private GameObject shopUI;

    [Header("Current Money")]
    [SerializeField] private float money;

    [Header("First turret Settings")]
    [SerializeField] private GameObject firstTurretPrefab;
    [SerializeField] private float firstTurretprice;

    [Header("Second turret Settings")]
    [SerializeField] private GameObject SecondTurretPrefab;
    [SerializeField] private float SecondTurretprice;
    

    public float Money
    {
        set
        {
            money = value;
            RefreshMoneyText();
        }
        get
        {
            return money;
        }

    }

    private Node lastNode;

    private void Awake()
    {
        if (turretsShop != null)
        {
            Debug.LogError("two turrets shop on level");
            return;
        }
        turretsShop = this;
    }

    private void Start()
    {
        RefreshPriceText();
        RefreshMoneyText();

    }

    private void RefreshMoneyText()
    {
        UITextManager.uITextManager.SetMoneyText(money.ToString());
    }

    private void RefreshPriceText()
    {
        UITextManager.uITextManager.SetfirstTurretPriceText(firstTurretprice.ToString());
        UITextManager.uITextManager.SetSecondTurretPriceText(SecondTurretprice.ToString());
    }

    public void SetActiveShopUI(Node currentNode)
    {
        if(lastNode != null)
        {
            lastNode.ChangeColorStandart();
        }
        lastNode = currentNode;

        shopUI.SetActive(true);
    }

    public void BuildFirstTurret()
    {
        if(Money >= firstTurretprice)
        {
            Money -= firstTurretprice;
            lastNode.BuildTurret(firstTurretPrefab);
            lastNode.ChangeColorStandart();
            shopUI.SetActive(false);
            lastNode = null;
        }
    }
    public void BuildSecondTurret()
    {
        if (Money >= SecondTurretprice)
        {
            Money -= SecondTurretprice;
            lastNode.BuildTurret(SecondTurretPrefab);
            lastNode.ChangeColorStandart();
            shopUI.SetActive(false);
            lastNode = null;
        }
    }
}
