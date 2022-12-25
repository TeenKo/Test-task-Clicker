using Entitas;

public sealed class GameSystems : Systems
{
    public GameSystems(Contexts contexts, GameConfig gameConfig)
    {
        Add(new CheckGameStartedReactiveSystem(contexts));
        Add(new GameStartedReactiveSystem(contexts));
        Add(new BusinessLevelUpReactiveSystem(contexts));
        Add(new BusinessPurchasedReactiveSystem(contexts));
        Add(new StartIncomeTimerReactiveSystem(contexts));
        Add(new BusinessIncomeTimerReactiveSystem(contexts));
        Add(new GetMoneyReactiveSystem(contexts));
        Add(new BusinessLevelReactiveSystem(contexts));
        Add(new ChangeBusinessValueReactiveSystem(contexts));
        Add(new UpgradePurchaseReactiveSystem(contexts));
        Add(new FirstUpgradePurchasedReactiveSystem(contexts));
        Add(new SecondUpgradePurchasedReactiveSystem(contexts));

        //==========================================================
        //                      Save Systems
        //==========================================================
        Add(new SaveBusinessLevelReactiveSystem(contexts));
        Add(new SavePurchasedReactiveSystem(contexts));
        Add(new SaveFirstUpgradePurchasedReactiveSystem(contexts));
        Add(new SaveSecondUpgradePurchasedReactiveSystem(contexts));
        Add(new SaveUserDataMoneyReactiveSystem(contexts));
    }
}