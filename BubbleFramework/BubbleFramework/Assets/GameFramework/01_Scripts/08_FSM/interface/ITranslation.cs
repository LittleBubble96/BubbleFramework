using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate bool DoCondition();
public interface ITranslation
{
    IState From { get; set; }

    IState To { get; set; }

    DoCondition Condition { get; set; }

    //转换条件
    bool OnCondition();
}
