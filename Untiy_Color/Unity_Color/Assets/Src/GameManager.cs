using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using yijianyouxie.Log;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public static int ScreenWidth = 640;
    public static int ScreenHeight = 1136;

    //µ±Ç°¹Ø¿¨
    private int _currLevel = 1;
    public int CurrLevel
    {
        get
        {
            return _currLevel;
        }
        set
        {
            _currLevel = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        EventManager.RegistDelegate(DataEvent.TableLoaded, TableLoaded);
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void TableLoaded(object[] param)
    {
        LogSystem.Error("====CurrLevel = {0}", CurrLevel);
        EventManager.SendEvent(DataEvent.StartGameWithLevel, CurrLevel);
    }
}
