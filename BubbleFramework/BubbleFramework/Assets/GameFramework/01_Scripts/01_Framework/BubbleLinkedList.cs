using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework
{
    public class BubbleLinkedList<T> : ICollection<T>,ICollection, IEnumerable<T>,IEnumerable
    {
        private LinkedList<T> _linkedList;
        private Queue<LinkedListNode<T>> _cachePoolQue;
         
        /// <summary>
        /// 初始化
        /// </summary>
        public BubbleLinkedList()
        {
            _linkedList = new LinkedList<T>();
            _cachePoolQue = new Queue<LinkedListNode<T>>();
        }

        private int _count => _linkedList.Count;
        private int _count1 => _linkedList.Count;
        
        /// <summary>
        /// 返回循环遍历得枚举数
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Enumerator e = new Enumerator(_linkedList);
            return e.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="item">对象得值</param>
        public void Add(T item)
        {
            AddLast(item);
        }

        /// <summary>
        /// 添加到最后一个位置
        /// </summary>
        /// <param name="item">对象得值</param>
        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> node = AcquireNode(item);
            _linkedList.AddLast(node);
            return node;
        }

        /// <summary>
        /// 添加到第一个位置
        /// </summary>
        /// <param name="item"> 对象得值 </param>
        /// <returns></returns>
        public LinkedListNode<T> AddFirst(T item)
        {
            LinkedListNode<T> node = AcquireNode(item);
            _linkedList.AddFirst(node);
            return node;
        }

        /// <summary>
        /// 添加到指定元素得后面 
        /// </summary>
        /// <param name="node">指定元素</param>
        /// <param name="item"> 需要添加得元素得值 </param>
        /// <returns></returns>
        public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T item)
        {
            LinkedListNode<T> afterNode = AcquireNode(item);
            _linkedList.AddAfter(node, afterNode);
            return afterNode;
        }

        /// <summary>
        /// 添加到指定元素得前面 
        /// </summary>
        /// <param name="node">指定元素</param>
        /// <param name="item"> 需要添加得元素得值 </param>
        /// <returns></returns>
        public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T item)
        {
            LinkedListNode<T> beforeNode = AcquireNode(item);
            _linkedList.AddBefore(node, beforeNode);
            return beforeNode;
        }

        /// <summary>
        /// 获取链表中得第一个元素
        /// </summary>
        /// <returns></returns>
        public LinkedListNode<T> First => _linkedList.First;

        /// <summary>
        /// 获取节点 对象池里有就在里面找
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private LinkedListNode<T> AcquireNode(T item)
        {
            LinkedListNode<T> node;
            if (_cachePoolQue.Count > 0)
            {
                node = _cachePoolQue.Dequeue();
                node.Value = item;
            }
            else
            {
                node = new LinkedListNode<T>(item);
            }
            return node;
        }

        /// <summary>
        /// 清楚列表缓存和 队列缓存
        /// </summary>
        public void Clear()
        {
            _linkedList.Clear();
            _cachePoolQue.Clear();
        }

        /// <summary>
        /// 获取链表里是否存在这个值
        /// </summary>
        /// <param name="item">需要查询得值</param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return _linkedList.Contains(item);
        }

        /// <summary>
        /// 索引开始 将链表里得值复制到数组中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _linkedList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 根据指定值搜索节点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LinkedListNode<T> Find(T value)
        {
            return _linkedList.Find(value);
        }

        /// <summary>
        /// 释放节点 缓存
        /// </summary>
        /// <param name="node"></param>
        public void ReleaseNode(LinkedListNode<T> node)
        {
            node.Value = default(T);
            _cachePoolQue.Enqueue(node);
        }

        /// <summary>
        /// 移除指定数据节点
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            LinkedListNode<T> node = Find(item);
            if (node!=null)
            {
                ReleaseNode(node);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 索引开始 将链表里得值复制到数组中
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            ((ICollection) _linkedList).CopyTo(array, index);
        }

        /// <summary>
        /// 元素数量
        /// </summary>
        int ICollection.Count => _count1;

        public bool IsSynchronized => ((ICollection) _linkedList).IsSynchronized;
        public object SyncRoot => ((ICollection) _linkedList).SyncRoot;

        /// <summary>
        /// 元素数量
        /// </summary>
        int ICollection<T>.Count => _count;

        /// <summary>
        /// 获取一个值 该值是否只可读
        /// </summary>
        public bool IsReadOnly => ((ICollection<T>) _linkedList).IsReadOnly;
        
        /// <summary>
        /// 迭代器
        /// </summary>
        public struct Enumerator : IEnumerable<T> , IEnumerator
        {
            private LinkedList<T>.Enumerator m_Enumerator;

            public Enumerator(LinkedList<T> linkedList)
            {
                if (linkedList==null)
                {
                    DDebug.Log($"{(LinkedList<T>) null} is invalid");
                    return;
                }
                m_Enumerator = linkedList.GetEnumerator();
            }


            public IEnumerator<T> GetEnumerator()
            {
                return m_Enumerator;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public bool MoveNext()
            {
                return m_Enumerator.MoveNext();
            }

            void IEnumerator.Reset()
            {
                ((IEnumerator<T>)m_Enumerator).Reset();
            }

            public object Current => m_Enumerator.Current;

            public void Dispose()
            {
                m_Enumerator.Dispose();
            }

        }
   
    }
}

