using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpinningBallStyle : ScriptableObject
{
    public abstract void Spin(GameObject obj);

    public abstract void Stop();
}
