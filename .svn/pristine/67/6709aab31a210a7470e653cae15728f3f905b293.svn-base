using Core.UI;
using Entitas;

namespace UI
{
    public class UIVictoryScreen : UIScreen, IAnyVictoryListener
    {
        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            UIEntity.isVictoryScreen = true;
            Contexts.sharedInstance.state.CreateEntity().AddAnyVictoryListener(this);
        }

        public void OnAnyVictory(StateEntity entity)
        {
            Open();
        }
    }
}