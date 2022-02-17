using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Stadium : Singleton<Stadium>
{
    [SerializeField] List<GameObject> Goals;

    public void OpenTriggerGoalLocal()
    {
        GetComponent<PhotonView>().RPC("OpenTriggerGoalGlobal", RpcTarget.All, null);
    }

    [PunRPC]
    private void OpenTriggerGoalGlobal()
    {
        int playerCount = 0;
        foreach (var playerObject in GameObject.FindGameObjectsWithTag("player"))       // oyuncu sayısını bulur
        {
            playerCount++;
        }

        for (int i = 0; i < playerCount; i++)       // oyuncu sayısına kadar olan kalelerin triggerlarını açar
        {
            Goals[i].GetComponent<BoxCollider2D>().isTrigger = true;
        }



        TextManager.Instance.UzerineYaz(playerCount + " kisi var.");
    }
    
}
