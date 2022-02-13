using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class kaleManager : MonoBehaviour
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
        createKale();
    }

    void createKale()
    {
        oyuncuSirasi = PlayerPrefs.GetInt("oyuncuSirasi");
        print(oyuncuSirasi);
        if (oyuncuSirasi == 1)
        {
            kalePos = new Vector2(-9.95f, 0f);
            aci = 90;
        }

        if (oyuncuSirasi == 2)
        {
            kalePos = new Vector2(9.95f, 0f);
            aci = 270;
        }

        if (oyuncuSirasi == 3)
        {
            kalePos = new Vector2(0f, -5.22f);
            aci = 180;
        }

        if (oyuncuSirasi == 4)
        {
            kalePos = new Vector2(0f, 5.22f);
            aci = 0;
        }
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "KaleController"), kalePos, Quaternion.Euler(0, 0, aci));
    }
}
