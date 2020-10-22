using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BubbleFramework.Bubble_UI
{
    public class UI_Manager : BubbleFrameModel
    {
        //ui相机
        public Camera _uiCamera { get; set; }
        //UIRoot
        public Transform _uiRoot { get; set; }

        internal override int Priority => 10;

        //当前显示的UI
        private Stack<UI_Base> _uiCurrentBases = new Stack<UI_Base>();
        //当前缓存的UI
        private Dictionary<string,UI_Base> _uiTempBases = new Dictionary<string, UI_Base>();
        //当前显示的UI名字
        private Stack<string> _uiCurrentNames = new Stack<string>();
        //UI路径
        private const string UIPrefab_Path = "UIPrefabs";
        //canvas
        private Transform _canvasRoot;
        //normal root
        private Transform _normalRoot;
        //fixed root
        private Transform _fixedRoot;
        //dialog root
        private Transform _dialogRoot;
        
        //init
        public UI_Manager()
        {
            var uiObj = Resources.Load<Transform>(UIPrefab_Path + "/" + "UIRoot");
            _uiRoot= Object.Instantiate(uiObj,null);
            Object.DontDestroyOnLoad(_uiRoot);
            _canvasRoot = _uiRoot.GetChildrenComponentByNode<Transform>("Canvas_UI");
            _uiCamera = _uiRoot.GetChildrenComponentByNode<Camera>("CameraUI");
            
            _normalRoot = _canvasRoot.GetChildrenComponentByNode<Transform>("Normal");
            _fixedRoot = _canvasRoot.GetChildrenComponentByNode<Transform>("Fixed");
            _dialogRoot = _canvasRoot.GetChildrenComponentByNode<Transform>("Dialog");
        }
        
        //update
        internal override void DoUpdate(float dt)
        {
            foreach (var uiBase in _uiCurrentBases)
            {
                uiBase.DoUpdate(dt);
            }
        }
        
        //显示UI
        public void Show<T>(string UIname ,T content) where T : UI_BaseContent
        {
            if (_uiCurrentNames.Contains(UIname))
                return;
            UI_Base uiBase;
            if (!_uiTempBases.ContainsKey(UIname))
            {
                uiBase = LoadUiPrefab(UIname);
                if (uiBase==null)
                {
                    Debug.LogError("当前的UIName与预制名字是否对应,当前的UIName:" + UIname);
                    return;
                }
                _uiTempBases.Add(UIname,uiBase);
                uiBase.Show();
                uiBase.Init();
            }
            else
            {
                uiBase = _uiTempBases[UIname] ;
                uiBase.ReShow();
            }
            //冻结前面的
            foreach (var ui in _uiCurrentBases)
            {
                ui.Freeze();
            }
            _uiCurrentBases.Push(uiBase);
            _uiCurrentNames.Push(UIname);
            //设置父物体
            Transform parent = _normalRoot;
            switch (uiBase.UiType)
            {
                case UIType.Fixed:
                    parent = _fixedRoot;
                    break;
                case UIType.Dialog:
                    parent = _dialogRoot;
                    break;
            }
            uiBase.transform.parent = parent;
            uiBase.SetContent(content);
        }

        /// <summary>
        /// 隐藏UI 并重新激活上层UI
        /// </summary>
        /// <param name="UIname"></param>
        public void Hide(string UIname)
        {
            bool result = true;
            result &= _uiCurrentNames.Contains(UIname);
            if (result)
            {
                result &= (UIname == _uiCurrentNames.Peek());
            }
            if (result)
            {
                _uiTempBases[UIname].Hide();
                _uiCurrentBases.Pop();
                _uiCurrentNames.Pop();
                //激活最上层UI
                if (_uiCurrentBases.Count > 0)
                {
                    UI_Base uiBase = _uiCurrentBases.Peek();
                    uiBase.ReShow();
                }
            }
        }

        //隐藏全部
        [Obsolete("this method is old ,please use new method HideView",false)]
        public void HideAll()
        {
            foreach (var uiBase in _uiCurrentBases)
            {
                uiBase.Hide();
            }
            _uiCurrentBases.Clear();
            _uiCurrentNames.Clear();
        }

        //隐藏
        public void HideView(UIType uiType = UIType.None)
        {
            Stack<UI_Base> temp = new Stack<UI_Base>();
            Stack<string> tempNames = new Stack<string>();

            int len = _uiCurrentNames.Count;
            for (int i = 0; i < len; i++)
            {
                var ui = _uiCurrentBases.Pop();
                var uiName = _uiCurrentNames.Pop();
                if (uiType!=UIType.None&& ui.UiType!=uiType)
                {
                    temp.Push(ui);
                    tempNames.Push(uiName);
                }
                else
                {
                    ui.Hide();
                }
            }

            len = tempNames.Count;
            for (int i = 0; i < len ; i++)
            {
                var ui = temp.Pop();
                var uiName = tempNames.Pop();
                _uiCurrentBases.Push(ui);
                _uiCurrentNames.Push(uiName);
            }
        }

        //加载UI预制
        private UI_Base LoadUiPrefab(string uiName) 
        {
            var go = Resources.Load(UIPrefab_Path + "/" + uiName);
            GameObject uiBase = GameObject.Instantiate(go,_canvasRoot) as GameObject;
            return uiBase.GetComponent<UI_Base>();
        }
    }
    
}
