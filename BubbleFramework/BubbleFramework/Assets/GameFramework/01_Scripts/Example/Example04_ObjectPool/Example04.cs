using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Pool;
using UnityEngine;

public class Example04 : MonoBehaviour
{
    [Bubble_Name("测试需要存入对象池得物体")]
    public CubeObject cube;
    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BubbleFrameEntry.GetModel<PoolManager>().TakeInObject(cube);
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            BubbleFrameEntry.GetModel<PoolManager>().TakeOutObject(cube);
        }
    }
}
