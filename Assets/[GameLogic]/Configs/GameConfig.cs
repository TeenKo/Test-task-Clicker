using Core.Configs;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/Game/GameConfig")]
public sealed class GameConfig : Config
{
    public const string PlayerDataKey = "playerData";

    public BusinessView BusinessView;
    public Business[] businesses;

    public float GetIncome(UiEntity entity)
    {
        var business = businesses[entity.index.value];
        var level = entity.businessLevel.value;
        var income = business.income;
        float firstMultiply = entity.firstMultiply.value;
        float secondMultiply = entity.secondMultiply.value;
        float endValue = level * income * (1 + firstMultiply + secondMultiply);

        return endValue;
    }

    public float GetLevelPrice(UiEntity entity)
    {
        var business = businesses[entity.index.value];
        var level = entity.businessLevel.value;
        var price = business.price;
        var endValue = (level + 1) * price;
        return endValue;
    }
}

[Serializable]
public class Business
{
    public string name;
    public float delayIncome;
    public int price;
    public int income;
    public BusinessImprovement first;
    public BusinessImprovement second;
}

[Serializable]
public class BusinessImprovement
{
    public string name;
    public int price;
    public float multiplyIncome;
}

