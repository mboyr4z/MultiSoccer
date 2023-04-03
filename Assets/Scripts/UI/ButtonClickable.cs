using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickable : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(ButtonSound);
    }
    private void ButtonSound()
    {
        SoundManager.Instance.PlaySound("Button");
    }

}
