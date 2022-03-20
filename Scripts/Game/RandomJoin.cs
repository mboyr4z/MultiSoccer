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

    private bool IsKnockedOut = false;

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
        if(!IsKnockedOut)
        {
            PhotonNetwork.JoinLobby();
        }

        TextManager.Instance.UzerineYaz("CONNECTING LOBBY...");
    }

    public override void OnJoinedLobby()
    {
        TextManager.Instance.UzerineYaz("CONNECTED LOBBY.");
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 4, CleanupCacheOnLeave = false }, TypedLobby.Default);
        TextManager.Instance.UzerineYaz("CONNECTING ROOM...");

    }

    public override void OnJoinedRoom()
    {
        if (!Data.isComeUI)     // eğer UI dan gelmediysek
        {
            Data.playerOrder = PhotonNetwork.CurrentRoom.PlayerCount;
        }

        Data.leftPlayer = (int) PhotonNetwork.CurrentRoom.MaxPlayers;   // odaya girdiğinde kalanOyuncu değeri Max player kadar olacak

        Data.SetDataColor();        // OYUNA GİRİLDİĞİNDE RENK BELLİ OLSUN

        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;
        //TextManager.Instance.UzerineYaz("CONNECTED ROOM...");

        TextManager.Instance.Ekle("ÜRETİLİYOR ");

        GetComponent<PlayerSpawner>().SpawnPlayer();        // oyuncu üret
        GetComponent<BallSpawner>().SpawnBall();            // top üret
    }


    public void LeaveRoom()
    {
        Room.Instance.DestroyAllInstantinatedObjects();
        IsKnockedOut = true;
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

    public override void OnPlayerLeftRoom(Player otherPlayer)       // birisi odadan ayrıldığında kazanan belli oluyor mu diye kontrol et
    {
        Room.Instance.IsWinnerBeenGlobal();
    }
}
