using UnityEditor;
using UnityEngine;

namespace Adapters.InAppPurchase.Editor
{
    [CustomEditor(typeof(UnityInAppPurchasesConfig))]
    public sealed class UnityInAppPurchasesConfigEditor : UnityEditor.Editor
    {
        private UnityInAppPurchasesConfig _config;

        private void OnEnable()
        {
            if (!_config) _config = (UnityInAppPurchasesConfig) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUILayout.Space(15);

            if (_config.IsEmpty() == false)
            {
                using (new GUILayout.VerticalScope("Box"))
                {
                    foreach (var item in _config.ProductCatalogItems)
                    {
                        using (new GUILayout.HorizontalScope("Box"))
                        {
                            GUILayout.Label($"{item.ID}");
                            GUILayout.Label($"{item.Purchased}");
                        }
                    }
                }
            }

            GUILayout.Space(10);

            if (GUILayout.Button("Reset purchased products"))
            {
                foreach (var item in _config.productCatalogItems)
                    item.Purchased = false;
            }
        }
    }
}