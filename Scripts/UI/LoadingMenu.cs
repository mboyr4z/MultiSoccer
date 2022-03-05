using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingMenu : MonoBehaviour
{

    [SerializeField] private AbstractSpinningBallStyle SpinningBallStyle;

    [SerializeField] private TextMeshProUGUI TMP_Loading;

    [SerializeField] private GameObject SpinningBall;

    private int textCtr = 0;


    private void OnEnable()
    {
        SpinningBallStyle.Spin(SpinningBall);       // ilgili döndğrme stili ile topu döndür
        InvokeRepeating("LoadingTextRepeater",0.0f,0.4f);
    }

    private void LoadingTextRepeater()
    {

        textCtr++;
        switch (textCtr % 3)
        {
            case 0:
                TMP_Loading.text = "Loading.";
                break;
            case 1:
                TMP_Loading.text = "Loading..";
                break;
            case 2:
                TMP_Loading.text = "Loading...";
                break;
            default:
                TMP_Loading.text = "Loading.";
                break;
        }
    }
    private void OnDisable()
    {
        SpinningBallStyle.Stop();
    }


}
