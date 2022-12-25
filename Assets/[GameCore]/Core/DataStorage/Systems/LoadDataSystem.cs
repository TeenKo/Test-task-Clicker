using System.Collections.Generic;
using Entitas;
using Newtonsoft.Json;
using UnityEngine;

namespace Core.DataStorage
{
    public sealed class LoadDataSystem : ReactiveSystem<GameEntity>
    {
        private readonly DebugLogConfig _debugLogConfig;

        public LoadDataSystem(GameContext gameContext, DebugLogConfig debugLogConfig) : base(gameContext)
        {
            _debugLogConfig = debugLogConfig;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.LoadData);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDataKey;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var jsonDataString = PlayerPrefs.GetString(gameEntity.dataKey.value, string.Empty);

                if (string.IsNullOrEmpty(jsonDataString))
                {
                    if (_debugLogConfig.SaveAndLoadData) Dbg.Log($"{nameof(LoadDataSystem)} файл с данными не найден");
                    gameEntity.systemTriggerLoadingDataFailed = true;
                    continue;
                }

                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonDataString);

                foreach (var item in dictionary)
                {
                    for (var i = 0; i < GameComponentsLookup.componentNames.Length; i++)
                    {
                        if (item.Key != GameComponentsLookup.componentTypes[i].ToString()) continue;

                        var savableDataComponent =
                            System.Activator.CreateInstance(GameComponentsLookup.componentTypes[i]);
                        var activator = savableDataComponent as IComponent;
                        var savableData = savableDataComponent as ISavableData;

                        gameEntity.ReplaceComponent(i, activator);
                        savableData?.SetValue(item.Value);
                    }
                }

                gameEntity.systemTriggerLoadingDataSuccessful = true;

                if (_debugLogConfig.SaveAndLoadData) Dbg.Log($"{nameof(LoadDataSystem)} Данные: {gameEntity.dataKey.value} загружены ");
            }
        }
    }
}