using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;
namespace BubbleFramework.Pool
{
    public class PoolManager : BubbleFrameModel , IDisposable 
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

        /// <summary>
        /// 轮序之
        /// </summary>
        internal override int Priority => 30;

        #region 接口

        /// <summary>
        /// 获取对象池得元素 有得话 就激活 没有就实例化
        /// </summary>
        /// <param name="storageObject"> 传入得物体 </param>
        /// <typeparam name="T"> </typeparam>
        /// <returns></returns>
        public T TakeOutObject<T>(T storageObject)  where T :StorageObject
        {
            string type = typeof(T).Name;
            DDebug.Log("类型："+ type);

            T item;
            if (_objectPool.TryGetValue(type,out var elementQue) && elementQue.Count>0)
            {
                item = elementQue.Dequeue().value as T;
            }
            else
            {
                item = Object.Instantiate(storageObject);
            }

            if (item!=null)
            {
                item.OnPoolEnable();
            }
            return item;
        }

        /// <summary>
        /// 将物体存入对象池中
        /// </summary>
        /// <param name="storageObject">需要存入得物体</param>
        /// <typeparam name="T"></typeparam>
        public void TakeInObject<T>(T storageObject) where T : StorageObject
        {
            string type = typeof(T).Name;

            if (!_objectPool.TryGetValue(type,out var elementQue))
            {
               _objectPool[type]=new Queue<Element>();
            }
            _objectPool[type].Enqueue(new Element(storageObject));
            storageObject.OnPoolDisable();
        }

        #endregion
        
        /// <summary>
        /// 元素构造函数 减少GC
        /// </summary>
        private struct Element
        {
            internal StorageObject value;

            public Element(StorageObject value)
            {
                this.value = value;
            }
        }

        /// <summary>
        /// 释放GC
        /// </summary>
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
