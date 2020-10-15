using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BubbleFramework.Pool
{
    public class PoolManager<T> : IDisposable where T :StorageObject
    {
        //是否销毁
        private bool isDisposed;
        
        //对应得对象池
        private Dictionary<string,Queue<Element>> _objectPool; 
        
        public PoolManager()
        {
            _objectPool=new Dictionary<string, Queue<Element>>(); 
        }

        ~PoolManager()
        {
            Dispose(false);
        }

        //单例
        private static PoolManager<T> _instance;
        public static PoolManager<T> Instance => _instance ?? (_instance = new PoolManager<T>());

        #region 接口

        //获取元素
        public T TakeOutObject(T storageObject)
        {
            string type = typeof(T).Name;
            DDebug.Log("类型："+ type);

            T item;
            if (_objectPool.TryGetValue(type,out var elementQue) && elementQue.Count>0)
            {
                item = elementQue.Dequeue().value;
            }
            else
            {
                item = Object.Instantiate(storageObject);
            }
            return item;
        }

        //存入物体
        public void TakeInObject(T storageObject)
        {
            string type = typeof(T).Name;

            if (!_objectPool.TryGetValue(type,out var elementQue))
            {
               _objectPool[type]=new Queue<Element>();
            }
            _objectPool[type].Enqueue(new Element(storageObject));
        }

        #endregion
        
        private struct Element
        {
            internal T value;

            public Element(T value)
            {
                this.value = value;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                //释放
                _objectPool.Clear();
            }

            isDisposed = true;
        }
    }

}
