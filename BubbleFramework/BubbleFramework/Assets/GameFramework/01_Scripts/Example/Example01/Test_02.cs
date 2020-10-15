using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_UI;
using UnityEngine;
using UnityEngine.UI;

public class Test_02 : UI_Base<Test_02Content>
{
    public Text _des;

    public override void Init()
    {
        base.Init();
        UiType = UIType.Fixed;
    }

    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
    }
    
}

public class Test_02Content :UI_BaseContent
{
    public string des { get; set; }

    public Test_02Content(string d)
    {
        des = d;
    }
}
