using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalTextEffect : Singleton<GoalTextEffect>
{
    [SerializeField] private GameObject goalText;

    [SerializeField] private AbstractGoalTextEffectStyle abstractGoalTextEffectStyle;

    [SerializeField] private float StopDelay;

    public void StartGoalTextEffect()
    {
        abstractGoalTextEffectStyle.GoalTextEffect(goalText);
        Invoke("StopGoalTextEffect",StopDelay);
    }

    private void StopGoalTextEffect()
    {
        abstractGoalTextEffectStyle.Stop();
        transform.localScale = Vector3.zero;
    }

    
}
