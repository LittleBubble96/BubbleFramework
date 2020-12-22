using System;
using System.Collections.Generic;
using System.Reflection;
using BubbleFramework;
using BubbleFramework.Bubble_UI;

namespace GameFramework._01_Scripts._03_Setting
{
    public class LanguageMgr : BubbleFrameModel
    {
        private SLanguageCache _language;
        public SLanguageCache Language {
            get => _language;
            private set
            {
                if (!Equals(value, _language))
                {
                    _language = value;
                    //储存语言
                    CPlayerPrefs.Save<SLanguageCache>(CPlayerKeys.LANGUAGE_KEY, _language);
                    //刷新语言
                    RefreshLanguage();
                    //刷新UI
                    BubbleFrameEntry.GetModel<UI_Manager>().RefreshUiLanguage();
                }
            }
        }
        /// <summary>
        /// 所有语言数据
        /// </summary>
        private List<LanguageData> _languageData;

        /// <summary>
        /// 显示的语言数据
        /// </summary>
        private SLanguageData[] _showLanguageData;

        public LanguageMgr()
        {
            _languageData = BubbleFrameEntry.GetModel<GameModelManager>().GetLanguageDatas;
            
            _showLanguageData = new SLanguageData[_languageData.Count];
            
            //获取语言 如果有本地保存 获取本地， 如果没有 获取系统语言
            SLanguageCache l = CPlayerPrefs.GetData<SLanguageCache>(CPlayerKeys.LANGUAGE_KEY);
            if (string.IsNullOrEmpty(l.LanguageType))
            {
                _language = new SLanguageCache(B_Application.GetLanguage());
            }
            else
            {
                _language = l;
            }
            //储存语言
            CPlayerPrefs.Save<SLanguageCache>(CPlayerKeys.LANGUAGE_KEY, _language);
            //刷新语言
            RefreshLanguage();
        }
        
        /// <summary>
        /// 显示的语言
        /// </summary>
        private struct  SLanguageData
        {
            public int ID;

            public string Text;
        }

        public struct SLanguageCache
        {
            public string LanguageType;

            public SLanguageCache(ELanguage language)
            {
                LanguageType = Enum.GetName(typeof(ELanguage), language);
            }
        }

        /// <summary>
        /// 刷新语言
        /// </summary>
        private void RefreshLanguage()
        {
            for (int i = 0; i < _showLanguageData.Length; i++)
            {
               _showLanguageData[i] = new SLanguageData();
               _showLanguageData[i].ID = _languageData[i].ID;
               
               Type languageType = _languageData[i].GetType();
               if (!string.IsNullOrEmpty(Language.LanguageType) && Language.LanguageType != "None")
               {
                   
                   FieldInfo info = languageType.GetField(Language.LanguageType);
                   if (info!=null)
                   {
                       var text = (string)info.GetValue(_languageData[i]);
                       _showLanguageData[i].Text = text;
                   }
               }
            }
        }

        #region Interface 

        /// <summary>
        /// 获取显示文本
        /// </summary>
        /// <param name="id"></param>
        public string GetText(int id)
        {
            foreach (var language in _showLanguageData)
            {
                if (id == language.ID)
                {
                    return language.Text;
                }
            }
            return null;
        }

        /// <summary>
        /// 设置语言
        /// </summary>
        public void SetLanguage(ELanguage eLanguage)
        {
            Language = new SLanguageCache(eLanguage);
        }

        #endregion
      

    }
    
    
}
