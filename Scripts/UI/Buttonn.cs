using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttonn : MonoBehaviour
{
    [SerializeField] private string menuName;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(OpenMenu);
    }

    private void OpenMenu()
    {
        MenuManager.Instance.OpenMenu(menuName);
    }
}
