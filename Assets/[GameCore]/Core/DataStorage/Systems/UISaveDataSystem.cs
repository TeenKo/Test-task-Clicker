using System.Collections.Generic;
using Entitas;
using Newtonsoft.Json;
using UnityEngine;

namespace Core.DataStorage
{
    public class UISaveDataSystem : ReactiveSystem<UiEntity>
    {
        private readonly DebugLogConfig _debugLogConfig;

        public UISaveDataSystem(UiContext uiContext, DebugLogConfig debugLogConfig) : base(uiContext)
        {
            _debugLogConfig = debugLogConfig;
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.UISaveData.Added());
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.hasUIDataKey;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var uiEntity in entities)
            {
                var dictionary = new Dictionary<string, object>();
                var uiDataKey = uiEntity.uIDataKey.value;

                foreach (var component in uiEntity.GetComponents())
                {
                    if (!(component is ISavableData savableData)) continue;

                    dictionary.Add(savableData.ToString(), savableData.GetValue);
                }

                var result = JsonConvert.SerializeObject(dictionary);
                PlayerPrefs.SetString(uiDataKey, result);

                if (_debugLogConfig.SaveAndLoadData) Dbg.Log($"Данные: {uiDataKey} сохранены");
            }
        }
    }
}