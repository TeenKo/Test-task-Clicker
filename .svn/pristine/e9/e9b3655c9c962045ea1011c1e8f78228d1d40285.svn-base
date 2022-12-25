using Core.UI;
using Entitas;

namespace UI
{
    public class UIRootSchemaInitializeSystem : IInitializeSystem
    {
        private readonly UiContext _uiContext;

        public UIRootSchemaInitializeSystem(UiContext uiContext)
        {
            _uiContext = uiContext;
            var uiRootSchema = UnityEngine.Object.FindObjectOfType<UIRootSchema>();
            if (uiRootSchema != null) _uiContext.SetUIRootSchema(uiRootSchema);
        }

        public void Initialize()
        {
            if (_uiContext.hasUIRootSchema == false)
            {
                Dbg.Log("<color=#D00000>UiRootSchema not found on scene</color>");
                return;
            }

            var uiSchema = _uiContext.uIRootSchema.value;

            InitScreens(ref uiSchema);
            InitElements(ref uiSchema);
        }

        private void InitScreens(ref UIRootSchema uiRootSchema)
        {
            foreach (var screen in uiRootSchema.UIScreens)
            {
                var screenEntity = _uiContext.CreateEntity();
                screen.Init(screenEntity);
            }
        }

        private void InitElements(ref UIRootSchema uiRootSchema)
        {
            foreach (var element in uiRootSchema.UIElements)
            {
                var elementElement = _uiContext.CreateEntity();
                element.Init(elementElement);
            }
        }
    }
}