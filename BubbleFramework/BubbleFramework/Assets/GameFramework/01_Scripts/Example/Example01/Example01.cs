using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_Event;
using UnityEngine;
using EventType = BubbleFramework.Bubble_Event.EventType;

namespace BubbleFramework.Bubble_UI.Example01
{
    public class Example01 : MonoBehaviour
    {
        // Start is called before the first frame update
        Dictionary<string,int> test=new Dictionary<string, int>();
        void Awake()
        {
            UI_Manager.Instance.Init();
        }

        // Update is called once per frame
        void Update()
        {
            UI_Manager.Instance.DoUpdate(Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.A))
            {
                UI_Manager.Instance.Show(UI_Name.UI_TEST_01,new Test_01Content("这是显示的第一个UI"));
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                UI_Manager.Instance.Hide(UI_Name.UI_TEST_01);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                UI_Manager.Instance.Show(UI_Name.UI_TEST_02,new Test_02Content("这是显示的第一个UI"));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                UI_Manager.Instance.Hide(UI_Name.UI_TEST_02);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                UI_Manager.Instance.HideView(UIType.Normal);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                Reg.EventDispatcher.BroadcastListener(EventName.EVENT_TEST01,"广播第一次");
            }
        }
    }
}

