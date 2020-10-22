using System.Collections.Generic;
using System.Linq;
using BubbleFramework;

//  注解： 表名和类型名一致
//  MonsterData的类名 对应 MonsterData的表名

public class GameModelManager : BubbleFrameModel
{
    /// <summary>
    /// 轮序值为20
    /// </summary>
    internal override int Priority => 20;

    #region MonsterData

    private List<MonsterData> getMonsterDatas;

    public List<MonsterData> GetMonsterDatas
    {
        get
        {
            if (getMonsterDatas==null)
            {
                getMonsterDatas = DataModelTable<MonsterData>.ParseTable().ToList();
            }
            return getMonsterDatas;
        }
    }

    #endregion
   
}
