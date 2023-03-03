using System;
using System.Collections.Generic;
using yijianyouxie.Log;

public class BaseAction: IEquatable<BaseAction>
{
	public enum ParamEnum 
    {
		PARAM_NONE,
        PARAM_INT,
        PARAM_BOOL,
        PARAM_STRING,
        PARAM_OBJECT,
        PARAM_OBJECT_STRING,
        PARAM_INT_STRING_FLOAT_FLOAT,
        PARAM_INT_STRING_OBJECT,
        PARAM_OBJECT_ARRAY
	}
    public virtual bool Execute(System.Object[] p_param)
    {
        return false;
    }
    public virtual ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_NONE;
    }
    public System.Delegate MyHandler = null;
    public virtual void CleanUp()
    {
        MyHandler = null;
    }
    private static Queue<Object_Array_Handler> Object_Array_Pool = new Queue<Object_Array_Handler>(100);
    private static Queue<Int_Param_Handler> Int_Param_Pool = new Queue<Int_Param_Handler>(100);
    private static Queue<Object_Param_Handler> Object_Param_Pool = new Queue<Object_Param_Handler>(100);
    private static Queue<Bool_Param_Handler> Bool_Param_Pool = new Queue<Bool_Param_Handler>(100);
    private static Queue<String_Param_Handler> String_Param_Pool = new Queue<String_Param_Handler>(100);
    private static Queue<Object_String_Param_Handler> Object_String_Param_Pool = new Queue<Object_String_Param_Handler>(100);
    private static Queue<Int_String_Float_Float_Handler> Int_String_Float_Float_Pool = new Queue<Int_String_Float_Float_Handler>(100);
    private static Queue<Int_String_Object_Handler> Int_String_Object_Pool = new Queue<Int_String_Object_Handler>(100);

    public static BaseAction NewByType(ParamEnum pe)
    {
        if( pe == BaseAction.ParamEnum.PARAM_NONE)
            return null;

        switch(pe)
        {
            case BaseAction.ParamEnum.PARAM_INT:
            {
                if (Int_Param_Pool != null)
                {
                    if (Int_Param_Pool.Count > 0)
                    {
                        Int_Param_Handler ret = Int_Param_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Int_Param_Handler();
            }
            case BaseAction.ParamEnum.PARAM_BOOL:
            {
                if (Bool_Param_Pool != null)
                {
                    if (Bool_Param_Pool.Count > 0)
                    {
                        Bool_Param_Handler ret = Bool_Param_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Bool_Param_Handler();
            }
            case BaseAction.ParamEnum.PARAM_STRING:
            {
                if (String_Param_Pool != null)
                {
                    if (String_Param_Pool.Count > 0)
                    {
                        String_Param_Handler ret = String_Param_Pool.Dequeue();
                        return ret;
                    }
                }
                return new String_Param_Handler();
            }
            case BaseAction.ParamEnum.PARAM_OBJECT_STRING:
            {
                if (Object_String_Param_Pool != null)
                {
                    if (Object_String_Param_Pool.Count > 0)
                    {
                        Object_String_Param_Handler ret = Object_String_Param_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Object_String_Param_Handler();
            }
            case BaseAction.ParamEnum.PARAM_INT_STRING_FLOAT_FLOAT:
            {
                if (Int_String_Float_Float_Pool != null)
                {
                    if (Int_String_Float_Float_Pool.Count > 0)
                    {
                        Int_String_Float_Float_Handler ret = Int_String_Float_Float_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Int_String_Float_Float_Handler();
            }
            case BaseAction.ParamEnum.PARAM_OBJECT_ARRAY:
            {
                if (Object_Array_Pool != null)
                {
                    if (Object_Array_Pool.Count > 0)
                    {
                        Object_Array_Handler ret = Object_Array_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Object_Array_Handler();
            }
            case BaseAction.ParamEnum.PARAM_OBJECT:
            {
                if (Object_Param_Pool != null)
                {
                    if (Object_Param_Pool.Count > 0)
                    {
                        Object_Param_Handler ret = Object_Param_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Object_Param_Handler();
            }
            case BaseAction.ParamEnum.PARAM_INT_STRING_OBJECT:
            {
                if (Int_String_Object_Pool != null)
                {
                    if (Int_String_Object_Pool.Count > 0)
                    {
                        Int_String_Object_Handler ret = Int_String_Object_Pool.Dequeue();
                        return ret;
                    }
                }
                return new Int_String_Object_Handler();
            }
            default:
                return null;
        }
    }
    public static void Recycle(ref BaseAction needdel)
    {
        if(needdel == null)
            return;
        BaseAction.ParamEnum pe = needdel.Ptype();
        switch(pe)
        {
            case BaseAction.ParamEnum.PARAM_INT:
            {
                needdel.CleanUp();
                if (Int_Param_Pool != null)
                {
                    if (Int_Param_Pool.Count < 100)
                    {
                        Int_Param_Pool.Enqueue((Int_Param_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;
            case BaseAction.ParamEnum.PARAM_BOOL:
            {
                needdel.CleanUp();
                if (Bool_Param_Pool != null)
                {
                    if (Bool_Param_Pool.Count < 100)
                    {
                        Bool_Param_Pool.Enqueue((Bool_Param_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;

            case BaseAction.ParamEnum.PARAM_STRING:
            {
                needdel.CleanUp();
                if (String_Param_Pool != null)
                {
                    if (String_Param_Pool.Count < 100)
                    {
                        String_Param_Pool.Enqueue((String_Param_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;

            case BaseAction.ParamEnum.PARAM_OBJECT_STRING:
            {
                needdel.CleanUp();
                if (Object_String_Param_Pool != null)
                {
                    if (Object_String_Param_Pool.Count < 100)
                    {
                        Object_String_Param_Pool.Enqueue((Object_String_Param_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;

            case BaseAction.ParamEnum.PARAM_INT_STRING_FLOAT_FLOAT:
            {
                needdel.CleanUp();
                if (Int_String_Float_Float_Pool != null)
                {
                    if (Int_String_Float_Float_Pool.Count < 100)
                    {
                        Int_String_Float_Float_Pool.Enqueue((Int_String_Float_Float_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;

            case BaseAction.ParamEnum.PARAM_OBJECT_ARRAY:
            {
                needdel.CleanUp();
                if (Object_Array_Pool != null)
                {
                    if (Object_Array_Pool.Count < 100)
                    {
                        Object_Array_Pool.Enqueue((Object_Array_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;

            case BaseAction.ParamEnum.PARAM_OBJECT:
            {
                needdel.CleanUp();
                if (Object_Param_Pool != null)
                {
                    if (Object_Param_Pool.Count < 100)
                    {
                        Object_Param_Pool.Enqueue((Object_Param_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;

            case BaseAction.ParamEnum.PARAM_INT_STRING_OBJECT:
            {
                needdel.CleanUp();
                if (Int_String_Object_Pool != null)
                {
                    if (Int_String_Object_Pool.Count < 100)
                    {
                        Int_String_Object_Pool.Enqueue((Int_String_Object_Handler)needdel);
                    }
                }
                needdel = null;
            }
            break;
            

        }
    }
    public virtual bool  ErrorParameExecute()
    {
        return false;
    }
    public virtual bool Execute()
    {
        return Execute((System.Object[])null);
    }
    public virtual bool Execute(int p_param)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(int p_param)");
        System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
        _p_tmp_param[0] = p_param;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
        return ret;
    }
    public virtual bool Execute(System.Object p_param)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(System.Object p_param)");
        System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
        _p_tmp_param[0] = p_param;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
        return ret;
    }
    public virtual bool Execute(bool p_param)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(bool p_param)");
        System.Object[] _p_tmp_param =  Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
        _p_tmp_param[0] = p_param;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
        return ret;
    }
    public virtual bool Execute(string p_param)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(string p_param)");
        System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
        _p_tmp_param[0] = p_param;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
        return ret;
    }
    public virtual bool Execute(System.Object p_param0, string p_param1)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(object p_param0, string p_param1)");
        System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray2();
        _p_tmp_param[0] = p_param0;
        _p_tmp_param[1] = p_param1;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        _p_tmp_param[1] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray2(ref _p_tmp_param);
        return ret;
    }
    public virtual bool Execute(int p_param0, string p_param1, float p_param2, float p_param3)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(int p_param0, string p_param1, float p_param2, float p_param3)");
        System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray4();
        _p_tmp_param[0] = p_param0;
        _p_tmp_param[1] = p_param1;
        _p_tmp_param[2] = p_param2;
        _p_tmp_param[3] = p_param3;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        _p_tmp_param[1] = null;
        _p_tmp_param[2] = null;
        _p_tmp_param[3] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray4(ref _p_tmp_param);
        return ret;
    }
    public virtual bool Execute(int p_param0, string p_param1, System.Object p_param2)
    {
        LogSystem.Error("Event处理函数参数不匹配导致new Object[]及装箱-(int p_param0, string p_param1, float p_param2, float p_param3)");
        System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray3();
        _p_tmp_param[0] = p_param0;
        _p_tmp_param[1] = p_param1;
        _p_tmp_param[2] = p_param2;
        bool ret = Execute(_p_tmp_param);
        _p_tmp_param[0] = null;
        _p_tmp_param[1] = null;
        _p_tmp_param[2] = null;
        Games.TLBB.Util.GameUtil.PoolDelObjectArray3(ref _p_tmp_param);
        return ret;
    }

    public bool Equals(BaseAction y)
    {
        return (this.MyHandler == y.MyHandler);
    }
}
public class Object_Array_Handler : BaseAction
{
    public Object_Array_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Object_Array_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_OBJECT_ARRAY;
    }
    public override bool Execute()
    {
        if(MyHandler != null)
        {
            ((MyAction<System.Object[]>)MyHandler)(null);
            return true;
        }
        return false;
    }
    public override bool Execute(int p_param)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
            _p_tmp_param[0] = p_param;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object p_param)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
            _p_tmp_param[0] = p_param;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
            return true;
        }
        return false;
    }
    public override bool Execute(bool p_param)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
            _p_tmp_param[0] = p_param;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
            return true;
        }
        return false;
    }
    public override bool Execute(object[] p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<System.Object[]>)MyHandler)(p_param);
            return true;
        }
        return false;
    }
    public override bool Execute(string p_param)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray1();
            _p_tmp_param[0] = p_param;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray1(ref _p_tmp_param);
        }
        return false;
    }
    public override bool Execute(System.Object p_param0, string p_param1)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray2();
            _p_tmp_param[0] = p_param0;
            _p_tmp_param[1] = p_param1;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            _p_tmp_param[1] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray2(ref _p_tmp_param);
            return true;
        }
        return false;
    }
    public override bool Execute(int p_param0, string p_param1, System.Object p_param2)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray3();
            _p_tmp_param[0] = p_param0;
            _p_tmp_param[1] = p_param1;
            _p_tmp_param[2] = p_param2;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            _p_tmp_param[1] = null;
            _p_tmp_param[2] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray3(ref _p_tmp_param);
            return true;
        }
        return false;
    }
    public override bool Execute(int p_param0, string p_param1, float p_param2, float p_param3)
    {
        if(MyHandler != null)
        {
            System.Object[] _p_tmp_param = Games.TLBB.Util.GameUtil.PoolNewObjectArray4();
            _p_tmp_param[0] = p_param0;
            _p_tmp_param[1] = p_param1;
            _p_tmp_param[2] = p_param2;
            _p_tmp_param[3] = p_param3;
            ((MyAction<System.Object[]>)MyHandler)(_p_tmp_param);
            _p_tmp_param[0] = null;
            _p_tmp_param[1] = null;
            _p_tmp_param[2] = null;
            _p_tmp_param[3] = null;
            Games.TLBB.Util.GameUtil.PoolDelObjectArray4(ref _p_tmp_param);
            return true;
        }
        return false;
    }
}
public class Int_String_Object_Handler : BaseAction
{
    public Int_String_Object_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Int_String_Object_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_INT_STRING_OBJECT;
    }
    public override bool Execute(int p_param0, string p_param1, System.Object p_param2)
    {
        if(MyHandler != null)
        {
            ((MyAction<int,string,System.Object>)MyHandler)(p_param0, p_param1, p_param2);
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<int,string,System.Object>)MyHandler)(0, string.Empty, null);
                }
                else if(len == 1)
                {
                    ((MyAction<int,string,System.Object>)MyHandler)(Convert.ToInt32(p_param[0]), string.Empty, null);
                }
                else if(len == 2)
                {
                    ((MyAction<int,string,System.Object>)MyHandler)(Convert.ToInt32(p_param[0]), p_param[1].ToString(), null);
                }
                else
                {
                    ((MyAction<int,string,System.Object>)MyHandler)(Convert.ToInt32(p_param[0]), p_param[1].ToString(), p_param[2]);
                }
            }
            else
            {
                ((MyAction<int,string,System.Object>)MyHandler)(0, string.Empty, null);
            }
            return true;
        }
        return false;
    }
}

public class Int_Param_Handler : BaseAction
{
    public Int_Param_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Int_Param_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_INT;
    }
    public override bool Execute(int p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<int>)MyHandler)(p_param);
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<int>)MyHandler)(0);
                }
                else
                {
                    ((MyAction<int>)MyHandler)(Convert.ToInt32(p_param[0]));
                }
            }
            else
            {
                ((MyAction<int>)MyHandler)(0);
            }
            return true;
        }
        return false;
    }
}

public class Object_Param_Handler : BaseAction
{
    public Object_Param_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Object_Param_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_OBJECT;
    }
    public override bool Execute(System.Object p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<System.Object>)MyHandler)(p_param);
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<System.Object>)MyHandler)(null);
                }
                else
                {
                    ((MyAction<System.Object>)MyHandler)(p_param[0]);
                }
            }
            else
            {
                ((MyAction<System.Object>)MyHandler)(null);
            }
            return true;
        }
        return false;
    }
}

public class Bool_Param_Handler : BaseAction
{
    public Bool_Param_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Bool_Param_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_BOOL;
    }
    //2017-10-15 sunyu GC优化
	public override bool Execute()
    {
        if (MyHandler != null)
        {
            ((MyAction<bool>)MyHandler)(false);
            return true;
        }
        return false;
    }
    public override bool Execute(int p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<bool>)MyHandler)(p_param==0?false:true);
            return true;
        }
        return false;
    }
    public override bool Execute(bool p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<bool>)MyHandler)(p_param);
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<bool>)MyHandler)(false);
                }
                else
                {
                    ((MyAction<bool>)MyHandler)(Convert.ToBoolean(p_param[0]));
                }
            }
            else
            {
                ((MyAction<bool>)MyHandler)(false);
            }
            return true;
        }
        return false;
    }
}

public class String_Param_Handler : BaseAction
{
    private static string _p_obj_param = null;

    public String_Param_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public String_Param_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_STRING;
    }
    public override bool Execute(int p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<string>)MyHandler)(p_param.ToString());
            return true;
        }
        return false;
    }
    public override bool Execute(bool p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<string>)MyHandler)(p_param.ToString());
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<string>)MyHandler)(string.Empty);
                }
                else
                {
                    ((MyAction<string>)MyHandler)(p_param[0].ToString());
                }
            }
            else
            {
                ((MyAction<string>)MyHandler)(string.Empty);
            }
            return true;
        }
        return false;
    }
    public override bool Execute(string p_param)
    {
        if(MyHandler != null)
        {
            ((MyAction<string>)MyHandler)(p_param);
            return true;
        }
        return false;
    }
}

public class Object_String_Param_Handler : BaseAction
{
    public Object_String_Param_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Object_String_Param_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_OBJECT_STRING;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<System.Object,string>)MyHandler)(null, string.Empty);
                }
                else if(len == 1)
                {
                    ((MyAction<System.Object,string>)MyHandler)(p_param[0], string.Empty);
                }
                else
                {
                    ((MyAction<System.Object,string>)MyHandler)(p_param[0], p_param[1].ToString());
                }
            }
            else
            {
                ((MyAction<System.Object,string>)MyHandler)(null, string.Empty);
            }
            return true;
        }
        return false;
    }
    public override bool Execute(System.Object p_param0, string p_param1)
    {
        if(MyHandler != null)
        {
            ((MyAction<System.Object,string>)MyHandler)(p_param0, p_param1);
            return true;
        }
        return false;
    }
}

public class Int_String_Float_Float_Handler : BaseAction
{
    public Int_String_Float_Float_Handler(System.Delegate act)
    {
        MyHandler = act;
    }
    public Int_String_Float_Float_Handler()
    {
        MyHandler = null;
    }
    public override ParamEnum Ptype()
    {
        return BaseAction.ParamEnum.PARAM_INT_STRING_FLOAT_FLOAT;
    }
    public override bool Execute(System.Object[] p_param)
    {
        if(MyHandler != null)
        {
            if(p_param != null)
            {
                int len = p_param.Length;
                if(len == 0)
                {
                    ((MyAction<int,string,float,float>)MyHandler)(0, string.Empty, 0.0f, 0.0f);
                }
                else if(len == 1)
                {
                    ((MyAction<int,string,float,float>)MyHandler)(Convert.ToInt32(p_param[0]), string.Empty, 0.0f, 0.0f);
                }
                else if(len == 2)
                {
                    ((MyAction<int,string,float,float>)MyHandler)(Convert.ToInt32(p_param[0]), p_param[1].ToString(), 0.0f, 0.0f);
                }
                else if(len == 3)
                {
                    ((MyAction<int,string,float,float>)MyHandler)(Convert.ToInt32(p_param[0]), p_param[1].ToString(), Convert.ToSingle(p_param[2]), 0.0f);
                }
                else
                {
                    ((MyAction<int,string,float,float>)MyHandler)(Convert.ToInt32(p_param[0]), p_param[1].ToString(), Convert.ToSingle(p_param[2]), Convert.ToSingle(p_param[3]));
                }
            }
            else
            {
                ((MyAction<int,string,float,float>)MyHandler)(0, string.Empty, 0.0f, 0.0f);
            }
            return true;
        }
        return false;
    }
    public override bool Execute(int p_param0, string p_param1, float p_param2, float p_param3)
    {
        if(MyHandler != null)
        {
            ((MyAction<int,string,float,float>)MyHandler)(p_param0, p_param1, p_param2, p_param3);
            return true;
        }
        return false;
    }
}
