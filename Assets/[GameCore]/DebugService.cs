using UnityEngine;

/// <summary>
/// Простой сервис дебаг консоли
/// </summary>
public static class Dbg
{
    public static void Log(string message, Color style)
    {
        Debug.Log($"<color=#{ColorUtility.ToHtmlStringRGB(style)}>{message}</color>");
    }

    public static void LogWarning(string message, Color style)
    {
        Debug.LogWarning($"<color=#{ColorUtility.ToHtmlStringRGB(style)}>{message}</color>");
    }

    public static void LogError(string message, Color style)
    {
        Debug.LogError($"<color=#{ColorUtility.ToHtmlStringRGB(style)}>{message}</color>");
    }


    public static void Log(string message)
    {
        Log(message, Color.white);
    }

    public static void LogYellow(string message)
    {
        Log(message, Color.yellow);
    }

    public static void LogGreen(string message)
    {
        Log(message, Color.green);
    }

    public static void LogCyan(string message)
    {
        Log(message, Color.cyan);
    }

    public static void LogMagenta(string message)
    {
        Log(message, Color.magenta);
    }

    public static void LogWarning(string message)
    {
        LogWarning(message, Color.yellow);
    }

    public static void LogError(string message)
    {
        LogError(message, Color.red);
    }
}