using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/// <summary>
/// 事件发送 只会派发到C#
/// </summary>
public partial class  EventManager
{
    private static BaseAction m_oahd = new BaseAction();

    public static void RegisterTemplate<T>(BaseAction.ParamEnum pt, string p_event, T p_action)
    {
        if (!actions.ContainsKey(p_event))
        {
            List<BaseAction> aList = new List<BaseAction>();
            actions.Add(p_event, aList);
        }

        List<BaseAction> list = actions[p_event];
        m_oahd.MyHandler = p_action as System.Delegate;
        if (list.Contains(m_oahd) == false)
        {
            BaseAction hd = BaseAction.NewByType(pt);
            if(hd != null)
            {
                hd.MyHandler = p_action as System.Delegate;
                list.Add(hd);
                if (list.Count==1)
                {
                    //if (LuaLinker.Instance != null && LuaLinker.Instance.IsReady)
                    //{
                    //    LuaInterface.LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnCSRegister");
                    //    if (func != null)
                    //    {
                    //        func.Call(p_event);
                    //    }
                    //}
                }
            }
        }
        m_oahd.CleanUp();
    }

     public static void RemoveTemplate<T>(string p_event, T p_action)
     {
        if (!actions.ContainsKey(p_event))
        {
            return;
        }
        List<BaseAction> list = actions[p_event];
        m_oahd.MyHandler = p_action as System.Delegate;
        int idx = list.IndexOf(m_oahd);
        if (idx != -1)
        {
            BaseAction ba = list[idx];
            list.RemoveAt(idx);
            BaseAction.Recycle(ref ba);

            if (list.Count == 0)
            {
                //if (LuaLinker.Instance != null && LuaLinker.Instance.IsReady)
                //{
                //    LuaInterface.LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnCSUnRegister");
                //    if (func != null)
                //    {
                //        func.Call(p_event);
                //    }
                //}
            }
        }
        m_oahd.CleanUp();
     }

    public static void RegistDelegate(string p_event, MyAction<object[]> p_action)
    {
        RegisterTemplate<MyAction<object[]>>(BaseAction.ParamEnum.PARAM_OBJECT_ARRAY, p_event, p_action);
    }
    
    public static void RemoveDelegate(string p_event, MyAction<System.Object[]> p_action)
    {
        RemoveTemplate<MyAction<System.Object[]>>(p_event, p_action);
    }

    public static void RegistDelegate(string p_event, MyAction<int> p_action)
    {
        RegisterTemplate<MyAction<int>>(BaseAction.ParamEnum.PARAM_INT, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<int> p_action)
    {
        RemoveTemplate<MyAction<int>>(p_event, p_action);
    }
    public static void RegistDelegate(string p_event, MyAction<bool> p_action)
    {
        RegisterTemplate<MyAction<bool>>(BaseAction.ParamEnum.PARAM_BOOL, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<bool> p_action)
    {
        RemoveTemplate<MyAction<bool>>(p_event, p_action);
    }

    public static void RegistDelegate(string p_event, MyAction<string> p_action)
    {
        RegisterTemplate<MyAction<string>>(BaseAction.ParamEnum.PARAM_STRING, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<string> p_action)
    {
        RemoveTemplate<MyAction<string>>(p_event, p_action);
    }

    public static void RegistDelegate(string p_event, MyAction<object,string> p_action)
    {
        RegisterTemplate<MyAction<object,string>>(BaseAction.ParamEnum.PARAM_OBJECT_STRING, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<object,string> p_action)
    {
        RemoveTemplate<MyAction<object,string>>(p_event, p_action);
    }

    public static void RegistDelegate(string p_event, MyAction<int,string,float,float> p_action)
    {
        RegisterTemplate<MyAction<int,string,float,float>>(BaseAction.ParamEnum.PARAM_INT_STRING_FLOAT_FLOAT, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<int,string,float,float> p_action)
    {
        RemoveTemplate<MyAction<int,string,float,float>>(p_event, p_action);
    }
    public static void RegistDelegate(string p_event, MyAction<System.Object> p_action)
    {
        RegisterTemplate<MyAction<System.Object>>(BaseAction.ParamEnum.PARAM_OBJECT, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<System.Object> p_action)
    {
        RemoveTemplate<MyAction<System.Object>>(p_event, p_action);
    }

    public static void RegistDelegate(string p_event, MyAction<int,string,System.Object> p_action)
    {
        RegisterTemplate<MyAction<int,string,System.Object>>(BaseAction.ParamEnum.PARAM_INT_STRING_OBJECT, p_event, p_action);
    }
    public static void RemoveDelegate(string p_event, MyAction<int,string,System.Object> p_action)
    {
        RemoveTemplate<MyAction<int,string,System.Object>>(p_event, p_action);
    }


}
