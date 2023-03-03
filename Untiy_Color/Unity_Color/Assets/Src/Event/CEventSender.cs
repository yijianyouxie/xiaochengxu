using UnityEngine;

/// <summary>
/// 事件发送 只会派发至lua脚本
/// </summary>
public class CEventSender 
{

    //public static bool IsReady
    //{
    //    get { return LuaLinker.Instance != null && LuaLinker.Instance.IsReady; }
    //}

    //public static void SendEventAsync(string e)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        func.Call(e, 0);
    //    }

    //}

    //public static void SendEventAsync<T1>(string e, T1 arg1)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        var type = typeof(T1);
    //        func.Call(e, (type.IsArray && !type.GetElementType().IsValueType) ? -1 : 1, arg1);
    //    }

    //}

    //public static void SendEventAsync<T1, T2>(string e, T1 arg1, T2 arg2)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        func.Call(e, 2, arg1, arg2);
    //    }

    //}

    //public static void SendEventAsync<T1, T2, T3>(string e, T1 arg1, T2 arg2, T3 arg3)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        func.Call(e, 3, arg1, arg2, arg3);
    //    }

    //}

    //public static void SendEventAsync<T1, T2, T3, T4>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        func.Call(e, 4, arg1, arg2, arg3, arg4);
    //    }

    //}

    //public static void SendEventAsync<T1, T2, T3, T4, T5>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        func.Call(e, 5, arg1, arg2, arg3, arg4, arg5);
    //    }

    //}

    ////TODO 把这个去掉
    //public static void SendEventAsync(string e, object[] args)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEventAsync");
    //    if (func != null)
    //    {
    //        func.Call(e, -1, args);
    //    }
    //}

    //public static void SendEvent(string e)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 0);
    //    }
    //}

    //public static void SendEvent<T1>(string e, T1 arg1)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        var type = typeof(T1);
    //        func.Call(e, (type.IsArray && !type.GetElementType().IsValueType) ? -1 : 1, arg1);
    //    }

    //}

    //public static void SendEvent<T1, T2>(string e, T1 arg1, T2 arg2)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 2, arg1, arg2);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3>(string e, T1 arg1, T2 arg2, T3 arg3)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 3, arg1, arg2, arg3);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 4, arg1, arg2, arg3, arg4);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4, T5>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 5, arg1, arg2, arg3, arg4, arg5);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4, T5, T6>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 6, arg1, arg2, arg3, arg4, arg5, arg6);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4, T5, T6, T7>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 7, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4, T5, T6, T7, T8>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 8, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 9, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    //    }
    //}

    //public static void SendEvent<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string e, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
    //{
    //    if (!IsReady)
    //    {
    //        return;
    //    }

    //    LuaFunction func = LuaScriptMgr.Instance.GetLuaFunction("OnEvent");
    //    if (func != null)
    //    {
    //        func.Call(e, 10, arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    //    }
    //}


    /// <summary>
    /// C#使用EventManager发送事件，这个接口只给Lua使用 事件发送 暂时会同时派发至lua脚本和c#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventFromLuaToCSharp(string p_event, params object[] p_param)
    {
        if (Application.isPlaying == false)
            return;
        EventManager.SendEvent(p_event, p_param);
    }

    /// <summary>
    /// C#使用EventManager发送事件，这个接口只给Lua使用 事件发送 暂时会同时派发至lua脚本和c#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventFromLuaToCSharp_Int(string p_event, int p_param)
    {
        if (Application.isPlaying == false)
            return;
        EventManager.SendEvent(p_event, p_param);
    }

    /// <summary>
    /// C#使用EventManager发送事件，这个接口只给Lua使用 事件发送 暂时会同时派发至lua脚本和c#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventFromLuaToCSharp_String(string p_event, string p_param)
    {
        if (Application.isPlaying == false)
            return;
        EventManager.SendEvent(p_event, p_param);
    }
    
    /// <summary>
    /// C#使用EventManager发送事件，这个接口只给Lua使用 事件发送 暂时会同时派发至lua脚本和c#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventFromLuaToCSharp_Bool(string p_event, bool p_param)
    {
        if (Application.isPlaying == false)
            return;
        EventManager.SendEvent(p_event, p_param);
    }


    /// <summary>
    /// C#使用EventManager发送事件，这个接口只给Lua使用 事件发送 暂时会同时派发至lua脚本和c#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventFromLuaToCSharpAync(string p_event, params object[] p_param)
    {
        if (Application.isPlaying == false)
            return;
        EventManager.SendEventAsyncNoBackToLua(p_event, p_param);
    }

}