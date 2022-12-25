using Core.UI;
using Entitas;

namespace UI
{
    public class UILoadingScreen : UIScreen, IAnyLoadingListener
    {
        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            UIEntity.isLoadScreen = true;
            Contexts.sharedInstance.state.CreateEntity().AddAnyLoadingListener(this);
        }
        
        public void OnAnyLoading(StateEntity entity)
        {
            Open();
        }
    }
}