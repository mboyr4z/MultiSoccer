using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


[CreateAssetMenu(menuName = "Blur/Normal")]
public class ImageBlurNormal : AbstractBlurStyle
{

    [SerializeField] private Color color;

    [SerializeField] private LoopType loopType;

    [SerializeField] private Ease Firstease;

    [SerializeField] private Ease SecondEase;

    [SerializeField] private float blurTime;

    [SerializeField] private int loopRepeat;

    [SerializeField] private bool IsSecondEase;
    public override void Blur(Image image)
    {
        image.DOColor(color, blurTime).SetLoops(loopRepeat, loopType).SetEase(Firstease).SetId(0).OnComplete(() =>
        {
            if (IsSecondEase)
            {
                image.DOColor(color, blurTime).SetLoops(loopRepeat, loopType).SetEase(SecondEase).SetId(1);
            }
        });
    }

    public override void Stop()
    {
        DOTween.Kill(0);
        DOTween.Kill(1);
    }
}
