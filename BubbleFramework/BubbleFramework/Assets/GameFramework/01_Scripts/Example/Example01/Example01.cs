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
            BubbleFrameEntry.GetModel<UI_Manager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                BubbleFrameEntry.GetModel<UI_Manager>().Show(UI_Name.UI_TEST_01,new Test_01Content("这是显示的第一个UI"));
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                BubbleFrameEntry.GetModel<UI_Manager>().Hide(UI_Name.UI_TEST_01);
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                BubbleFrameEntry.GetModel<UI_Manager>().Show(UI_Name.UI_TEST_02,new Test_02Content("这是显示的第一个UI"));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                BubbleFrameEntry.GetModel<UI_Manager>().Hide(UI_Name.UI_TEST_02);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                BubbleFrameEntry.GetModel<UI_Manager>().HideView(UIType.Normal);
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                BubbleFrameEntry.GetModel<AppEventDispatcher>().BroadcastListener(EventName.EVENT_TEST01,"广播第一次");
            }
        }
    }
}

