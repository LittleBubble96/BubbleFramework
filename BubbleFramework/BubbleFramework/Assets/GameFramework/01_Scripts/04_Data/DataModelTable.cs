using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataModelTable<T> where T : DataModelBase
{
    //表路径
    private const string TABLE_PATH = "CSV/{0}";

    //字段信息行(当前.py中只导出字段与有效数据 所以为1 *这行之下必须数据)
    private const int PROPERTY_ROW = 2;

    public static T[] ParseTable()
    {
        string fullName = string.Format(TABLE_PATH, typeof(T));
        T[] data = CSVHelper.Parse<T>(fullName, PROPERTY_ROW);
        return data;
    }
}
