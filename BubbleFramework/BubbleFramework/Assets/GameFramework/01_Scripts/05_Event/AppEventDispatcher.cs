using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Bubble_Event
{
    public class AppEventDispatcher : BubbleFrameModel , IDisposable
    {
        /// <summary>
        /// 轮序为0 最先调用
        /// </summary>
        internal override int Priority => 0;

        //是都已经被释放
        private bool disposed;

        private Dictionary<string, Delegate> _listensDic;

        public AppEventDispatcher()
        {
            _listensDic=new Dictionary<string, Delegate>();
        }

        //程序结束
        ~AppEventDispatcher()
        {
            Dispose(false);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //释放资源
                _listensDic.Clear();
            }

            disposed = true;
        }

        /// <summary>
        /// 添加事件 
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="listener">事件</param>
        /// <typeparam name="TEvent"></typeparam>
        public void AddEventListener<TEvent>(string eventType, Action<TEvent> listener) where TEvent : EventType
        {
            if (string.IsNullOrEmpty(eventType))
            {
                return;
            }

            if (_listensDic.TryGetValue(eventType,out _))
            {
                _listensDic[eventType] = Delegate.Combine(listener);
            }
            else
            {
                _listensDic[eventType] = listener;
            }
        }
        
        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="listener">事件监听</param>
        /// <typeparam name="TEvent"></typeparam>
        public void RemoveEventListener<TEvent>(string eventType,Action<TEvent> listener) where  TEvent :EventType
        {
            if (string.IsNullOrEmpty(eventType))
            {
                return;
            }
            
            if (_listensDic.TryGetValue(eventType,out _))
            {
                _listensDic[eventType] = Delegate.Remove(_listensDic[eventType], listener);
            }
        }
        
        /// <summary>
        /// 广播事件
        /// </summary>
        /// <param name="evt">事件类型 </param>
        /// <typeparam name="TEvent"></typeparam>
        private void BroadcastListener<TEvent>(TEvent evt) where TEvent : EventType
        {
            string type = evt.Type;
            if (string.IsNullOrEmpty(type))
            {
                return;
            }

            if (_listensDic.TryGetValue(type,out _))
            {
                Action<TEvent> onEvt = _listensDic[type] as Action<TEvent>;
                onEvt?.Invoke(evt);
            }
        }

        /// <summary>
        /// 广播事件 无参数
        /// </summary>
        /// <param name="eventType">事件类型</param>
        public void BroadcastListener(string eventType)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new EventType(eventType));
            }
        }

        /// <summary>
        /// 广播事件 带一个参数
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="value">第一个参数 </param>
        /// <typeparam name="T"></typeparam>
        public void BroadcastListener<T>(string eventType, T value)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new MultiEvent<T>(eventType,value));
            }
        }
        
        /// <summary>
        /// 广播事件 带俩个参数
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="value">第一个参数 </param>
        /// <param name="value1">第二个参数 </param>
        /// <typeparam name="T"></typeparam>
        public void BroadcastListener<T,T1>(string eventType, T value,T1 value1)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new MultiEvent<T,T1>(eventType,value,value1));
            }
        }
        
        /// <summary>
        /// 广播事件 带三个参数
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="value">第一个参数</param>
        /// <param name="value1">第二个参数</param>
        /// <param name="value2">第三个参数</param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        public void BroadcastListener<T,T1,T2>(string eventType, T value,T1 value1,T2 value2)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new MultiEvent<T,T1,T2>(eventType,value,value1,value2));
            }
        }
    }
}

