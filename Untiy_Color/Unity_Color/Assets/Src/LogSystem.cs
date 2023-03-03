using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace yijianyouxie.Log
{
    public class LogSystem
    {
        private static string GetCurDateTime()
        {
            var time = System.DateTime.Now;
            return time.ToString("[yyyy-MM-dd HH:mm:ss:ffff]");
        }

        public static void Info(string format, params object[] args)
        {
            string str = string.Format(GetCurDateTime() + "[Info]:" + format, args);
            Debug.Log(str);
        }

        public static void Error(string format, params object[] args)
        {
            string str = string.Format(GetCurDateTime() + "[Error]:" + format, args);
            Debug.LogError(str);
        }
    }
}