﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class RandomJoin : MonoBehaviourPunCallbacks
{

    public static RandomJoin instance;

    int sayac = 0;

    private void Awake()
    {
        instance = this;
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1 )    // Game ekranındaysak 
        {
            if (PlayerPrefs.GetInt("isComeUI") == 1 ) // ve UI ekranından geldiysek
            {
                PlayerPrefs.SetInt("isComeUI", 0);
            }
            else
            {
                print("Direk HGame ile başladık");
            }
            
        }
        
    }

    public static float time;
    void Start()
    {
        TextManager.Instance.UzerineYaz("OFFLINE");
        // burada
        TextManager.Instance.UzerineYaz("CONNECTING SERVER...");
    }

    public void ConnectServer()
    {
        PhotonNetwork.ConnectUsingSettings();
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

        PhotonNetwork.SendRate = 20;
        PhotonNetwork.SerializationRate = 10;
        TextManager.Instance.UzerineYaz("CONNECTED ROOM...");

        Data.Instance.Gol = 0;      //odaya katıldığında gol ve oyuncu sırası ayarlanır
        Data.Instance.PlayerOrder = PhotonNetwork.CurrentRoom.PlayerCount;
      
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
