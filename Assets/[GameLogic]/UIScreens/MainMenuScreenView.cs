using Core.UI;
using Entitas;

public class MainMenuScreenView : UIScreen, IAnyMainMenuListener
{
    public override void Init(IEntity iEntity)
    {
        base.Init(iEntity);
        var stateEntity = Contexts.sharedInstance.state.CreateEntity();
        stateEntity.AddAnyMainMenuListener(this);
    }

    public void OnAnyMainMenu(StateEntity entity)
    {
        Open();
    }
}