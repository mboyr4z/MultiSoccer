using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObserverManager : MonoBehaviour
{
    public static Action<int> obs_gol;

    public static Action obs_oyunBasladi;
}
