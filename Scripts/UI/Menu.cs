using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;

    public void Open()
    {
        //print(gameObject.name + " menüsü açıldı");
        open = true;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        //print(gameObject.name + " menüsü kapandı");
        open = false;
        gameObject.SetActive(false);
    }
}
 