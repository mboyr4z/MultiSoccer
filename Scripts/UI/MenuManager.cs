using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    
    [SerializeField] private Menu[] menus;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu(string menuName)
    {
//        print(menuName + "  verisi geldi");
        for (int i = 0; i < menus.Length; i++)
        {
            //print("for");
            if(menus[i].menuName == menuName)
            {
                //print("if gelenle eşit");
                menus[i].Open();
            }
            else if(menus[i].open)
            {
               // print("Açik olan kapatıldı");
                CloseMenu(menus[i]);
            }
        }
    }



    public void OpenMenu(Menu menu)
    {
        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
