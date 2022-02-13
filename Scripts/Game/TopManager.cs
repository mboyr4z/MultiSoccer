using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class TopManager : MonoBehaviour
{
    PhotonView PV;
    Vector2 kalePos;
    float aci;
    int oyuncuSirasi;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
  

    private void OnEnable()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            CreateBall();
        }
    }

    private void CreateBall()
    {
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "TopController"), new Vector3(0,0,0), Quaternion.identity);
    }
}
