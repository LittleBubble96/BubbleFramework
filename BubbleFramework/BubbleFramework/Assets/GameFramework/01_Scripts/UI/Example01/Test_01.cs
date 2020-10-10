using System.Collections;
using System.Collections.Generic;
using Bubble_UI;
using UnityEngine;
using UnityEngine.UI;

public class Test_01 : UI_Base<Test_01Content>
{
    [Bubble_Name("描述",Describe = "这个是描述")]
    public Text _des;

    public override void Init()
    {
        base.Init();
        UiType = UIType.Normal;
    }

    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
        _des.text = UiBaseContent.des;
        
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
