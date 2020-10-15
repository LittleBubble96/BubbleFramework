using BubbleFramework.Bubble_Event;
using BubbleFramework.Pool;

namespace BubbleFramework
{
    public static class Reg
    {
        //事件调用
       public static readonly AppEventDispatcher EventDispatcher =new AppEventDispatcher();
       //解析csv调用
       public static readonly GameModelManager ModelManager =new GameModelManager();
    }
}

