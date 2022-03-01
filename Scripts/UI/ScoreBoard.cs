using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ScoreBoard : Singleton<ScoreBoard>
{

    [SerializeField] private List<GameObject> scoreBoardItems;

    public void SetActiveScoreBoardItemsLocal(int playerCount)
    {
        print(playerCount);
        GetComponent<PhotonView>().RPC("RPC_SetActiveScoreBoardItems", RpcTarget.All, playerCount);
    }


    [PunRPC]
    private void RPC_SetActiveScoreBoardItems(int playerCount)
    {
        for (int i = 0; i < playerCount; i++)
        {
            scoreBoardItems[i].SetActive(true);
        }
    }
}
