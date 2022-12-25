using Core.UI;
using Entitas;

namespace UI
{
    public class UIDefeatScreen : UIScreen, IAnyDefeatListener
    {
        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            UIEntity.isDefeatScreen = true;
            Contexts.sharedInstance.state.CreateEntity().AddAnyDefeatListener(this);
        }

        public void OnAnyDefeat(StateEntity entity)
        {
            Open();
        }        
    }
}
