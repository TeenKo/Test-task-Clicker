using Entitas;
using UnityEngine;

namespace Core.Extension
{
    public abstract class MonoBehAdvUi : MonoBehAdv
    {
        public UiEntity UIEntity { get; private set; }

        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            UIEntity = (UiEntity)iEntity;
            UIEntity.AddRectTransform(GetComponent<RectTransform>());
            UIEntity.AddHashCode(gameObject.GetHashCode());
        }
    }
}
