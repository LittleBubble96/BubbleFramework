
using UnityEngine;

namespace BubbleFramework
{
    public class GameManager : Bubble_MonoSingle<GameManager>
    {
        void Awake()
        {
            BubbleFrameEntry.Awake();
        }

        void Update()
        {
            BubbleFrameEntry.Update();
        }
    }
}

