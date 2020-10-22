using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubStateController : IStateController
{
    public IState CurState { get; set; }

    private List<IState> _states;
    public List<IState> States
    {
        get => _states ?? (_states = new List<IState>());
        set => _states = value;
    }

    
    public void AddState(IState state)
    {
        //如果当前状态为空 就进入初始状态
        if (CurState==null)
        {
            CurState = state;
            CurState.OnEnter?.Invoke();
        }

        if (!States.Contains(state))
        {
            States.Add(state);
        }
    }

    public void OnUpdate(float dt)
    {
        foreach (var translation in CurState.Translations)
        {
            //检测当前状态的所有可转化路径 成立就状态切换
            if (translation.OnCondition())
            {
                CurState.OnExit?.Invoke();
                CurState = translation.To;
                CurState.OnEnter?.Invoke();
            }
        }

        CurState.OnUpdate?.Invoke(dt);
    }

    //创建一个实例
    public static BubStateController CreateInstance()
    {
        return new BubStateController();
    }

}
