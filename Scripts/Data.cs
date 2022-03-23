using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public static class Data
{

    public static int gol;

    public static int playerOrder;

    public static int leftPlayer;

    public static bool amILose = false;

    public static bool isComeUI = false;

    public static bool isComeGame = false;

    public static Color color;

    public static string nickName = string.Empty;

    public static Color gray = new Color(164,191,219,255) / 255;
    public static Color pink = new Color(255, 54, 114, 255) / 255;
    public static Color blue = new Color(25, 199, 236, 255) / 255;
    public static Color yellow = new Color(226, 231, 132, 255) / 255;
    public static Color KnockedOut = new Color(255, 0, 0,255) / 255;


    public static void SetDataColor()  // oyuna katılındığında kale ve player için renk belli olur
    {
        switch (playerOrder)
        {
            case 1:
                color = gray;
                break;
            case 2:
                color = pink;
                break;
            case 3:
                color = blue;
                break;
            case 4:
                color = yellow;
                break;
            default:
                color = gray;
                break;
        }
    }
}

