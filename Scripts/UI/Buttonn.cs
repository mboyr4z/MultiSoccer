using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonn : MonoBehaviour
{
    [SerializeField] private string menuName;

    private void OnEnable()
    {
        print(this.name + " butonu aktif oldu");
        GetComponent<Button>().onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {
        print(this.name + " butonuna tıklandı");
        MenuManager.Instance.OpenMenu(menuName);
    }
}
