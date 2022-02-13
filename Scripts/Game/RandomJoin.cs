using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;


public class RandomJoin : MonoBehaviourPunCallbacks
{
    private PhotonView pw;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.SendRate = 200;
        PhotonNetwork.SerializationRate = 200;
        pw = GetComponent<PhotonView>();
        
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()

    {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.JoinOrCreateRoom("oda1", new RoomOptions { MaxPlayers = 4 }, TypedLobby.Default);

    }

    public override void OnJoinedRoom()
    {
        PlayerPrefs.SetInt("gol", 0);
        PlayerPrefs.SetInt("oyuncuSirasi", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel(1);
    }

    /*public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("adam girdi");
        print("su anki " + PhotonNetwork.CurrentRoom.PlayerCount);

        if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers  )
        {
            PhotonNetwork.LoadLevel(1);
        }
    }*/

   


}
