using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    private ObjectManager om;

    private void Awake()
    {
        om = ObjectManager.Instance;
        Instance = this;
    }

    void Start()
    {
        Data.isComeUI = true;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.SendRate = 120;
        PhotonNetwork.SerializationRate = 60;
    }







    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Invoke("OpenStartPanel", 0.01f);
    }

    private void OpenStartPanel()
    {
        MenuManager.Instance.OpenMenu("startPanel");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }

    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("oda oluşturulamadı" + returnCode.ToString());
        om.ErrorCanvas.SetActive(true);
        om.Text_Error.text = "Create Room Failed : " + message;
    }


    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        om.ErrorCanvas.SetActive(true);
        om.Text_Error.text = "Join Room Failed : " + message;
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        om.ErrorCanvas.SetActive(true);
        om.Text_Error.text = "Join Room Failed : " + message;
    }
}


