using Entitas;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ApplicationStates
{
    public class LoadingTimerReactionSystem : ReactiveSystem<StateEntity>
    {
        private StateContext _stateContext;
        public LoadingTimerReactionSystem(StateContext stateContext) : base(stateContext)
        {
            _stateContext = stateContext;
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.LoadingTimer.Added());
        }
 
        protected override bool Filter(StateEntity entity)
        {
            return entity.hasLoadingTimer;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            foreach (var entity in entities)
            {
                var timeValue = entity.loadingTimer.value - Time.deltaTime;

                if (timeValue <= 0)
                {
                    entity.RemoveLoadingTimer();

                    if (entity.isToGame)
                    {
                        _stateContext.appStateEntity.transitionGame = true;
                    }

                    if (entity.isToMainMenu)
                    {
                        _stateContext.appStateEntity.transitionMainMenu = true;
                    }

                    entity.Destroy();

                    break;
                }

                entity.ReplaceLoadingTimer(timeValue);
            }
        }
    }
}