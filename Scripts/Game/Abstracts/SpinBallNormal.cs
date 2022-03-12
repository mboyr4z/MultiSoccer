using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "SpinBall/Normal")]
public class SpinBallNormal : AbstractSpinningBallStyle
{

    [SerializeField] private LoopType loopType;

    [SerializeField] private Ease Firstease;

    [SerializeField] private Ease SecondEase;

    [SerializeField] private Vector3 spinAngle;

    [SerializeField] private float spinTime;

    [SerializeField] private int loopRepeat;

    [SerializeField] private bool IsSecondEase;


    public override void Spin(GameObject obj)
    {
        obj.transform.DORotate(spinAngle, spinTime).SetLoops(loopRepeat, loopType).SetEase(Firstease).SetId(0).OnComplete(() =>
        {
            if (IsSecondEase)
            {
                obj.transform.DORotate(spinAngle, spinTime).SetLoops(loopRepeat, loopType).SetEase(SecondEase).SetId(1);
            }
        });
    }

    public override void Stop()
    {
        DOTween.Kill(0);
        DOTween.Kill(1);
    }
}
