using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


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
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;

        if (Data.isComeUI == true) // ve UI ekranından geldiysek
        {
            OnJoinedRoom();
            Data.isComeUI = false;
        }
        else
        {
            Data.gol = 0;      //odaya katıldığında gol ve oyuncu sırası ayarlanır
            PhotonNetwork.ConnectUsingSettings();
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
        TextManager.Instance.UzerineYaz("CONNECTED LOBBY.");
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);
        TextManager.Instance.UzerineYaz("CONNECTING ROOM...");

    }

    public override void OnJoinedRoom()
    {
        if (!Data.isComeUI)     // eğer UI dan gelmediysek
        {
            Data.playerOrder = PhotonNetwork.CurrentRoom.PlayerCount;
        }

        
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;
        //TextManager.Instance.UzerineYaz("CONNECTED ROOM...");

        TextManager.Instance.Ekle("ÜRETİLİYOR ");

        GetComponent<PlayerSpawner>().SpawnPlayer();        // oyuncu üret
        GetComponent<BallSpawner>().SpawnBall();            // top üret


    }

    public void LeaveRoom()
    {
        sayac++;
        ScoreBoard.Instance?.SetCloseScoreBoardItemForLeavedPlayerLocal(Data.playerOrder);      // odadan ayrılırken scoreboarddan ismini sil
        PhotonNetwork.LeaveRoom();      // ayrıl

    }

    

    public override void OnLeftRoom()
    {
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene(0);
        
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.OfflineMode = true;       // tekrar mastera bağlanmasın odadan ayrılınca
    }

}
