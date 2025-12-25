using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public Text clickPerSecondText;
    public Text clickCounterText;
    public Text upgradeText;
    public Text autoClickUpgradeText;
    
    public Text upgrade5Text;
    public Text upgrade25Text;
    public Text auto5Text;
    public Text auto25Text;

    private int clickCounter = 0;
    private int clickUpgradePrice = 200;
    private int clickMultiplier = 1;
    private int autoClickUpgradePrice = 150;
    private int autoClickRate = 0;
    
    private int upgrade5Price = 750;
    private int upgrade25Price = 3750;
    private int auto5Price = 550;
    private int auto25Price = 2250;

    void Start()
    {
        UpdateUI();
        StartCoroutine(AutoClick());
    }

    public void OnClick()
    {
        clickCounter += clickMultiplier;
        UpdateUI();
    }

    public void BuyUpgrade()
    {
        if (clickCounter >= clickUpgradePrice)
        {
            clickCounter -= clickUpgradePrice;
            clickUpgradePrice += 100;
            clickMultiplier += 1;
            UpdateUI();
        }
    }

    public void BuyAutoClickUpgrade()
    {
        if (clickCounter >= autoClickUpgradePrice)
        {
            clickCounter -= autoClickUpgradePrice;
            autoClickUpgradePrice += 50;
            autoClickRate += 1;
            UpdateUI();
        }
    }
    
    public void BuyUpgrade5()
    {
        if (clickCounter >= upgrade5Price)
        {
            clickCounter -= upgrade5Price;
            upgrade5Price += 375;
            clickMultiplier += 5;
            UpdateUI();
        }
    }
    
    public void BuyUpgrade25()
    {
        if (clickCounter >= upgrade25Price)
        {
            clickCounter -= upgrade25Price;
            upgrade25Price += 1875;
            clickMultiplier += 25;
            UpdateUI();
        }
    }
    
    public void BuyAuto5()
    {
        if (clickCounter >= auto5Price)
        {
            clickCounter -= auto5Price;
            auto5Price += 275;
            autoClickRate += 5;
            UpdateUI();
        }
    }
    
    public void BuyAuto25()
    {
        if (clickCounter >= auto25Price)
        {
            clickCounter -= auto25Price;
            auto25Price += 1125;
            autoClickRate += 25;
            UpdateUI();
        }
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            clickCounter += autoClickRate;
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (clickCounterText != null)
            clickCounterText.text = "Баланс: " + clickCounter.ToString();
            
        if (clickPerSecondText != null)
            clickPerSecondText.text = "Кликов в сек: " + autoClickRate.ToString();
            
        if (upgradeText != null)
            upgradeText.text = "Цена улучшения: " + clickUpgradePrice.ToString();
            
        if (autoClickUpgradeText != null)
            autoClickUpgradeText.text = "Цена авто-клика: " + autoClickUpgradePrice.ToString();
        
        if (upgrade5Text != null)
            upgrade5Text.text = "Цена улучшения: " + upgrade5Price;
            
        if (upgrade25Text != null)
            upgrade25Text.text = "Цена улучшения: " + upgrade25Price;
            
        if (auto5Text != null)
            auto5Text.text = "Цена авто-клика: " + auto5Price;
            
        if (auto25Text != null)
            auto25Text.text = "Цена авто-клика: " + auto25Price;
    }
}