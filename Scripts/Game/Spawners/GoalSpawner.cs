using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GoalSpawner : MonoBehaviour
{

    public static Vector3 spawnPoint;

    public GameObject goal;

    private PhotonView pv;

    private float angle;
    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    public void SpawnGoal()
    {
        Invoke("Spawn", 0.3f);
    }

   
    private void Spawn()
    {
        switch (Data.playerOrder)
        {
            case 1:
                spawnPoint = new Vector2(-9.95f, 0f);
                angle = 90;
                break;

            case 2:
                spawnPoint = new Vector2(9.95f, 0f);
                angle = 270;
                break;

            case 3:
                spawnPoint = new Vector2(0f, -5.22f);
                angle = 180;
                break;

            case 4:
                spawnPoint = new Vector2(0f, 5.22f);
                angle = 0;
                break;

            default:
                spawnPoint = new Vector2(-9.95f, 0f);
                angle = 90;
                break;
        }
        

      
        
        GameObject _localGoal = PhotonNetwork.Instantiate(goal.name, spawnPoint, Quaternion.Euler(0, 0, angle));
        _localGoal.GetComponent<Goal>().enabled = true;
        _localGoal.GetComponent<Goal>().Setup(gameObject);

        Room.Instance.SetGoalsColorsLocal();        // kale oluşturulduktan sonra herkes kalelerine tekrar renk versin
    }
}
