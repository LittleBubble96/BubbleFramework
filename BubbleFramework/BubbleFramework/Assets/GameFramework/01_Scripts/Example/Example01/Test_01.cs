using System;
using System.Collections;
using System.Collections.Generic;
using BubbleFramework;
using BubbleFramework.Bubble_Event;
using BubbleFramework.Bubble_UI;
using UnityEngine;
using UnityEngine.UI;
using EventType = BubbleFramework.Bubble_Event.EventType;

public class Test_01 : UI_Base<Test_01Content>
{
    [Bubble_Name("描述",Describe = "这个是描述")]
    public Text _des;
    
    public override void Init()
    {
        base.Init();
        UiType = UIType.Normal;
        BubbleFrameEntry.GetModel<AppEventDispatcher>().AddEventListener<EventType>(EventName.EVENT_TEST01,OnChangeDes);
    }

    private void OnChangeDes(EventType obj)
    {
        if (obj is MultiEvent<string> item) 
            _des.text = item.Value;
    }


    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
        _des.text = UiBaseContent.des;
    }

    private void OnDestroy()
    {
        BubbleFrameEntry.GetModel<AppEventDispatcher>().RemoveEventListener<EventType>(EventName.EVENT_TEST01,OnChangeDes);
    }
}

public class Test_01Content :UI_BaseContent
{
    public string des { get; set; }

    public Test_01Content(string d)
    {
        des = d;
    }
}
