using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Bubble_Event
{
    public class AppEventDispatcher : IDisposable
    {
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    
    
        public void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //释放资源
            }

            disposed = true;
        }

        //添加事件
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
        
        //移除事件
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
        
        //广播事件
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

        public void BroadcastListener(string eventType)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new EventType(eventType));
            }
        }

        public void BroadcastListener<T>(string eventType, T value)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new MultiEvent<T>(eventType,value));
            }
        }
        
        public void BroadcastListener<T,T1>(string eventType, T value,T1 value1)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new MultiEvent<T,T1>(eventType,value,value1));
            }
        }
        
        public void BroadcastListener<T,T1,T2>(string eventType, T value,T1 value1,T2 value2)
        {
            if (!string.IsNullOrEmpty(eventType)&&_listensDic.ContainsKey(eventType))
            {
                BroadcastListener(new MultiEvent<T,T1,T2>(eventType,value,value1,value2));
            }
        }
    }
}

