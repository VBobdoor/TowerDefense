using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
    public static UITextManager uITextManager;

    [SerializeField] private Text livesText;
    [SerializeField] private Text moneyText;
    [SerializeField] private Text currentWaveText;
    [SerializeField] private Text firstTurretCostText;
    [SerializeField] private Text SecondTurretCostText;

    private const string LIVES_COUNT_TEXT_ADDITION = "Lives : ";
    private const string WAVE_TEXT_ADDITION = "Current Wave : ";
    private const string MONEY_TEXT_ADDITION = "$ ";

    private void Awake()
    {
        if (uITextManager != null)
        {
            Debug.LogError("two UITextManager on level");
            return;
        }

        uITextManager = this;
    }

    public void SetLivesText(string _lives)
    {
        livesText.text = LIVES_COUNT_TEXT_ADDITION + _lives;
    }
     
    public void SetCurrentWaveText(string _currentWave)
    {
        currentWaveText.text = WAVE_TEXT_ADDITION + _currentWave;
    }

    public void SetMoneyText(string _money)
    {
        moneyText.text = MONEY_TEXT_ADDITION + _money;
    }

    public void SetfirstTurretPriceText(string _firstTurretCost)
    {
        firstTurretCostText.text = MONEY_TEXT_ADDITION + _firstTurretCost;
    }

    public void SetSecondTurretPriceText(string _secondTurretCost)
    {
        SecondTurretCostText.text = MONEY_TEXT_ADDITION + _secondTurretCost;
    }
}
