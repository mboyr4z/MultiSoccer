using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


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


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)      // Yani UI ekranı ise 
        {
            PlayerPrefs.SetInt("isComeUI", 1);
        }
    }



    void Start()
    {
        time = System.DateTime.Now.ToString();
    }

    
}
