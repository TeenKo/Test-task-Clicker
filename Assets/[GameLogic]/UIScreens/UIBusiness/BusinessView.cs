using Core.Configs;
using Core.Extension;
using Entitas;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BusinessView : MonoBehAdvUi, INameListener, ILevelUpPriceListener, IIncomeListener, IBusinessLevelListener, IIncomeTimerListener, IUserDataMoneyListener, ISecondUpgradePurchasedListener, IFirstUpgradePurchasedListener
{
    [Header("Business")]
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Level;
    [SerializeField] private TextMeshProUGUI Income;
    [SerializeField] private TextMeshProUGUI LevelUpPrice;
    [SerializeField] private Image IncomeFillAmount;
    [SerializeField] private Button LevelUpButton;

    [Header("First Upgrade")]
    [SerializeField] private TextMeshProUGUI FirstUpgradeName;
    [SerializeField] private TextMeshProUGUI FirstUpgradeMultiply;
    [SerializeField] private TextMeshProUGUI FirstUpgradePrice;
    [SerializeField] private Button BuyFirstUpgradeButton;

    [Header("Second Upgrade")]
    [SerializeField] private TextMeshProUGUI SecondUpgradeName;
    [SerializeField] private TextMeshProUGUI SecondUpgradeMultiply;
    [SerializeField] private TextMeshProUGUI SecondUpgradePrice;
    [SerializeField] private Button BuySecondUpgradeButton;


    private GameConfig _gameConfig;
    private Business _business;

    public override void Init(IEntity iEntity)
    {
        base.Init(iEntity);
        _gameConfig = ConfigsCatalogsManager.GetConfig<GameConfig>();

        _business = _gameConfig.businesses[UIEntity.index.value];
        var firstBusiness = UIEntity.index.value == 0;
        IncomeFillAmount.fillAmount = 0f;

        UIEntity.isBusiness = true;
        UIEntity.AddBusinessLevel(firstBusiness ? 1 : 0);
        UIEntity.AddName(_business.name);
        UIEntity.AddIncome(_business.income);
        UIEntity.AddPurchased(firstBusiness ? true : false);
        UIEntity.AddLevelUpPrice(_business.price);
        UIEntity.AddFirstMultiply(0);
        UIEntity.AddSecondMultiply(0);
        UIEntity.AddFirstUpgradePurchased(false);
        UIEntity.AddSecondUpgradePurchased(false);

        UIEntity.AddNameListener(this);
        UIEntity.AddLevelUpPriceListener(this);
        UIEntity.AddIncomeListener(this);
        UIEntity.AddBusinessLevelListener(this);
        UIEntity.AddIncomeTimerListener(this);
        UIEntity.AddSecondUpgradePurchasedListener(this);
        UIEntity.AddFirstUpgradePurchasedListener(this);

        Contexts.sharedInstance.game.userDataEntity.AddUserDataMoneyListener(this);

        UIEntity.systemTriggerUILoadData = true;
    }

    public void OnName(UiEntity entity, string value)
    {
        Name.text = $"{value}";
        FirstUpgradeName.text = _business.first.name;
        SecondUpgradeName.text = _business.second.name;
    }

    public void OnLevelUpPrice(UiEntity entity, float value)
    {
        LevelUpPrice.text = $"Цена: {value}$";

        var firstUpgradeText = entity.firstUpgradePurchased.value ? $"Куплено" : $"Цена: {_business.first.price}$";
        var secondUpgradeText = entity.secondUpgradePurchased.value ? $"Куплено" : $"Цена: {_business.second.price}$";

        FirstUpgradePrice.text = firstUpgradeText;
        SecondUpgradePrice.text = secondUpgradeText;
    }

    public void OnIncome(UiEntity entity, float value)
    {
        Income.text = $"{value}$";
        FirstUpgradeMultiply.text = $"Доход: +{_business.first.multiplyIncome}%";
        SecondUpgradeMultiply.text = $"Доход: +{_business.second.multiplyIncome}%";
    }

    public void OnBusinessLevel(UiEntity entity, int value)
    {
        Level.text = $"{value}";
    }

    public void OnIncomeTimer(UiEntity entity, float value)
    {
        IncomeFillAmount.fillAmount = (_business.delayIncome - value) / _business.delayIncome;
    }

    public void BusinessLevelUp()
    {
        var requestPurchaseEntity = Contexts.sharedInstance.ui.CreateEntity();
        requestPurchaseEntity.isPurchase = true;
        requestPurchaseEntity.AddIndex(UIEntity.index.value);
    }

    public void BuyFirstUpgrade()
    {
        var requestPurchaseEntity = Contexts.sharedInstance.ui.CreateEntity();
        requestPurchaseEntity.isFirstUpgradePurchase = true;
        requestPurchaseEntity.AddIndex(UIEntity.index.value);
    }

    public void BuySecondUpgrade()
    {
        var requestPurchaseEntity = Contexts.sharedInstance.ui.CreateEntity();
        requestPurchaseEntity.isSecondUpgradePurchase = true;
        requestPurchaseEntity.AddIndex(UIEntity.index.value);
    }

    public void OnUserDataMoney(GameEntity entity, float value)
    {
        LevelUpButton.interactable = value >= UIEntity.levelUpPrice.value ? true : false;
        BuyFirstUpgradeButton.interactable = value >= _business.first.price && UIEntity.purchased.value && UIEntity.firstUpgradePurchased.value == false ? true : false;
        BuySecondUpgradeButton.interactable = value >= _business.second.price && UIEntity.purchased.value && UIEntity.secondUpgradePurchased.value == false ? true : false;
    }

    public void OnFirstUpgradePurchased(UiEntity entity, bool value)
    {
        if (value)
        {
            BuyFirstUpgradeButton.interactable = !value;
        }
    }

    public void OnSecondUpgradePurchased(UiEntity entity, bool value)
    {
        if (value)
        {
            BuySecondUpgradeButton.interactable = !value;
        }
    }
}
