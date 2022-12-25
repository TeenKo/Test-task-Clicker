using UnityEditor;
using UnityEngine;

namespace EditorInstantFunctions
{
    public static class ClearSavedData
    {
        [MenuItem("JB tools/Clear Saved Data #r", false)]
        private static void Action(MenuCommand menuCommand)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("<b><color=#FF6F91>PlayerPrefs was deleted</color></b>");
        }
    }
}