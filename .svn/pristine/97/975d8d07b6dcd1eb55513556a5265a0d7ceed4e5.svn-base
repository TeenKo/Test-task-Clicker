using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Object = UnityEngine.Object;

namespace EditorWindowedFunctions
{
    public sealed class Colorant : EditorWindow
    {
        private const string MaterialsDirectory = "Assets/[GameDesign]/Graphics/Materials/Generated";
        private static string _input = "https://coolors.co/ff595e-ffca3a-8ac926-1982c4-6a4c93";
        private const string Pattern = @"([A-F]|[0-9]){6}";
        private const RegexOptions Options = RegexOptions.IgnoreCase;

        private const string HyperLink =
            "https://coolors.co/001219-005f73-0a9396-94d2bd-e9d8a6-ee9b00-ca6702-bb3e03-ae2012-9b2226";

        private static Color[] _parseColors;
        private static string _materialName;
        private static Texture2D _headerTexture;
        private static Shader _shader;


        [MenuItem("JB tools/Colorant")]
        private static void ShowWindow()
        {
            var window = GetWindow<Colorant>();
            window.titleContent = new GUIContent("Colorant");
            window.Show();

            var currentResolution = Screen.currentResolution;
            var size = Vector2.one * 512;
            var position = (new Vector2(currentResolution.width, currentResolution.height) - size) / 2;
            window.position = new Rect(position, size);

            CreateStyles();

            OnOpenWindow();

            ParseInputStringToColors();
        }

        #region styles

        private static GUIStyle _buttonLinkStyle = new GUIStyle();

        private static void CreateStyles()
        {
            _buttonLinkStyle = new GUIStyle
            {
                normal =
                {
                    textColor = new Color(0.2f, 0.6f, 0.9f, 1f)
                }
            };
        }

        #endregion

        private static void OnOpenWindow()
        {
            _headerTexture = AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/[GameCore]/EditorResources/colors.png");
            _shader = Shader.Find("Voodoo_LaunchOps/SliderRamp");
            if (_shader == null) _shader = Shader.Find("Standard");
        }

        private void OnGUI()
        {
            if (EditorApplication.isCompiling) Close();

            DrawHeaderImage(position);

            EditorGUILayout.Space(5);
            if (GUILayout.Button("   (LINK) Copy colors string from browser address field: coolors.co", _buttonLinkStyle))
            {
                Application.OpenURL(HyperLink);
            }

            EditorGUILayout.Space(10);
            _input = EditorGUILayout.TextField(_input);
            if (string.IsNullOrEmpty(_input) == false && GUILayout.Button("Create a color palette"))
                ParseInputStringToColors();

            DrawParsedColors();
            if (GUILayout.Button("Reset")) _parseColors = null;

            if (_parseColors != null && _parseColors.Length > 0)
            {
                EditorGUILayout.Space(10);
                _shader = EditorGUILayout.ObjectField(_shader, typeof(Shader), false) as Shader;
                if (_shader)
                {
                    if (_shader.FindPropertyIndex("_Color") >= 0)
                    {
                        if (CreateMaterials())
                        {
                            if (EditorUtility.DisplayDialog("Complete!",
                                    $"Materials was successfully created at folder {MaterialsDirectory}!", "Ok"))
                            {
                                Close();
                                var obj = AssetDatabase.LoadAssetAtPath(MaterialsDirectory, typeof(Object));
                                var selection = new Object[1];
                                selection[0] = obj;
                                Selection.objects = selection;
                            }
                        }
                    }
                    else
                    {
                        EditorGUILayout.HelpBox($"Shader {_shader.name} does not contain _Color property!", MessageType.Error);
                    }
                }
            }

            if (GUILayout.Button("Delete generated materials"))
            {
                if (Directory.Exists(MaterialsDirectory))
                {
                    if (EditorUtility.DisplayDialog("WARNING!",
                            $"This action DELETE all files in folder {MaterialsDirectory}!",
                            "Yes, remove it!", "No way!"))
                    {
                        var directoryInfo = new DirectoryInfo(MaterialsDirectory);
                        foreach (var file in directoryInfo.GetFiles())
                        {
                            file.Delete();
                        }

                        foreach (var dir in directoryInfo.GetDirectories())
                        {
                            dir.Delete(true);
                        }

                        AssetDatabase.Refresh();
                    }
                }
            }
        }

        private static void DrawHeaderImage(Rect position)
        {
            var headerWidth = position.width;
            var aspectRatio = _headerTexture.height / (float) _headerTexture.width;
            GUILayout.BeginScrollView(Vector2.zero, false, false, GUILayout.Width(headerWidth),
                GUILayout.Height(headerWidth * aspectRatio));
            var texRect = new Rect(0f, 0f, headerWidth, headerWidth * aspectRatio);

            GUILayout.FlexibleSpace();
            GUILayout.BeginArea(texRect);
            GUI.DrawTexture(texRect, _headerTexture, ScaleMode.ScaleToFit);
            GUILayout.EndArea();
            GUILayout.FlexibleSpace();
            GUILayout.EndScrollView();
        }

        private static void ParseInputStringToColors()
        {
            var matchCollection = Regex.Matches(_input, Pattern, Options);
            _parseColors = new Color[matchCollection.Count];
            var index = 0;
            foreach (Match match in matchCollection)
            {
                if (ColorUtility.TryParseHtmlString($"#{match.Value}", out var color))
                {
                    _parseColors[index++] = color;
                }
                else
                {
                    Debug.Log($"<color=#F94144>Value {match.Value} cannot be parsed to color!</color>");
                }
            }
        }

        private static Vector2 scrollViewPosition = Vector2.zero;

        private static void DrawParsedColors()
        {
            if (_parseColors == null || _parseColors.Length <= 0) return;

            using (var scrollViewScope = new GUILayout.ScrollViewScope(scrollViewPosition))
            {
                scrollViewPosition = scrollViewScope.scrollPosition;
                foreach (var color in _parseColors)
                {
                    using (new GUILayout.HorizontalScope())
                    {
                        EditorGUILayout.ColorField(color);
                        EditorGUILayout.LabelField(ColorUtility.ToHtmlStringRGB(color));
                    }
                }
            }
        }

        private static bool CreateMaterials()
        {
            if (GUILayout.Button("Create materials") == false) return false;
            if (Directory.Exists(MaterialsDirectory) == false) Directory.CreateDirectory(MaterialsDirectory);
            foreach (var color in _parseColors)
            {
                _materialName = $"{_shader.name}-{ColorUtility.ToHtmlStringRGB(color)}";
                _materialName = _materialName.Replace('/', '-');
                var materialPath = $"{MaterialsDirectory}/{_materialName}.mat";
                var exists = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
                if (exists)
                {
                    exists.SetColor("_Color", color);
                }
                else
                {
                    var material = new Material(_shader);
                    material.SetColor("_Color", color);
                    AssetDatabase.CreateAsset(material, materialPath);
                }
            }

            AssetDatabase.Refresh();
            return true;
        }
    }
}