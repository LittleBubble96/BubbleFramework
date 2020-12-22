using System.Collections;
using System.Collections.Generic;
using BubbleFramework;
using UnityEngine;

public class B_Application
{
        /// <summary>
        /// 获取语言
        /// </summary>
        /// <returns></returns>
        public static ELanguage GetLanguage()
        {
                ELanguage eLanguage = ELanguage.EN;
#if UNITY_EDITOR
                var language = System.Globalization.CultureInfo.InstalledUICulture.EnglishName;
                eLanguage = GetWinLanguage(language);
                DDebug.Log("windows "+eLanguage);
#elif UNITY_IPHONE
        platform = "hi，大家好,我是IPHONE平台";
                
#elif UNITY_ANDROID
        platform = "hi，大家好,我是ANDROID平台";
#elif UNITY_STANDALONE_WIN
                var language = System.Globalization.CultureInfo.InstalledUICulture.EnglishName;
                eLanguage = GetWinLanguage(language);
                DDebug.Log("windows "+eLanguage);
#endif
                return eLanguage;
        }

        private static ELanguage GetWinLanguage(string language)
        {
                ELanguage eLanguage = ELanguage.EN;

                if (language == "Chinese (Simplified)")
                {
                        eLanguage = ELanguage.CN;
                }
                else if (language == "Chinese (Traditional)")
                {
                        eLanguage = ELanguage.HK;
                }
                else if (language.Contains("English"))
                {
                        eLanguage = ELanguage.EN;
                }
                else if (language.Contains("Japanese"))
                {
                        eLanguage = ELanguage.JA;
                }
                else if (language.Contains("Korean"))
                {
                        eLanguage = ELanguage.KO;
                }
                else if (language.Contains("Italian"))
                {
                        eLanguage = ELanguage.IT;
                }
                else if (language.Contains("French"))
                {
                        eLanguage = ELanguage.FR;
                }
                else if (language.Contains("Portuguese"))
                {
                        eLanguage = ELanguage.PT;
                }
                else if (language.Contains("Estonian"))
                {
                        eLanguage = ELanguage.ES;
                }
                else if (language.Contains("German"))
                {
                        eLanguage = ELanguage.DE;
                }

                return eLanguage;
        }
}
