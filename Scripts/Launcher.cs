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
        PhotonNetwork.ConnectUsingSettings();
    }

    

   public override void OnConnectedToMaster()
   {
       PhotonNetwork.JoinLobby();
       PhotonNetwork.AutomaticallySyncScene = true;
   }

    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("startPanel");
    }


 
   public override void OnCreateRoomFailed(short returnCode, string message)
   {
       ObjectManager.Instance.Text_Error.text = "Room Creation Failed : " + message;
       MenuManager.Instance.OpenMenu("error");
   }

   public void JoinRoom(RoomInfo info)
   {
       PhotonNetwork.JoinRoom(info.Name);
   }



 

}
