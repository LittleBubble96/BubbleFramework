//状态控制器

using System.Collections.Generic;

public interface IStateController
{
    IState CurState { get; set; }
    List<IState> States { get; set; }

    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="state"></param>
    void AddState(IState state);

    void OnUpdate(float dt);

}
