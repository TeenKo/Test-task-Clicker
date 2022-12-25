#if VoodooSDK && !UNITY_EDITOR
using System;

namespace Adapters.VoodooAnalytics
{
    public sealed class Voodoo : IVoodooService
    {
        /*
   === Voodoo description ===
   To set up game start event tracking:

  If your game has no levels, insert in your code:

  TinySauce.OnGameStarted();
  If your game has levels, insert in your code:

  TinySauce.OnGameStarted(levelNumber:"UserGameLevelNumber");
  Note: Please replace ‘UserGameLevelNumber’ with a string containing the actual level number of the player.

  To set up game finish event tracking (level is completed, user exits to the main menu…):

  If your game has no levels, insert in your code:

  TinySauce.OnGameFinished(score);
  Note: Please replace ‘score’ with a float containing the final score of the player.

  If your game has levels, insert in your code:

  TinySauce.OnGameFinished(isUserCompleteLevel, score);
  Notes: Please replace ‘isUserCompleteLevel’ with a boolean (True/False). Please replace ‘score’ with a float containing the final score of the player.

  To track if the user was able to finish the level of the game, insert in your code:

  TinySauce.OnGameFinished(isUserCompleteLevel, score, levelNumber:"UserGameLevelNumber");
  Notes: Please replace ‘isUserCompleteLevel’ with a boolean (True/False). Please replace ‘score’ with a float containing the final score of the player. 
  Please replace ‘UserGameLevelNumber’ with a string containing the final level number of the player.
  */

        public void Initialize(Action complete, Action<string> failed)
        {
            complete?.Invoke();
        }

        public void ApplicationOnFocus(bool focus)
        {
        }

        public void ApplicationOnPause(bool pause)
        {
        }

        public void GameLevelStart(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters)
        {
            var levelNumber = 0;
            if (eventGameLevelParameters.Parameters.TryGetValue("level_number", out var lvl))
                levelNumber = Convert.ToInt32(lvl);
            TinySauce.OnGameStarted($"{levelNumber}");
        }

        public void GameLevelFinish(AnalyticsConfig.EventGameLevelParameters eventGameLevelParameters)
        {
            var result = true;
            if (eventGameLevelParameters.Parameters.TryGetValue("result", out var res))
                result = Convert.ToString(res) == "win";
            TinySauce.OnGameFinished(result, 0);
        }
    }
}
#endif