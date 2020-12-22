
using System;
using System.Collections.Generic;
using System.Threading;
using BubbleFramework;
using UnityEngine;
using Object = System.Object;

/// <summary>
/// 模块入口
/// 1.UI模块           UI_Manager
/// 2.事件模块         AppEventDispatcher
/// 3.CSV数据管理模块   GameModelManager
/// 4.对象池模块        PoolManager
/// 5.语言国际化        LanguageMgr
/// </summary>
public static class BubbleFrameEntry
{
    private static readonly BubbleLinkedList<BubbleFrameModel> GameModels = new BubbleLinkedList<BubbleFrameModel>();

    private static List<ModelInstance> _entries = new List<ModelInstance>();
    
    /// <summary>
    /// 模块初始化
    /// </summary>
    public static void Awake()
    {
        //_entries = new List<ModelInstance>();
    }

    public static void Update(float dt)
    {
        foreach (var model in GameModels)
        {
            model.DoUpdate(dt);
        }
    }

    /// <summary>
    /// 获取模块
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetModel<T>() where T : BubbleFrameModel
    {
        Type type = typeof(T);
        
        if (type.IsAbstract)
        {
            throw new GameException($"{type} is invalid");
        }

        foreach (var model in GameModels)
        {
            if (model.GetType()==type)
            {
                return model as T;
            }
        }
        return CreateModel(type) as T;
    }

    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static BubbleFrameModel CreateModel(Type type)
    {
        ModelInstance idleInstance = null;
        foreach (var entry in _entries)
        {
            if (entry.Idle)
            {
                idleInstance = entry;
            }
        }

        if (idleInstance==null)
        {
            idleInstance = new ModelInstance();
            _entries.Add(idleInstance);
        }
        return idleInstance.CreateModelByType(type);
    }
    
    
    private class ModelInstance
    {
        public bool Idle;

        public ModelInstance()
        {
            Idle = false;
        }

        public BubbleFrameModel CreateModelByType(Type type)
        {
            BubbleFrameModel instance = (BubbleFrameModel) Activator.CreateInstance(type);
            LinkedListNode<BubbleFrameModel> current = GameModels.First;
            LinkedListNode<BubbleFrameModel> beforeNode = null;
        
            while (current!=null)
            {
                if (current.Value.Priority > instance.Priority)
                {
                    beforeNode = current;
                    break;
                }
                current = current.Next;
            }

            if (beforeNode!=null)
            {
                GameModels.AddBefore(beforeNode, instance);
            }
            else
            {
                GameModels.AddLast(instance);
            }

            Idle = true;
            return instance;
        }
    }
}
