using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingMenu : MonoBehaviour
{

    [SerializeField] private AbstractSpinningBallStyle SpinningBallStyle;

    [SerializeField] private TextMeshProUGUI TMP_Loading;

    [SerializeField] private GameObject SpinningBall;


    private void OnEnable()
    {
        SpinningBallStyle.Spin(SpinningBall);       // ilgili döndğrme stili ile topu döndür
    }
    private void OnDisable()
    {
        SpinningBallStyle.Stop();
    }


}
