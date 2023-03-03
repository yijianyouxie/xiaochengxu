using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/// <summary>
/// 事件发送 只会派发到C#
/// </summary>
public partial class  EventManager
{
   static public Dictionary<int,string> dic_int2str = new Dictionary<int,string>(1200);
    static public Dictionary<string,int> dic_str2int = new Dictionary<string,int>(1200);
    static private int pcount = 0;

    public static void RegisterAllToLua()
    {
        var it = actions.GetEnumerator();
        while (it.MoveNext())
        {
            //if (LuaLinker.Instance != null && LuaLinker.Instance.IsReady)
            //{
            //    LuaInterface.LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnCSRegister");
            //    if (func != null)
            //    {
            //        func.Call(it.Current.Key);
            //    }
            //}
        }
    }

}
