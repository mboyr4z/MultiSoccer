using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.IO;

public class PlayerSpawner : MonoBehaviour
{
    PhotonView PV;
    Vector3 playerPos;
    int oyuncuSirasi;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void OnEnable()
    {
       // if (PV.IsMine)
        //{
            createController();
        //}
    }

    void createController()
    {
        print("Oyuncu Uretiliyor");
        oyuncuSirasi = PlayerPrefs.GetInt("oyuncuSirasi");
        if (oyuncuSirasi == 1)
        {
            playerPos = new Vector2(-8f,0f);
        }

        if (oyuncuSirasi == 2)
        {
            playerPos = new Vector2(8f, 0f);
        }

        if (oyuncuSirasi == 3 )
        {
            playerPos = new Vector2(0f, 4f);
        }

        if (oyuncuSirasi == 4)
        {
            playerPos = new Vector2(0f, -4f);
        }
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs","PlayerController"), playerPos, Quaternion.identity, 0);
    }
}
