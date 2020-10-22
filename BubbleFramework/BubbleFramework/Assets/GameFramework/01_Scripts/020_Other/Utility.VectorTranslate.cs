using System.Collections;
using System.Collections.Generic;
using BubbleFramework.Bubble_UI;
using UnityEngine;

namespace BubbleFramework
{
    public static partial class Utility
    {
        public static class VectorTranslate
        {
            /// <summary>
            /// world 'position translate UI 'position
            /// </summary>
            /// <param name="worldPosition">world 'position</param>
            /// <returns>UI 'position</returns>
            public static Vector2 WorldToUGUIPosition(Vector3 worldPosition)
            {
                Vector3 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(BubbleFrameEntry.GetModel<UI_Manager>()._uiRoot.rectTransfrom(),
                    screenPoint, BubbleFrameEntry.GetModel<UI_Manager>()._uiCamera, out var localPoint);
                return localPoint;
            }

            /// <summary>
            /// world 'position translate screen 'position
            /// </summary>
            /// <param name="worldPosition">world 'position</param>
            /// <returns> screen 'position</returns>
            public static Vector2 WorldToScreenPoint(Vector3 worldPosition)
            {
                Vector2 screenPoint = BubbleFrameEntry.GetModel<UI_Manager>()._uiCamera.WorldToScreenPoint(worldPosition);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(BubbleFrameEntry.GetModel<UI_Manager>()._uiRoot.rectTransfrom(),
                    screenPoint, BubbleFrameEntry.GetModel<UI_Manager>()._uiCamera, out var localPoint);
                return screenPoint;
            }

            /// <summary>
            /// ui 'position To world 'position
            /// </summary>
            /// <param name="rect">postion </param>
            /// <param name="targetTransform"></param>
            /// <returns></returns>
            public static Vector2 UGUIToWorldPosition(Vector2 rect, Transform targetTransform)
            {
                // 相机到目标的向量
                Vector3 dir = targetTransform.position - Camera.main.transform.position;
                // 计算在摄像机Z方向上的投影向量
                Vector3 normardir = Vector3.Project(dir, Camera.main.transform.forward);
                // 坐标转换，需要知道投影距离,normardir.magnitude是求出向量的长度
                return Camera.main.ScreenToWorldPoint(new Vector3(rect.x, rect.y, normardir.magnitude));
            }
        }
    }
}
