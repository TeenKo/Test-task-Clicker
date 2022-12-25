using System;
using System.Collections.Generic;
using System.Linq;
using Core.GameLevels;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.GameLevelsLoadRule
{
    /// <summary>
    /// Returned next game level schema of game levels if current index less than game levels number
    /// and return random game level schema of reusable game levels if received current index greater then game levels number.
    /// On restart will return the saved game level index (from previous request).
    /// </summary>
    public sealed class RandomLoopedChainGameLevelsLoadRule : IGameLevelsLoadRule
    {
        private readonly GameLevel[] _gameLevels;
        private readonly int[] _loopedGameLevels;
        private readonly int _gameLevelsCount;

        /// <summary>
        /// Available indexes of reusable game levels
        /// </summary>
        private List<int> _availableIndexes;

        private int _lastRequestedIndex;
        private int _lastReturnedRandomIndex;

        public RandomLoopedChainGameLevelsLoadRule([NotNull] in GameLevel[] gameLevels)
        {
            _gameLevels = gameLevels;

            _loopedGameLevels = (from gameLevel in _gameLevels
                where gameLevel.Reusable
                select Array.IndexOf(_gameLevels, gameLevel)).ToArray();

            _availableIndexes = _loopedGameLevels.ToList();
            _gameLevelsCount = gameLevels.Length;

            _lastRequestedIndex = -1;
            _lastReturnedRandomIndex = 0;
        }

        /// <summary>
        /// Returned next game level schema of game levels if current index less than game levels number
        /// and return random game level schema of reusable game levels if received current index greater then game levels number.
        /// On restart will return the saved game level index (from previous request).
        /// </summary>
        /// <param name="currentIndex">Current game level index</param>
        /// <param name="levelIndex"></param>
        /// <returns></returns>
        /// <exception cref="Exception">If index less then zero</exception>
        public LevelSchema GetNextLevel(int currentIndex, out int levelIndex)
        {
            levelIndex = -1;
            // returned next game level schema
            if (currentIndex >= 0 && currentIndex < _gameLevelsCount) return _gameLevels[currentIndex].LevelSchema;


            // returned random game level schema
            if (currentIndex >= 0 && currentIndex >= _gameLevelsCount)
            {
                // on restart will return the saved game level index (from previous request)
                if (_lastRequestedIndex == currentIndex)
                {
                    levelIndex = _lastReturnedRandomIndex;
                    return _gameLevels[_lastReturnedRandomIndex].LevelSchema;
                }

                var availableIndexesCount = _availableIndexes.Count;
                if (availableIndexesCount == 0) _availableIndexes = _loopedGameLevels.ToList();

                var randomIndex = availableIndexesCount < 2 ? 0 : Random.Range(0, availableIndexesCount);
                var indexValue = _availableIndexes[randomIndex];

                if (availableIndexesCount < 2)
                {
                    _availableIndexes.Clear();
                    _availableIndexes = _loopedGameLevels.ToList();
                }
                else _availableIndexes.RemoveAt(randomIndex);

                _lastRequestedIndex = currentIndex;
                _lastReturnedRandomIndex = indexValue;
                levelIndex = indexValue;

                return _gameLevels[indexValue].LevelSchema;
            }

            throw new Exception(
                $"{nameof(RandomLoopedChainGameLevelsLoadRule)}.{nameof(GetNextLevel)}() {nameof(currentIndex)} out of bounds!");
        }

        public LevelSchema GetLevelByIndex(int currentIndex)
        {
            return _gameLevels[Mathf.Clamp(currentIndex, 0, _gameLevelsCount)].LevelSchema;
        }
    }
}