
using System;
using System.ComponentModel;
using System.Reflection;
using UnityEditor;
using UnityEngine.Internal;
using Debug = UnityEngine.Debug;

public enum LogColor
{
    red,
    green,
    blue,
    yellow,
    black,
    white,
}

public class DDebug
{
    //是否启用debug
    public static bool Enable =true;

    //颜色打印
    public static void Log(object message,LogColor color=LogColor.blue)
    {
        if (Enable)
        {
            Debug.Log(string.Format("<color={1}> {0} </color>", message, color.ToString()));
        }
    }
    
    public static void Log(object message,UnityEngine.Object context,LogColor color=LogColor.blue)
    {
        if (Enable)
        {
            Debug.Log(string.Format("<color={1}> {0} </color>", message, context,color.ToString()));
        }
    }

    public static void LogWarning(object message)
    {
        if (Enable)
            Debug.LogWarning(message);
    }
    public static void LogWarning(object message, UnityEngine.Object context)
    {
        if (Enable)
            Debug.LogWarning(message, context);
    }
 
    public static void LogError(object message)
    {
        if (Enable)
            Debug.LogError(message);
    }
    public static void LogError(object message, UnityEngine.Object context)
    {
        if (Enable)
            Debug.LogError(message, context);
    }


    //暂停
    public static void Break()
    {
        Debug.Break();
    }
    
    //清空控制台
    public static void Clear()
    {
        Assembly assembly =Assembly.GetAssembly(typeof(SceneView));
        Type logEntries = assembly.GetType("UnityEditor.LogEntries");
        MethodInfo methodInfo = logEntries.GetMethod("Clear");
        if (methodInfo != null) methodInfo.Invoke(new object(), null);
    }

}

