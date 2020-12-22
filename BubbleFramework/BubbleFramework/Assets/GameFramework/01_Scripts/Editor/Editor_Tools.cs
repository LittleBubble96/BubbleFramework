using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Editor_Tools : Editor
{
    [MenuItem("Tools/清除数据")]
    public static void ClearData()
    {
        CPlayerPrefs.DeleteAll();
    }

}
