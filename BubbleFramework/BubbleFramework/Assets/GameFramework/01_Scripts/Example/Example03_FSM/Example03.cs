using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example03 : MonoBehaviour
{
    //先定义一个控制器
    private BubStateController _controller;
    private void Awake()
    {
        _controller = BubStateController.CreateInstance();

        BubState idleState = new BubState("休闲", OnIdleEnter, OnIdleUpdate, OnIdleExit, _controller);
        BubState attackState = new BubState("攻击", OnAttackEnter, OnAttackUpdate, OnAttackExit, _controller);

        BubTranslation idleToAttack=new BubTranslation(idleState,attackState,OnIdleToAttack);
        BubTranslation attackToIdle=new BubTranslation(attackState,idleState,OnAttackToIdle);
    }

    private void Update()
    {
        _controller.OnUpdate(Time.deltaTime);
        
    }

    #region IDle

    private void OnIdleEnter()
    {
        DDebug.Log("Idle Enter");
    }
    private void OnIdleUpdate(float dt)
    {
        DDebug.Log("Idle Update");
    }
    private void OnIdleExit()
    {
        DDebug.Log("Idle Exit");
    }

    #endregion

    #region Attack
    private void OnAttackEnter()
    {
        DDebug.Log("Attack Enter");
    }
    private void OnAttackUpdate(float dt)
    {
        DDebug.Log("Attack Update");
    }
    private void OnAttackExit()
    {
        DDebug.Log("Attack Exit");
    }
    #endregion

    #region Condition
    //idleToAttack 条件
    private bool OnIdleToAttack()
    {
        return Input.GetKeyDown(KeyCode.A);
    }

    //attackToIdle 条件
    private bool OnAttackToIdle()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }
    #endregion
}
