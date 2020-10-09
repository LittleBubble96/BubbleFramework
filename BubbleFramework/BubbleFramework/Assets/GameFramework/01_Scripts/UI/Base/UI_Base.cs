using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bubble_UI
{
    public abstract class UI_Base: MonoBehaviour
    {

        private CanvasGroup canvasAlpha;
        //对UI的冻结和重启
        private CanvasGroup _canvasAlpha
        {
            get
            {
                if (canvasAlpha==null)
                {
                    canvasAlpha = GetComponent<CanvasGroup>();
                    if (canvasAlpha==null)
                    {
                        canvasAlpha = gameObject.AddComponent<CanvasGroup>();
                    }
                }
                return canvasAlpha;
            }
        }

        public virtual void Init()
        {
            
        }

        public virtual void SetContent(UI_BaseContent content)
        {
            
        }
        public virtual void DoUpdate(float dt)
        {

        }

        //显示
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
        //隐藏
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        //冻结
        public virtual void Freeze()
        {
            _canvasAlpha.blocksRaycasts = false;
        }
        //重启
        public virtual void ReShow()
        {
            _canvasAlpha.blocksRaycasts = true;
            gameObject.SetActive(true);
        }
    }

    public abstract class UI_Base<T> :UI_Base where T : UI_BaseContent
    {
        public T _uiBaseContent { get; set; }

        public override void SetContent(UI_BaseContent content)
        {
            _uiBaseContent = content as T;
        }
    }

    public abstract class UI_BaseContent
    {
        
    }
}

