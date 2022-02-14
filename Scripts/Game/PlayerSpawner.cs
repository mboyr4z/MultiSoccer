using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class PlayerSpawner : MonoBehaviour
{
    PhotonView pv;

    public GameObject player;

    public GameObject top;

    public static Vector3 spawnPoint;

    int oyuncuSirasi;

    private void Awake()
    {
        pv = GetComponent<PhotonView>();
    }


    void createController()
    {
        oyuncuSirasi = PlayerPrefs.GetInt("oyuncuSirasi");
        if (oyuncuSirasi == 1)
        {
            spawnPoint = new Vector3(-8f,0f,0f);
        }

        if (oyuncuSirasi == 2)
        {
            spawnPoint = new Vector3(8f, 0f, 0f);
        }

        if (oyuncuSirasi == 3 )
        {
            spawnPoint = new Vector3(0f, 4f, 0f);
        }

        if (oyuncuSirasi == 4)
        {
            spawnPoint = new Vector3(0f, -4f, 0f);
        }
        PhotonNetwork.Instantiate(player.name, spawnPoint, Quaternion.identity, 0);
    }
}
