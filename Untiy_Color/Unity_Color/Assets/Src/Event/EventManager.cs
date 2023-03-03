using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/// <summary>
/// 事件发送 只会派发到C#
/// </summary>
//by sunyu 2017-08-02 SendEvent 可变参数问题
public partial class EventManager
{
    class CloneListData
    {
        public bool IsValid = true;
        public List<BaseAction> cloneList = null;
    }
    private static List<CloneListData> _cloneListPool = new List<CloneListData>();
    /// <summary>
    /// c#事件监听器
    /// </summary>
    public static Dictionary<string, List<BaseAction>> actions = new Dictionary<string, List<BaseAction>>();
    private static CloneListData CloneList(List<BaseAction> list)
    {
        CloneListData newData = null;
        List<BaseAction> newList = null;
        bool hasExist = false;
        for (int i = 0; i < _cloneListPool.Count; i++)
        {
            if(_cloneListPool[i].IsValid)
            {
                newData = _cloneListPool[i];
                hasExist = true;
                break;
            }
        }
        if(!hasExist)
        {
            newData = new CloneListData();
            newData.cloneList = new List<BaseAction>();
            _cloneListPool.Add(newData);
        }
        newList = newData.cloneList;
        newList.Clear();

        for (int i = 0; i < list.Count; i++)
        {
            if(list[i] == null)
            {
                continue;
            }
            newList.Add(list[i]);
        }
        return newData;
    }

    /// <summary>
    /// 异步事件发送
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventAsync(string p_event, params object[] p_param)
    {
        _EventList.Add(p_event);
        _ParamList.Add(p_param);
        _NeedToLuaList.Add(true);
    }

    /// <summary>
    /// 异步事件发送
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_param"></param>
    public static void SendEventAsyncNoBackToLua(string p_event, params object[] p_param)
    {
        _EventList.Add(p_event);
        _ParamList.Add(p_param);
        _NeedToLuaList.Add(false);
    }

    /// <summary>
    /// 隔帧执行
    /// </summary>
    private static void OnSendEventAsync()
    {
        if (_EventList.Count == 0 || _ParamList.Count == 0 || _NeedToLuaList.Count == 0)
        {
            return;
        }
        for (int i = 0; i < _EventList.Count && i < _ParamList.Count && i < _NeedToLuaList.Count; i++)
        {
            string p_event = _EventList[i];
            object[] p_param = _ParamList[i];
            bool bNeetToLua = _NeedToLuaList[i];
            EventManager.SendEvent(p_event, p_param);
            if (bNeetToLua == true)
            {
                //CEventSender.SendEventAsync(p_event, p_param);
            }
        }
        _EventList.Clear();
        _ParamList.Clear();
        _NeedToLuaList.Clear();
    }

    public static void Tick()
    {
        OnSendEventAsync();
    }

    private static List<bool> _NeedToLuaList = new List<bool>();
    private static List<String> _EventList = new List<string>();
    private static List<object[]> _ParamList = new List<object[]>();

}
