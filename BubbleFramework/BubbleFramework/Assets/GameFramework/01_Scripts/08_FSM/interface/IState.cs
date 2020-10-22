
//状态基类

using System;
using System.Collections.Generic;

public interface IState
{
    //名字
    string Name { get; set; }

    Action OnEnter { get; set; }
    Action<float> OnUpdate { get; set; }
    Action OnExit { get; set; }

    //转换的指向状态
    List<ITranslation> Translations { get; set; }

    //添加状态转换
    void AddStateTranslation(ITranslation translation);
}
