using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractGoalTextEffectStyle : ScriptableObject
{
    public abstract void GoalTextEffects(GameObject obj);

    public abstract void Stop();
}
