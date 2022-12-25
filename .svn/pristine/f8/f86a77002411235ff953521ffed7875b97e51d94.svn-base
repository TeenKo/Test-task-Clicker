using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace UI
{
    [Ui]
    public sealed class UIPlayerMoneyComponent : IComponent
    {
    }

    [Ui, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class UIPlayerMoneyShowComponent : IComponent
    {
        
    }
    
    [Ui, Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public sealed class UIPlayerMoneyHideComponent : IComponent
    {
        
    }

    [Ui, Event(EventTarget.Self)]
    public sealed class UIPlayerMoneyValueComponent : IComponent
    {
        public int value;
    }
}