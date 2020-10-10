
using UnityEngine;

public class BubDebug 
{
    public static void Log(object content,string color16="0000ff")
    {
        Debug.Log(string.Format("<color=#{1}> {0} </color>", content, color16));
    }
}
