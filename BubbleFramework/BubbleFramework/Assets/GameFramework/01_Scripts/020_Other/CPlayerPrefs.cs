
using System;
using System.Collections.Generic;
using BubbleFramework;
using UnityEngine;

public class CPlayerKeys
{
    public const string EXAMPLE_KEY = "example_key";
}

public class CPlayerPrefs
{
    /// <summary>
    /// 覆盖当前数据
    /// </summary>
    /// <param name="key"> 键值</param>
    /// <param name="data"> 数据</param>
    public static void Save<T>(string key,T data)
    {
        try
        {
            string d = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, d);
        }
        catch (Exception e)
        {
            throw new GameException(e.Message);
        }
      
    }
    
    /// <summary>
    /// 储存得数据是集合 
    ///在此基础上增加数据
    /// </summary>
    /// <param name="key">键值</param>
    /// <param name="data">数据</param>
    public static void SaveAdd<T>(string key, T data)
    {
        try
        {
            List<T> list = HasKey(key) ? JsonUtility.FromJson<List<T>>(PlayerPrefs.GetString(key)) : new List<T>();
            if (list==null)
            {
                DDebug.LogError("请检查类型是否正确 "+typeof(T));
                return;
            }
            list.Add(data);
            Save(key, list);
        }
        catch (Exception e)
        {
            throw new GameException(e.Message);
        }
       
    }

    /// <summary>
    /// 获取数据
    /// </summary>
    /// <param name="key">键值</param>
    public static T GetData<T>(string key)
    {
        try
        {
            T data = HasKey(key) ? JsonUtility.FromJson<T>(PlayerPrefs.GetString(key)) : default(T);
            return data;
        }
        catch (Exception e)
        {
            throw new GameException(e.Message);
        }
      
    }

    /// <summary>
    /// 删除键
    /// </summary>
    /// <param name="key">键值</param>
    public static void DeleteKey(string key)
    {
        try
        {
            if (HasKey(key))
            {
                PlayerPrefs.DeleteKey(key);
            }
        }
        catch (Exception e)
        {
            throw new GameException("键值输入是否正确");
        }
    }

    /// <summary>
    /// 删除所有数据
    /// </summary>
    public static void DeleteAll()
    {
        try
        {
            PlayerPrefs.DeleteAll();
        }
        catch (Exception e)
        {
           throw new GameException(e.Message);
        }
    }

    /// <summary>
    /// 是否存在键值
    /// </summary>
    /// <param name="key">键值</param>
    /// <returns>bool</returns>
    private static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(key);
    }
}
