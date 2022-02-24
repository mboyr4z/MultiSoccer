using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private string menuName;
    private void Start()
    {
        
    }

    private void OpenMenu()
    {
        MenuManager.Instance.OpenMenu(menuName);
    }
}
