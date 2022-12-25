using System.Collections.Generic;
using System.Linq;
using Adapters;
using Entitas;

namespace Core.Analytics
{
    public sealed class GameLevelStartReactSystem : ReactiveSystem<StateEntity>
    {
        private readonly AnalyticContext _analyticContext;
        private readonly IGroup<GameEntity> _userDataGroup;

        public GameLevelStartReactSystem(AnalyticContext analyticContext, GameContext gameContext, StateContext stateContext) : base(stateContext)
        {
            _analyticContext = analyticContext;
            _userDataGroup = gameContext.GetGroup(GameMatcher.AnyOf(
                GameMatcher.UserData,
                GameMatcher.UserDataGameLevel,
                GameMatcher.UserDataGameLevelCount,
                GameMatcher.UserDataGameLevelLoop));
        }

        protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
        {
            return context.CreateCollector(StateMatcher.Game.Added());
        }

        protected override bool Filter(StateEntity entity)
        {
            return true;
        }

        protected override void Execute(List<StateEntity> entities)
        {
            if (GetUserDataEntity(out var userDataEntity) == false) return;

            // get dummy data (replace parameters to REAL DATA)
            var dummyParameters = new AnalyticsConfig.EventGameLevelParameters().Dummy();
            var gameLevelNumber = userDataEntity.userDataGameLevel.value;
            var gameLevelName = (string) dummyParameters.ElementAt(1).Value;
            var gameLevelCount =  userDataEntity.userDataGameLevelCount.value;
            var gameLevelDiff = (string) dummyParameters.ElementAt(3).Value;
            var gameLevelLoop = userDataEntity.userDataGameLevelLoop.value ;
            var gameLevelRandom = (bool) dummyParameters.ElementAt(5).Value;
            var gameLevelType = (string) dummyParameters.ElementAt(6).Value;
            var gameMode = (string) dummyParameters.ElementAt(7).Value;

            // create request to send event
            var analyticEntity = _analyticContext.CreateEntity();
            analyticEntity.isGameLevelStart = true;
            analyticEntity.AddGameLevelNumber(gameLevelNumber);
            analyticEntity.AddGameLevelName(gameLevelName);
            analyticEntity.AddGameLevelCount(gameLevelCount);
            analyticEntity.AddGameLevelDiff(gameLevelDiff);
            analyticEntity.AddGameLevelLoop(gameLevelLoop);
            analyticEntity.AddGameLevelRandom(gameLevelRandom);
            analyticEntity.AddGameLevelType(gameLevelType);
            analyticEntity.AddGameLevelMode(gameMode);
        }
        
        private bool GetUserDataEntity(out GameEntity userDataEntity)
        {
            foreach (var gameEntity in _userDataGroup.GetEntities())
            {
                userDataEntity = gameEntity;
                return true;
            }

            userDataEntity = null;
            return false;
        }
    }
}