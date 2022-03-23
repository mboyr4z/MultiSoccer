using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public static class Data
{

    private static int gol;

    private static int playerOrder;

    private static int leftPlayer;

    private static bool amILose = false;

    private static bool ısComeUI = false;

    private static Color color;

    private static string nickName = string.Empty;

    public static Color gray = new Color(164,191,219,255) / 255;
    public static Color pink = new Color(255, 54, 114, 255) / 255;
    public static Color blue = new Color(25, 199, 236, 255) / 255;
    public static Color yellow = new Color(226, 231, 132, 255) / 255;
    public static Color KnockedOut = new Color(255, 0, 0,255) / 255;

    public static int Gol { get => gol; set => gol = value; }
    public static int PlayerOrder { get => playerOrder; set => playerOrder = value; }
    public static int LeftPlayer { get => leftPlayer; set => leftPlayer = value; }
    public static bool AmILose { get => amILose; set => amILose = value; }
    public static bool IsComeUI { get => ısComeUI; set => ısComeUI = value; }
    public static Color Color { get => color; set => color = value; }
    public static string NickName { get => nickName; set => nickName = value; }

    public static void SetDataColor()  // oyuna katılındığında kale ve player için renk belli olur
    {
        switch (PlayerOrder)
        {
            case 1:
                Color = gray;
                break;
            case 2:
                Color = pink;
                break;
            case 3:
                Color = blue;
                break;
            case 4:
                Color = yellow;
                break;
            default:
                Color = gray;
                break;
        }
    }
}

