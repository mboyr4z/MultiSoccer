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

        if (Data.IsComeUI == true) // ve UI ekranından geldiysek
        {
            OnJoinedRoom();
            Data.IsComeUI = false;      // oyun ekranına geldiysek tekrar false yaparız
        }
        else
        {
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
        if (!Data.IsComeUI)     // eğer UI dan gelmediysek
        {
            Data.PlayerOrder = PhotonNetwork.CurrentRoom.PlayerCount;
        }

        Data.LeftPlayer = (int) PhotonNetwork.CurrentRoom.MaxPlayers;   // odaya girdiğinde kalanOyuncu değeri Max player kadar olacak

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
        if (Data.AmILose) {
            Debug.LogError("Oyunu kaybederek çıktım");
            
        }
        else
        {
            Debug.LogError("Oyunu kaybetmeden Çıktım");
            Room.Instance.IsWinnerBeenLocal(); //Odadan ayrılırken eğer yenilmemişse, diğer adamlardan birinci var mı kontrol etsin, yoksa zaten daha önceden yenilirken kontrol etmişti
        }


        Room.Instance.DestroyAllInstantinatedObjects();
        IsKnockedOut = true;
        PhotonNetwork.LeaveRoom();      // ayrıl
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnLeftLobby()
    {
        PhotonNetwork.OfflineMode = true;       // tekrar mastera bağlanmasın odadan ayrılınca
    }

}
