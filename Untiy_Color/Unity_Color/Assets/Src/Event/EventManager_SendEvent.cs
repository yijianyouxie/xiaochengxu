
using System.Collections;
using System.Collections.Generic;
using System;
using Games.TLBB.Util;
/// <summary>
/// 事件发送 只会派发到C#
/// </summary>
public partial class  EventManager
{

    /// <summary>
    /// 事件发送 只会派发到C#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEvent(string p_event, params object[] p_param)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent objectarray" + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 1:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }
    public static void SendEvent(string p_event, object p_param0)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent object" + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param0);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 2:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }

    public static void SendEvent(string p_event, int p_param0, string p_param1, System.Object p_param2)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent object" + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param0, p_param1, p_param2);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 3:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif

    }

    // public static void SendEvent(string p_event, int p_param0, float p_param1, float p_param2)
    // {
    // }


    // public static void SendEvent(string p_event, int p_param0, string p_param1)
    // {
    // }

    // public static void  SendEvent(string p_event, int p_param0, int p_param1)
    // {
    // }

    // public static void SendEvent(string p_event, int p_param0, bool p_param1)
    // {
    // }

    // public static void SendEvent(string p_event, string p_param0, int p_param1)
    // {
    // }

    // public static void SendEvent(string p_event, object p_param0, object p_param1)
    // {
    // }

    public static void SendEvent(string p_event, int p_param0, string p_param1, float p_param2, float p_param3)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent object string " + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param0, p_param1, p_param2, p_param3);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 4:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }

    public static void SendEvent(string p_event, object p_param0, string p_param1)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent object string " + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param0, p_param1);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 5:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }

    public static void SendEvent(string p_event, string p_param)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent string " + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 6:" + p_event);
                    }
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }

    public static void SendEvent(string p_event, bool p_param)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEvent bool " + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 7:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }


    /// <summary>
    /// 事件发送 只会派发到C#
    /// </summary>
    /// <param name="p_event"></param>
    public static void SendEvent(string p_event)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEventNoParam " + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute();
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 8:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }
    /// <summary>
    /// 事件发送 只会派发到C#
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEvent(string p_event, int p_param)
    {
        #if (GCALLOC)
        UnityEngine.Profiling.Profiler.BeginSample("EventManager SendEventInt " + p_event);
        #endif
        if (actions.ContainsKey(p_event))
        {
            CloneListData data = CloneList(actions[p_event]);
            data.IsValid = false;
            List<BaseAction> list = data.cloneList;
            for (int i = 0; i < list.Count; i++)
            {
                BaseAction ba = list[i];
                if(ba != null)
                {
                    try
                    {
                        ba.Execute(p_param);
                    }
                    catch (Exception ex)
                    {
                        GameUtil.LogAndReportException(ex, "SendEvent 9:" + p_event);
                    }
                    
                }
            }
            data.IsValid = true;
        }
        #if (GCALLOC) 
        UnityEngine.Profiling.Profiler.EndSample();  
        #endif
    }
}
