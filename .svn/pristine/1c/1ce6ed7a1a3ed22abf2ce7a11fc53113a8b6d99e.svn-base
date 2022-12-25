// using System.Collections.Generic;
// using System.Linq;
// using Adapters;
// using Entitas;
//
// namespace Core.Analytics
// {
//     public sealed class GameLevelFinishWithLooseReactSystem : ReactiveSystem<StateEntity>
//     {
//         private readonly AnalyticContext _analyticContext;
//         private readonly IGroup<GameEntity> _userDataGroup;
//
//         public GameLevelFinishWithLooseReactSystem(AnalyticContext analyticContext, GameContext gameContext, StateContext stateContext) : base(stateContext)
//         {
//             _analyticContext = analyticContext;
//             _userDataGroup = gameContext.GetGroup(GameMatcher.AnyOf(
//                 GameMatcher.UserData,
//                 GameMatcher.UserDataGameLevel,
//                 GameMatcher.UserDataGameLevelCount,
//                 GameMatcher.UserDataGameLevelProgress,
//                 GameMatcher.UserDataGameLevelPlayTime));
//         }
//
//         protected override ICollector<StateEntity> GetTrigger(IContext<StateEntity> context)
//         {
//             return context.CreateCollector(StateMatcher.Defeat.Added());
//         }
//
//         protected override bool Filter(StateEntity entity)
//         {
//             return true;
//         }
//
//         protected override void Execute(List<StateEntity> entities)
//         {
//             if (GetUserDataEntity(out var userDataEntity) == false) return;
//             
//             // get dummy data (replace parameters to REAL DATA)
//             var dummyParameters = new AnalyticsConfig.EventGameLevelParameters().Dummy();
//             var gameLevelNumber = userDataEntity.userDataGameLevel.value; // (int) dummyParameters.ElementAt(0).Value;
//             var gameLevelName = (string) dummyParameters.ElementAt(1).Value;
//             var gameLevelCount = userDataEntity.userDataGameLevelCount.value; // (int) dummyParameters.ElementAt(2).Value;
//             var gameLevelDiff = (string) dummyParameters.ElementAt(3).Value;
//             var gameLevelLoop = (int) dummyParameters.ElementAt(4).Value;
//             var gameLevelRandom = (bool) dummyParameters.ElementAt(5).Value;
//             var gameLevelType = (string) dummyParameters.ElementAt(6).Value;
//             var gameLevelMode = (string) dummyParameters.ElementAt(7).Value;
//
//             var gameLevelResult = "loose";
//             var gameLevelTime = userDataEntity.userDataGameLevelPlayTime.value; // (int) dummyParameters.ElementAt(9).Value;
//             var gameLevelProgress = (int)(userDataEntity.userDataGameLevelProgress.value * 100);// (int) dummyParameters.ElementAt(10).Value;
//             var gameLevelContinueForAd = (int) dummyParameters.ElementAt(11).Value;
//
//             // create request to send event
//             var analyticEntity = _analyticContext.CreateEntity();
//             analyticEntity.isGameLevelFinish = true;
//             analyticEntity.AddGameLevelNumber(gameLevelNumber);
//             analyticEntity.AddGameLevelName(gameLevelName);
//             analyticEntity.AddGameLevelCount(gameLevelCount);
//             analyticEntity.AddGameLevelDiff(gameLevelDiff);
//             analyticEntity.AddGameLevelLoop(gameLevelLoop);
//             analyticEntity.AddGameLevelRandom(gameLevelRandom);
//             analyticEntity.AddGameLevelType(gameLevelType);
//             analyticEntity.AddGameLevelMode(gameLevelMode);
//
//             analyticEntity.AddGameLevelResult(gameLevelResult);
//             analyticEntity.AddGameLevelTime(gameLevelTime);
//             analyticEntity.AddGameLevelProgress(gameLevelProgress);
//             analyticEntity.AddGameLevelContinueForAd(gameLevelContinueForAd);
//         }
//         
//         private bool GetUserDataEntity(out GameEntity userDataEntity)
//         {
//             foreach (var gameEntity in _userDataGroup.GetEntities())
//             {
//                 userDataEntity = gameEntity;
//                 return true;
//             }
//
//             userDataEntity = null;
//             return false;
//         }
//     }
// }