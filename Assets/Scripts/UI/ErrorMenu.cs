using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMenu : MonoBehaviour
{

    [SerializeField] private Button btn_ok;

    private ObjectManager om;
    void Start()
    {
        om = ObjectManager.Instance;
        btn_ok.GetComponent<Button>().onClick.AddListener(close);
    }

    private void close()
    {
        om.ErrorCanvas.SetActive(false);
    }
}
