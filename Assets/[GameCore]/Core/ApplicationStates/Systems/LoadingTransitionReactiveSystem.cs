using Core.Configs;
using Entitas;
using System.Collections.Generic;

namespace Core.ApplicationStates
{
    public class LoadingTransitionReactiveSystem : ReactiveSystem<StateEntity>
    {
        private StateContext _stateContext;
        private StateValueConfig _stateValueConfig;

        public LoadingTransitionReactiveSystem(StateContext stateContext) : base(stateContext)
        {
            _stateContext = stateContext;
            _stateValueConfig = ConfigsCatalogsManager.GetConfig<StateValueConfig>();
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Loading.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            foreach (var entity in entities)
            {
                var timerEntity = _stateContext.CreateEntity();
                timerEntity.AddLoadingTimer(_stateValueConfig.loadingTime);
                timerEntity.isToGame = entity.isToGame;
                timerEntity.isToMainMenu = entity.isToMainMenu;

                entity.isToGame = false;
                entity.isToMainMenu = false;
            }
        }
    }
}