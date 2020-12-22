using System;
using System.Collections;
using System.Collections.Generic;
using BubbleFramework;
using BubbleFramework.Pool;
using GameFramework._01_Scripts._03_Setting;
using UnityEngine;

public class Example02 : MonoBehaviour
{
    private List<MonsterData> _monsterData;
    void Start()
    {
        _monsterData = BubbleFrameEntry.GetModel<GameModelManager>().GetMonsterDatas;
        
        foreach (var t in _monsterData)
        {
            DDebug.Log(t.ToString());
        }

       
        
    }

  
}
