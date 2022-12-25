using Core.UI;
using Entitas;

namespace UI
{
    public class UIMainMenuScreen : UIScreen, IAnyMainMenuListener
    {
        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            UIEntity.isMainManuScreen = true;
            Contexts.sharedInstance.state.CreateEntity().AddAnyMainMenuListener(this);
        }
        public void OnAnyMainMenu(StateEntity entity)
        {
            Open();
        }
    }

}
