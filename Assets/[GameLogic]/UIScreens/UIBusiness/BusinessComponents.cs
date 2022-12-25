using Core.DataStorage;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using System;

[Ui]
public sealed class BusinessComponent : IComponent
{

}

[Ui, Event(EventTarget.Self)]
public sealed class BusinessLevelComponent : IComponent, ISavableData
{
    public int value;

    public object GetValue => value;

    public void SetValue(object value)
    {
        this.value = Convert.ToInt32(value);
    }
}

[Ui]
public sealed class BusinessLevelUpComponent : IComponent
{

}

[Ui]
public sealed class IndexComponent : IComponent
{
    public int value;
}

[Ui, Event(EventTarget.Self)]
public sealed class NameComponent : IComponent
{
    public string value;
}

[Ui, Event(EventTarget.Self)]
public sealed class IncomeTimerComponent : IComponent
{
    public float value;
}

[Ui, Event(EventTarget.Self)]
public sealed class IncomeComponent : IComponent
{
    public float value;
}

[Ui]
public sealed class PurchaseComponent : IComponent
{

}

[Ui, Event(EventTarget.Self)]
public sealed class LevelUpPriceComponent : IComponent
{
    public float value;
}

[Ui, Event(EventTarget.Self)]
public sealed class PurchasedComponent : IComponent, ISavableData
{
    public bool value;

    public object GetValue => value;

    public void SetValue(object value)
    {
        this.value = Convert.ToBoolean(value);
    }
}

[Ui]
public sealed class GetMoneyComponent : IComponent
{

}

[Ui]
public sealed class StartIncomeTimerComponent : IComponent
{

}

[Ui]
public sealed class ChangeBusinessValueComponent : IComponent
{

}

//===========================================================================
//                          First Upgrade
//===========================================================================

[Ui, Event(EventTarget.Self)]
public sealed class FirstUpgradePurchasedComponent : IComponent, ISavableData
{
    public bool value;

    public object GetValue => value;

    public void SetValue(object value)
    {
        this.value = Convert.ToBoolean(value);
    }
}

[Ui]
public sealed class FirstMultiplyComponent : IComponent
{
    public float value;
}

[Ui]
public sealed class FirstUpgradePurchaseComponent : IComponent
{

}

//===========================================================================
//                          Second Upgrade
//===========================================================================

[Ui, Event(EventTarget.Self)]
public sealed class SecondUpgradePurchasedComponent : IComponent, ISavableData
{
    public bool value;

    public object GetValue => value;

    public void SetValue(object value)
    {
        this.value = Convert.ToBoolean(value);
    }
}

[Ui]
public sealed class SecondMultiplyComponent : IComponent
{
    public float value;
}

[Ui]
public sealed class SecondUpgradePurchaseComponent : IComponent
{

}