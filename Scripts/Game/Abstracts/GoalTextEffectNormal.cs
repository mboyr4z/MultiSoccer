using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu(menuName = "GoalTextEffect/Normal")]
public class GoalTextEffectNormal : AbstractGoalTextEffectStyle
{

    /*DÖNME ÖZELLİKLERİ*/
    [SerializeField] private Vector3 rotateAngle;

    [SerializeField] private float rotateDuration;

    [SerializeField] private Ease rotateEase;

    [SerializeField] private LoopType rotateLoopType;

    [SerializeField] private int rotateRepeat;


    /*bÜYÜME ÖZELLİKLERİ*/

    [SerializeField] private Vector3 newScale;

    [SerializeField] private float scaleDuration;

    [SerializeField] private Ease scaleEase;

    [SerializeField] private LoopType scaleLoopType;

    [SerializeField] private int scaleRepeat;

    
    public override void GoalTextEffect(GameObject obj)
    {
        obj.transform.DORotate(rotateAngle, rotateDuration ).SetEase(rotateEase).SetLoops(rotateRepeat, rotateLoopType).SetId(555);
        obj.transform.DOScale(newScale,scaleDuration).SetEase(scaleEase).SetLoops(scaleRepeat, scaleLoopType).SetId(556);
    }
    public override void Stop()
    {
        DOTween.Kill(555);
        DOTween.Kill(556);
    }
}
