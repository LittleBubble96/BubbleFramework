using System.Collections;
using System.Collections.Generic;
using Bubble_UI;
using UnityEngine;
using UnityEngine.UI;

public class Test_01 : UI_Base<Test_01Content>
{
    public Text _des;

    public override void SetContent(UI_BaseContent content)
    {
        base.SetContent(content);
        _des.text = _uiBaseContent.des;
        
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
