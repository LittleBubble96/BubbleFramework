using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubTranslation : ITranslation
{
    public IState From { get; set; }
    public IState To { get; set; }
    
    public DoCondition Condition { get; set; }

    public BubTranslation(IState from,IState to,DoCondition condition)
    {
        this.From = from;
        this.To = to;
        this.Condition = condition;
        
        from.AddStateTranslation(this);
    }

    public bool OnCondition()
    {
        if (Condition!=null)
        {
            return Condition();
        }
        return true;
    }
}
