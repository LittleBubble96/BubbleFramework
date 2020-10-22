using System.Collections;
using System.Collections.Generic;
using BubbleFramework;
using BubbleFramework.Pool;
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
