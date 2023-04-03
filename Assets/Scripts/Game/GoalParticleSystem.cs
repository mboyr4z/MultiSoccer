using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalParticleSystem : Singleton<GoalParticleSystem>
{

    [SerializeField] private float stopDelay;

    private ParticleSystem ps;



    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    public void StartParticalSystem()
    {
        ps.Play();
        Invoke("StopParticalSystem", stopDelay);
    }

    public void StopParticalSystem()
    {
        ps.Stop();
    }
}
