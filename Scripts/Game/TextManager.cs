using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : Singleton<TextManager>
{
    private Text alan;
    private void Start()
    {
        alan = GetComponent<Text>();
    }
    public void Ekle(string yazi)
    {
        alan.text = alan.text +" " +  yazi + " ";
    }

    public void UzerineYaz(string yazi)
    {
        alan.text = " " + yazi;
    }
}
