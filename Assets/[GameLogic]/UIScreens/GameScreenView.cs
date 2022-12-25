using Core.Configs;
using Core.UI;
using Entitas;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreenView : UIScreen, IAnyGameListener, IUserDataMoneyListener
{
    [SerializeField] private RectTransform ScrollContent;
    [SerializeField] private TextMeshProUGUI PlayerMoney;

    private bool setScrollContentSize = false;
    private GameConfig _gameConfig;

    public override void Init(IEntity iEntity)
    {
        base.Init(iEntity);
        UIEntity.isUIGameScreen = true;

        var stateEntity = Contexts.sharedInstance.state.CreateEntity();
        stateEntity.AddAnyGameListener(this);

        _gameConfig = ConfigsCatalogsManager.GetConfig<GameConfig>();

        CreateBusinessObject();

        Contexts.sharedInstance.game.userDataEntity.AddUserDataMoneyListener(this);
    }

    public void CreateBusinessObject()
    {
        foreach (var business in _gameConfig.businesses)
        {
            var businessEntity = Contexts.sharedInstance.ui.CreateEntity();
            businessEntity.AddIndex(Array.IndexOf(_gameConfig.businesses, business));
            businessEntity.AddUIDataKey($"business_{businessEntity.index.value}");

            var businessView = Instantiate(_gameConfig.BusinessView, ScrollContent.transform);
            businessView.Init(businessEntity);
        }
    }

    public void OnAnyGame(StateEntity entity)
    {
        Open();

        SetScrollContentSize(setScrollContentSize);
    }

    public void SetScrollContentSize(bool value)
    {
        if (!value)
        {
            var gridLayoutGroup = ScrollContent.GetComponent<GridLayoutGroup>();
            var rectY = ScrollContent.transform.parent.GetComponent<RectTransform>().rect.height;
            var contentSize = _gameConfig.businesses.Length;
            var allSpacing = gridLayoutGroup.spacing.y * (contentSize - 1);
            var allCellSize = gridLayoutGroup.cellSize.y * contentSize;
            var puddingSum = gridLayoutGroup.padding.bottom + gridLayoutGroup.padding.top;
            var newOffsetMin = new Vector2(0, rectY - (allSpacing + allCellSize + puddingSum));
            ScrollContent.offsetMin = newOffsetMin;

            setScrollContentSize = true;
        }
    }

    public void OnUserDataMoney(GameEntity entity, float value)
    {
        PlayerMoney.text = $"Баланс: {value}$";
    }

    public void BackToMainMenu()
    {
        var stateEntity = Contexts.sharedInstance.state.appStateEntity;
        stateEntity.transitionLoading = true;
        stateEntity.isToMainMenu = true;
    }
}
