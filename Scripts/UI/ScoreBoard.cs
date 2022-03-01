using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ScoreBoard : Singleton<ScoreBoard>
{

    [SerializeField] private List<GameObject> scoreBoardItems;

    public void SetActiveScoreBoardItemsLocal(int playerCount)
    {
        GetComponent<PhotonView>().RPC("RPC_SetActiveScoreBoardItems", RpcTarget.All, playerCount);
    }

    public void SetInfosScoreBoardItemsLocal(string nickName, int level, int gol, int playerOrder)
    {
        GetComponent<PhotonView>().RPC("RPC_SetInfosScoreBoardItems", RpcTarget.All, nickName, level, gol, playerOrder);
    }


    [PunRPC]
    private void RPC_SetActiveScoreBoardItems(int playerCount)
    {
        for (int i = 0; i < playerCount; i++)
        {
            scoreBoardItems[i].SetActive(true);
        }
    }

    [PunRPC]
    private void RPC_SetInfosScoreBoardItems(string nickName,int level, int gol, int playerOrder)        // score boarddaki kişiye ait sıradaki itemin vbilgilerini günceller
    {
        scoreBoardItems[playerOrder - 1].GetComponent<ScoreBoardItem>().Setup(nickName, level, gol,  playerOrder);
    }
}
