using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GoalSpawner : MonoBehaviour
{

    public static Vector3 spawnPoint;

    public GameObject goal;

    private PhotonView pv;

    private int playerOrder;

    private float angle;
    

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    public void SpawnGoal()
    {
        Invoke("Spawn", 0.3f);
    }

    void Spawn()
    {
        playerOrder = PlayerPrefs.GetInt("playerOrder");

        if (playerOrder == 1)
        {
            spawnPoint = new Vector2(-9.95f, 0f);
            angle = 90;
        }

        if (playerOrder == 2)
        {
            spawnPoint = new Vector2(9.95f, 0f);
            angle = 270;
        }

        if (playerOrder == 3)
        {
            spawnPoint = new Vector2(0f, -5.22f);
            angle = 180;
        }

        if (playerOrder == 4)
        {
            spawnPoint = new Vector2(0f, 5.22f);
            angle = 0;
        }
        GameObject _localGoal = PhotonNetwork.Instantiate(goal.name, spawnPoint, Quaternion.Euler(0, 0, angle));
        _localGoal.GetComponent<Goal>().enabled = true;
    }
}
