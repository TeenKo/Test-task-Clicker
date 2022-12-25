using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

namespace EditorInstantFunctions
{
    public static class ScreenShooter
    {
        private const string FileExtension = "png";
        private const string Pattern = @"\d{2}";
        private const RegexOptions Options = RegexOptions.IgnoreCase;
        private static string _screenShotsPath;

        [MenuItem("JB tools/Screenshot #s", false)]
        private static void Action()
        {
            _screenShotsPath = Application.dataPath.Replace("Assets", "ScreenShots");

            if (Directory.Exists(_screenShotsPath) == false) Directory.CreateDirectory(_screenShotsPath);

            var screenShotName = CloudProjectSettings.projectName;
            var directoryInfo = new DirectoryInfo(_screenShotsPath);

            var files = directoryInfo.GetFiles();
            var count = 0;
            foreach (var fileInfo in files)
            {
                var matchCollection = Regex.Matches(fileInfo.Name, Pattern, Options);
                foreach (Match match in matchCollection)
                {
                    try
                    {
                        var value = int.Parse(match.Value);
                        if (value >= count) count = value + 1;
                    }
                    catch (FormatException)
                    {
                    }
                }
            }

            var fileName = $"{screenShotName}-{count:00}.{FileExtension}";
            ScreenCapture.CaptureScreenshot($"{_screenShotsPath}/{fileName}");
            Debug.Log($"<b><color=#3A86FF>ScreenShot {fileName} saved!</color></b>");
        }
    }
}