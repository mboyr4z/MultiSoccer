using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;


public class RandomJoin : MonoBehaviourPunCallbacks
{
    void Start()
    {
        TextManager.Instance.UzerineYaz("OFFLINE");
        PhotonNetwork.ConnectUsingSettings();
        TextManager.Instance.UzerineYaz("CONNECTING SERVER...");
    }

    public override void OnConnectedToMaster()
    {
        TextManager.Instance.UzerineYaz("CONNECTED SERVER.");
        PhotonNetwork.JoinLobby();
        TextManager.Instance.UzerineYaz("CONNECTING LOBBY...");
    }

    public override void OnJoinedLobby()
    {
        TextManager.Instance.UzerineYaz("CONNECTED LOBBY.");
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
        TextManager.Instance.UzerineYaz("CONNECTING ROOM...");

    }

    public override void OnJoinedRoom()
    {
        TextManager.Instance.UzerineYaz("CONNECTED ROOM...");
        PlayerPrefs.SetInt("gol", 0);
        PlayerPrefs.SetInt("playerOrder", PhotonNetwork.CurrentRoom.PlayerCount);

        GetComponent<PlayerSpawner>().SpawnPlayer();
        
        
    }

    
}
