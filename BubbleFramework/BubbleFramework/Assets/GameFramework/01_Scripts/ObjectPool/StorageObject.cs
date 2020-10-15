using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Pool
{
    public  class StorageObject : MonoBehaviour
    {

        //重新激活
        protected virtual void OnPoolEnable()
        {
            gameObject.SetActive(true);
        }

        //重新隐藏
        protected virtual void OnPoolDisable()
        {
            gameObject.SetActive(false);
        }
    }
}

