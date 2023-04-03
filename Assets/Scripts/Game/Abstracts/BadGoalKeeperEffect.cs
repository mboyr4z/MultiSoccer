using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

[CreateAssetMenu(menuName = "GoalEffects/BadGoalKeeperText/Normal")]
public class BadGoalKeeperEffect : AbstractBadGoalKeeperEffectStyle
{

    [SerializeField] private float duration;

    [SerializeField] private Ease ease;

    [SerializeField] private LoopType loopType;

    [SerializeField] private int repeat;



    public override void BadGoalKeeperTextEffect_first(GameObject obj)
    {
        obj.transform.position = new Vector3(-520, obj.transform.position.y, obj.transform.position.z);
        obj.transform.DOLocalMoveX(0, duration).SetEase(ease).SetLoops(repeat, loopType).SetId(431);
    }

 

    public override void Stop()
    {
        DOTween.Kill(431);
        DOTween.Kill(432);
    }

    [SerializeField] private float s_duration;

    [SerializeField] private Ease s_esae;

    [SerializeField] private LoopType s_loopType;

    [SerializeField] private int s_repeat;


    public override void BadGoalKeeperTextEffect_second(GameObject obj)
    {
        obj.transform.DOLocalMoveX(470, duration).SetEase(ease).SetLoops(repeat, loopType).SetId(432).OnComplete(() =>
        {
            Stop();
        });
    }
}
