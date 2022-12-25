using Entitas;

namespace Core.Extension
{
    public abstract class MonoBehAdvGame : MonoBehAdv
    {
        public GameEntity GameEntity { get; private set; }

        public override void Init(IEntity iEntity)
        {
            base.Init(iEntity);
            GameEntity = (GameEntity) iEntity;
            GameEntity.AddTransform(transform);
            GameEntity.AddHashCode(gameObject.GetHashCode());
        }
    }
}