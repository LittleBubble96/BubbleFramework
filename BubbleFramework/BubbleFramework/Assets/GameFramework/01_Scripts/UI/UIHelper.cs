using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Bubble_UI
{
    //UI帮助类
    public static class UIHelper
    {
        //扩展 transform 获取 RectTransform
        public static RectTransform rectTransfrom(this Transform tf)
        {
            return tf.GetComponent<RectTransform>();
        }

        //扩展 transform 获取子物体对应的组件
        public static T GetChildrenComponentByNode<T>(this Transform tf,string childName)
        {
            T script = tf.GetComponentByNode<T>(childName);
            if (script==null)
            {
                DDebug.Log("下面所有子物体没有找到对应的名字上有脚本 ，请核对子物体名字："+childName+" ,和这个组件："+typeof(T)+" 是否存在");
            }
            return script;
        }

        static T GetComponentByNode<T>(this Transform tf, string childName)
        {
            for (int i = 0; i < tf.childCount; i++)
            {
                Transform tfChild = tf.GetChild(i);
                if (tfChild.name==childName)
                {
                    return tfChild.GetComponent<T>();
                }
                else
                {
                    T component = tfChild.GetComponentByNode<T>(childName);
                    if (component!=null)
                    {
                        return component;
                    }
                }
            }
            return default(T);
        }
    }
}
