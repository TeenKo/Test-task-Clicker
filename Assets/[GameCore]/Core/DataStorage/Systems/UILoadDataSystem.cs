using System.Collections.Generic;
using Entitas;
using Newtonsoft.Json;
using UnityEngine;


namespace Core.DataStorage
{
    public class UILoadDataSystem : ReactiveSystem<UiEntity>
    {
        private readonly DebugLogConfig _debugLogConfig;

        public UILoadDataSystem(UiContext uiContext, DebugLogConfig debugLogConfig) : base(uiContext)
        {
            _debugLogConfig = debugLogConfig;
        }

        protected override ICollector<UiEntity> GetTrigger(IContext<UiEntity> context)
        {
            return context.CreateCollector(UiMatcher.UILoadData);
        }

        protected override bool Filter(UiEntity entity)
        {
            return entity.hasUIDataKey;
        }

        protected override void Execute(List<UiEntity> entities)
        {
            foreach (var uiEntity in entities)
            {
                var jsonDataString = PlayerPrefs.GetString(uiEntity.uIDataKey.value, string.Empty);

                if (string.IsNullOrEmpty(jsonDataString))
                {
                    if (_debugLogConfig.SaveAndLoadData) Dbg.Log($"{nameof(LoadDataSystem)} файл с данными не найден");
                    uiEntity.systemTriggerUILoadingDataFailed = true;
                    continue;
                }

                var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonDataString);

                foreach (var item in dictionary)
                {
                    for (var i = 0; i < UiComponentsLookup.componentNames.Length; i++)
                    {
                        if (item.Key != UiComponentsLookup.componentTypes[i].ToString()) continue;

                        var savableDataComponent =
                            System.Activator.CreateInstance(UiComponentsLookup.componentTypes[i]);
                        var activator = savableDataComponent as IComponent;
                        var savableData = savableDataComponent as ISavableData;

                        uiEntity.ReplaceComponent(i, activator);
                        savableData?.SetValue(item.Value);
                    }
                }

                uiEntity.systemTriggerUILoadingDataSuccessful = true;

                if (_debugLogConfig.SaveAndLoadData) Dbg.Log($"{nameof(LoadDataSystem)} Данные: {uiEntity.uIDataKey.value} загружены ");
            }
        }
    }
}