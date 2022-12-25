using System.Collections.Generic;
using UnityEngine;

namespace Core.UI
{
    [DisallowMultipleComponent]
    public sealed class UIRootSchema : MonoBehaviour
    {
        [SerializeField] private UIScreen[] uiScreens;
        [SerializeField] private UIElement[] uiElements;

        public IEnumerable<UIScreen> UIScreens => uiScreens;
        public IEnumerable<UIElement> UIElements => uiElements;
    }
}