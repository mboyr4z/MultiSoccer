using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GoalSpawner : MonoBehaviour
{
    public static GameObject localGoal;

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
        switch (Data.PlayerOrder)
        {
            case 1:
                spawnPoint = new Vector2(-9.31f, -4.4f);
                angle = 137;
                break;

            case 2:
                spawnPoint = new Vector2(9.46f,4.28f);
                angle = -45;
                break;

            case 3:
                spawnPoint = new Vector2(-9.31f, 4.34f);
                angle = 45;
                break;

            case 4:
                spawnPoint = new Vector2(9.44f, -4.41f);
                angle = -135;
                break;

            default:
                spawnPoint = new Vector2(-9.95f, -4.4f);
                angle = 135;
                break;
        }
        

      
        
        localGoal = PhotonNetwork.Instantiate(goal.name, spawnPoint, Quaternion.Euler(0, 0, angle));
        localGoal.GetComponent<Goal>().enabled = true;
        localGoal.GetComponent<Goal>().Setup(gameObject);

        Room.Instance.SetGoalsColorsLocal();        // kale oluşturulduktan sonra herkes kalelerine tekrar renk versin
    }
}
