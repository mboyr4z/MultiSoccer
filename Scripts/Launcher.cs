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
        
        if (string.IsNullOrEmpty(Data.nickName))
        {
            Invoke("OpenStartPanel", 0.01f);
        }
        else
        {
            MenuManager.Instance.OpenMenu("TitleMenu");
        }
    }

    private void OpenStartPanel()
    {
        MenuManager.Instance.OpenMenu("StartMenu");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }

    public override void OnCreatedRoom()
    {
        MenuManager.Instance.OpenMenu("RoomMenu");
    }


    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        switch (returnCode)
        {
            case 32766:
                om.Text_CreateRoomErrorText.text = "UYARI : ODA ADI, HALİHAZIRDA ZATEN VAR";
                break;
            default:
                break;
        }

    }



    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        om.ErrorCanvas.SetActive(true);
        om.Text_Error.text = "Join Room Failed : " + message;
    }

   
}


