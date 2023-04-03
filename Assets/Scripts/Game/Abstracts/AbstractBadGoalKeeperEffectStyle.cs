using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractBadGoalKeeperEffectStyle : ScriptableObject
{
    public abstract void BadGoalKeeperTextEffect_first(GameObject obj);

    public abstract void BadGoalKeeperTextEffect_second(GameObject obj);

    public abstract void Stop();
}
