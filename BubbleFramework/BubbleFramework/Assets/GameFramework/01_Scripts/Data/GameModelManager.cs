using System.Collections.Generic;
using System.Linq;

//  注解： 表名和类型名一致
//  MonsterData的类名 对应 MonsterData的表名

public class GameModelManager
{
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
