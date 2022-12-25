using System;
using UnityEngine;

namespace Core.GameLevels
{
    [Serializable]
    public class GameLevel
    {
        [SerializeField] private LevelSchema levelSchema;
        [SerializeField] private bool reusable;

        public LevelSchema LevelSchema
        {
            get
            {
                if (levelSchema == null)
                    throw new Exception($"{nameof(GameLevel)} does not contain reference to {nameof(LevelSchema)}!");

                return levelSchema;
            }
        }
        public bool Reusable => reusable;
    }
}