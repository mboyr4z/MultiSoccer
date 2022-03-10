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
        switch (Data.playerOrder){
            case 1:
                spawnPoint = new Vector3(-8f, 0f, 0f);
                break;
            case 2:
                spawnPoint = new Vector3(8f, 0f, 0f);
                break;
            case 3:
                spawnPoint = new Vector3(0f, -4f, 0f);
                break;
            case 4:
                spawnPoint = new Vector3(0f, 4f, 0f);
                break;
            default:
                spawnPoint = new Vector3(-8f, 0f, 0f);
                break;
        }
        
        localPlayer = PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity);
        localPlayer.GetComponent<PlayerSetup>().IsLocalPlayer();

    }

}
