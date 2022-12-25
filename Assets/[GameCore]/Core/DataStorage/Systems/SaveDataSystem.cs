using System.Collections.Generic;
using Entitas;
using Newtonsoft.Json;
using UnityEngine;

namespace Core.DataStorage
{
    public class SaveDataSystem : ReactiveSystem<GameEntity>
    {
        private readonly DebugLogConfig _debugLogConfig;

        public SaveDataSystem(GameContext gameContext, DebugLogConfig debugLogConfig) : base(gameContext)
        {
            _debugLogConfig = debugLogConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SaveData.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDataKey;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var dictionary = new Dictionary<string, object>();
                var dataKey = gameEntity.dataKey.value;

                foreach (var component in gameEntity.GetComponents())
                {
                    if (!(component is ISavableData savableData)) continue;

                    dictionary.Add(savableData.ToString(), savableData.GetValue);
                }

                var result = JsonConvert.SerializeObject(dictionary);
                PlayerPrefs.SetString(dataKey, result);

                if (_debugLogConfig.SaveAndLoadData) Dbg.Log($"Данные: {dataKey} сохранены");
            }
        }
    }
}