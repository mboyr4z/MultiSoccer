using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerSpawner : MonoBehaviour
{
    public static Vector3 spawnPoint;

    public GameObject player;

    private PhotonView pv;

    private int playerOrder;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }

    public void SpawnPlayer()
    {
        Invoke("Spawn", 0.3f);
    }

    private void Spawn()
    {
        playerOrder = PlayerPrefs.GetInt("playerOrder");

        if (playerOrder == 1)
        {
            spawnPoint = new Vector3(-8f, 0f, 0f);
        }

        if (playerOrder == 2)
        {
            spawnPoint = new Vector3(8f, 0f, 0f);
        }

        if (playerOrder == 3)
        {
            spawnPoint = new Vector3(0f, -4f, 0f);
        }

        if (playerOrder == 4)
        {
            spawnPoint = new Vector3(0f, 4f, 0f);
        }

        
        GameObject _localPlayer = PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity);
        _localPlayer.GetComponent<PlayerSetup>().IsLocalPlayer();
        _localPlayer.GetComponent<Movement>().enabled = true;
        _localPlayer.GetComponent<Shot>().enabled = true;

    }

}
