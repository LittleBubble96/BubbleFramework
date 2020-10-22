using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Pool
{
    public  class StorageObject : MonoBehaviour
    {

        //重新激活
        public virtual void OnPoolEnable()
        {
            gameObject.SetActive(true);
        }

        //重新隐藏
        public virtual void OnPoolDisable()
        {
            gameObject.SetActive(false);
        }
    }
}

