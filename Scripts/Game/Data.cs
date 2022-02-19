using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Data : Singleton<Data>
{

    private string time;

    private int gol;

    private int playerOrder;

    
    public int Gol { 
        get
        {
           return PlayerPrefs.GetInt("gol"+time.ToString());
        }
        set
        {
            PlayerPrefs.SetInt("gol"+time.ToString(),value);
        }
    }

    public int PlayerOrder
    {
        get
        {
            return PlayerPrefs.GetInt("playerOrder" + time.ToString());
        }
        set
        {
            PlayerPrefs.SetInt("playerOrder" + time.ToString(), value);
        }
    }

    void Start()
    {
        time = System.DateTime.Now.ToString();
    }

    
}
