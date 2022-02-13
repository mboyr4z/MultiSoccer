using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;

public class ScorController : MonoBehaviour
{
    [SerializeField] private List<GameObject> skorlar;

    int oyuncuSirasi;
    Vector3 pos;
    
    void Start()
    {
        PlayerPrefs.SetInt("gol",0);
        oyuncuSirasi = PlayerPrefs.GetInt("oyuncuSirasi");
        ObserverManager.obs_gol += golYendi;

        for (int i = 0; i < PhotonNetwork.CurrentRoom.PlayerCount; i++)
        {
            skorlar[i].SetActive(true);
        }
    }

    void golYendi(int golYiyen)
    {
        if (GetComponent<PhotonView>().IsMine && golYiyen == oyuncuSirasi)
        {
            PlayerPrefs.SetInt("gol", PlayerPrefs.GetInt("gol") + 1);
            skorlar[oyuncuSirasi - 1].GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("gol").ToString();
        }

        if (PlayerPrefs.GetInt("gol") == 3)
        {
            print("kaybettin");
        }
    }
}
