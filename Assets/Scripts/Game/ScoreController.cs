using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;

public class ScoreController : Singleton<ScoreController>
{
    [SerializeField] public List<GameObject> Scores;


    public void SetScorsLocal()
    {
        GetComponent<PhotonView>().RPC("SetScorsGlobal", RpcTarget.All, null);
    }

    [PunRPC]
    private void SetScorsGlobal()
    {
        int playerCount = 0;
        foreach (var playerObject in GameObject.FindGameObjectsWithTag("player"))
        {
            playerCount++;
        }

        for (int i = 0; i < playerCount; i++)
        {
            Scores[i].SetActive(true);
        }
    }
}
