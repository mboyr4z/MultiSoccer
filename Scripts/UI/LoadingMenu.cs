using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class LoadingMenu : MonoBehaviour
{

    [SerializeField] private AbstractSpinningBallStyle SpinningBallStyle;

    [SerializeField] private AbstractBlurStyle BlurImageStyle;

    [SerializeField] private TextMeshProUGUI TMP_Loading;

    [SerializeField] private GameObject SpinningBall;

    [SerializeField] private Image BluredFootballArea;

    private int textCtr = 0;



    private void OnEnable()
    {
        BlurImageStyle.Blur(BluredFootballArea);
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
