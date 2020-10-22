using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleFramework
{
    public static partial class Utility
    {
        public static class Random
        {
            //随机数种子
            private static System.Random s_Random=new System.Random((int)DateTime.Now.Ticks);

            //获取一个非负随机数
            public static int GetRandom()
            {
                return s_Random.Next();
            }

            //获取一个非负随机数 最大时 max
            public static int GetRandom(int max)
            {
                return s_Random.Next(max);
            }

            //获取一个非负随机数 最大时max 最小时 min
            public static int GetRandom(int min,int max)
            {
                return s_Random.Next(min, max);
            }

            /// <summary>
            /// 获取一个随机得0.0到1.0得随机数 
            /// </summary>
            /// <returns></returns>
            public static double GetRandomDouble()
            {
                return s_Random.NextDouble();
            }

            /// <summary>
            /// 获取一个填满buffer数组得随机数
            /// </summary>
            /// <param name="buffer">需要填充得byte数组</param>
            public static void GetRandomBytes(byte[] buffer)
            {
                s_Random.NextBytes(buffer);
            }

        }
    }

}
