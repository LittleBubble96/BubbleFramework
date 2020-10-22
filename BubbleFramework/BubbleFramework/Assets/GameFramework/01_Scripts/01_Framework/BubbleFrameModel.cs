namespace BubbleFramework
{
    public abstract class BubbleFrameModel
    {
        /// <summary>
        /// 优先级 根据这个值来 优先轮序
        /// </summary>
        internal virtual int Priority => 0;

        /// <summary>
        /// update 更新
        /// </summary>
        /// <param name="dt"></param>
        internal virtual void DoUpdate(float dt)
        {
            
        }

    }

}
