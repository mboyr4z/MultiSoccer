using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;

public class RandomJoin : MonoBehaviourPunCallbacks
{

    public static RandomJoin instance;

    public static float time;

    private int sayac = 0;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        print("Random Join Start");
        // PlayerPrefs.SetInt("isComeUI", 0);
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;
        if (PlayerPrefs.GetInt("isComeUI") == 1) // ve UI ekranından geldiysek
        {
            PlayerPrefs.SetInt("isComeUI", 0);
            print("GOL : " + Data.Instance.Gol);
            print("PlayerOrder : " + Data.Instance.PlayerOrder);
            OnJoinedRoom();
            print("UI dan geldik");
        }
        else
        {
            Data.Instance.Gol = 0;      //odaya katıldığında gol ve oyuncu sırası ayarlanır

            PhotonNetwork.ConnectUsingSettings();
            print("Direk başladık");
        }
    }


    public override void OnConnectedToMaster()
    {
        TextManager.Instance.UzerineYaz("CONNECTED SERVER.");
        if(sayac == 0)
        {
            PhotonNetwork.JoinLobby();
        }

        TextManager.Instance.UzerineYaz("CONNECTING LOBBY...");
    }

    public override void OnJoinedLobby()
    {
        print("lobiye katıldı");
        TextManager.Instance.UzerineYaz("CONNECTED LOBBY.");
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
        TextManager.Instance.UzerineYaz("CONNECTING ROOM...");

    }

    public override void OnJoinedRoom()
    {
        Data.Instance.PlayerOrder = PhotonNetwork.CurrentRoom.PlayerCount;
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;
        TextManager.Instance.UzerineYaz("CONNECTED ROOM...");

        print("Üretiliyor");
      
        GetComponent<PlayerSpawner>().SpawnPlayer();        // oyuncu üret
        GetComponent<BallSpawner>().SpawnBall();            // top üret


    }

    public void LeaveRoom()
    {
        sayac++;
        ScoreBoard.Instance.SetCloseScoreBoardItemForLeavedPlayerLocal(Data.Instance.PlayerOrder);
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LeaveLobby();
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.OfflineMode = true;       // tekrar mastera bağlanmasın odadan ayrılınca
    }

}
