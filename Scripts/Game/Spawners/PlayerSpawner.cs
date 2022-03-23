using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerSpawner : MonoBehaviour
{
    public static Vector3 spawnPoint;

    public GameObject player;

    public static GameObject localPlayer;


    public void SpawnPlayer()
    {
        Invoke("Spawn", 0.3f);
    }

    private void Spawn()
    {
        switch (Data.PlayerOrder){
            case 1:
                spawnPoint = new Vector3(-8.98f, -3.93f, 0f);
                break;
            case 2:
                spawnPoint = new Vector3(8.97f, 3.98f, 0f);
                break;
            case 3:
                spawnPoint = new Vector3(-8.89f, 3.92f, 0f);
                break;
            case 4:
                spawnPoint = new Vector3(9.09f, -4f, 0f);
                break;
            default:
                spawnPoint = new Vector3(-8.98f, -3.93f, 0f);
                break;
        }
        
        localPlayer = PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity);
        localPlayer.GetComponent<PlayerSetup>().IsLocalPlayer();

    }

}
