using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallSpawner : MonoBehaviour
{

    public GameObject ball;

    private PhotonView pv;

    void Start()
    {
        pv = GetComponent<PhotonView>();
    }


    public void SpawnBall()
    {
        Invoke("Spawn", 0.3f);
    }


    private void Spawn()
    {
         GameObject.Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
