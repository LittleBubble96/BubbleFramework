using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework.Bubble_UI
{
    public enum UIType
    {
        None,
        Normal,//普通UI
        Fixed,//固定UI
        Dialog,//弹窗UI
    }

    public abstract class UI_Base: MonoBehaviour
    {

        private CanvasGroup _canvasAlpha;
        //对UI的冻结和重启
        private CanvasGroup CanvasAlpha
        {
            get
            {
                if (_canvasAlpha==null)
                {
                    _canvasAlpha = GetComponent<CanvasGroup>();
                    if (_canvasAlpha==null)
                    {
                        _canvasAlpha = gameObject.AddComponent<CanvasGroup>();
                    }
                }
                return _canvasAlpha;
            }
        }

        public UIType UiType { get; set; }

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
            CanvasAlpha.blocksRaycasts = false;
        }
        //重启
        public virtual void ReShow()
        {
            CanvasAlpha.blocksRaycasts = true;
            gameObject.SetActive(true);
        }
    }

    public abstract class UI_Base<T> :UI_Base where T : UI_BaseContent
    {
        protected T UiBaseContent { get; set; }

        public override void SetContent(UI_BaseContent content)
        {
            UiBaseContent = content as T;
        }
    }

    public abstract class UI_BaseContent
    {
        
    }
}

