using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TreeEditor;
using UnityEngine;

namespace Bubble_UI
{
    public class UI_Manager : Bubble_MonoSingle<UI_Manager>
    {
        //ui相机
        public Camera _uiCamera { get; set; }

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
        
        //init
        public void Init()
        {
            var canvas = Resources.Load<Transform>(UIPrefab_Path + "/" + "Canvas_UI");
            _canvasRoot = Instantiate(canvas,transform);
            _uiCamera = _canvasRoot.GetComponentInChildren<Camera>();
        }
        //update
        public void DoUpdate(float dt)
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
                uiBase = LoadUIPrefab(UIname);
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
            uiBase.SetContent(content);
        }

        //隐藏
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
            }
        }

        //隐藏全部
        public void HideAll()
        {
            foreach (var uiBase in _uiCurrentBases)
            {
                uiBase.Hide();
            }
            _uiCurrentBases.Clear();
            _uiCurrentNames.Clear();
        }

        //加载UI预制
        private UI_Base LoadUIPrefab(string UIname) 
        {
            var go = Resources.Load(UIPrefab_Path + "/" + UIname);
            GameObject uiBase = GameObject.Instantiate(go, _canvasRoot) as GameObject;
            return uiBase.GetComponent<UI_Base>();
        }
    }
    
}
