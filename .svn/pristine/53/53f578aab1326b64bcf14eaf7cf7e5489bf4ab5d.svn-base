using Core.UI;
using Entitas;

namespace UI
{
    public class UIGameScreen : UIScreen, IAnyGameListener
    {
        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            UIEntity.isGameScreen = true;
            Contexts.sharedInstance.state.CreateEntity().AddAnyGameListener(this);
        }

        public void OnAnyGame(StateEntity entity)
        {
            Open();
        }
    }
}