using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }

    /*

   public override void OnConnectedToMaster()
   {
       PhotonNetwork.JoinLobby();
       PhotonNetwork.AutomaticallySyncScene = true;
   }

   public void SetNickName(Text txtNickName)
   {
       PhotonNetwork.NickName = txtNickName.text;
       MenuManager.Instance.OpenMenu("title");
       print(PhotonNetwork.NickName);
   }


   public void CreateRoom()
   {
       if (string.IsNullOrEmpty(roomNameInput.text) )
       {
           return;
       }

       if (int.Parse(MaxPlayerInput.text) < 5 && int.Parse(MaxPlayerInput.text) > 0 )
       {
           RoomOptions roomOptions = new RoomOptions();
           roomOptions.MaxPlayers = (byte)int.Parse(MaxPlayerInput.text);
           PhotonNetwork.CreateRoom(roomNameInput.text,roomOptions);
           MenuManager.Instance.OpenMenu("loading");
       }
       else
       {
           return;
       }

   }

   public override void OnMasterClientSwitched(Player newMasterClient)
   {
       startGameButton.SetActive(PhotonNetwork.IsMasterClient);
       startGameButton.GetComponent<Button>().enabled = false;
       startGameButton.GetComponent<Button>().transform.Find("TMP").GetComponent<TextMeshProUGUI>().text = "Waiting Player";
   }

   public override void OnJoinedRoom()
   {
       PlayerPrefs.SetInt("oyuncuSirasi",PhotonNetwork.CurrentRoom.PlayerCount);
       PlayerPrefs.SetInt("gol", 0);
       MenuManager.Instance.OpenMenu("room");
       roomNameText.text = PhotonNetwork.CurrentRoom.Name;

       Player[] players = PhotonNetwork.PlayerList;

       foreach (Transform child in playerListContent)
       {
           Destroy(child.gameObject);
       }

       for (int i = 0; i < players.Length; i++)
       {
           Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().setup(players[i]);
       }


       startGameButton.SetActive(PhotonNetwork.IsMasterClient);
       if (PhotonNetwork.IsMasterClient)
       {
           if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
           {
               startGameButton.GetComponent<Button>().enabled = true;
               startGameButton.GetComponent<Button>().transform.Find("TMP").GetComponent<TextMeshProUGUI>().text = "Start Game";
           }
           else
           {
               startGameButton.GetComponent<Button>().enabled = false;
               startGameButton.GetComponent<Button>().transform.Find("TMP").GetComponent<TextMeshProUGUI>().text = "Waiting Player";
           }

       }

   }

   public void startGame()
   {
       PhotonNetwork.LoadLevel(1);
   }

   public override void OnCreateRoomFailed(short returnCode, string message)
   {
       errorText.text = "Room Creation Failed : " + message;
       MenuManager.Instance.OpenMenu("error");
   }

   public void LeaveRoom()
   {
       PhotonNetwork.LeaveRoom();
       MenuManager.Instance.OpenMenu("loading");
   }

   public override void OnLeftRoom()
   {
       MenuManager.Instance.OpenMenu("title");
   }

   public void JoinRoom(RoomInfo info)
   {
       PhotonNetwork.JoinRoom(info.Name);
   }

   public override void OnRoomListUpdate(List<RoomInfo> roomList)
   {
       foreach (Transform room in roomListContent)
       {
           Destroy(room.gameObject);
       }


       for (int i = 0; i < roomList.Count; i++)
       {
           if (roomList[i].RemovedFromList)
               continue;
           Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().setup(roomList[i]);
       }

   }

   public override void OnPlayerEnteredRoom(Player newPlayer)
   {
       Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().setup(newPlayer);
       if(PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
       {
           startGameButton.transform.Find("TMP").GetComponent<TextMeshProUGUI>().text = "Start Game";
           startGameButton.GetComponent<Button>().enabled = true;
       }
   }

   public override void OnPlayerLeftRoom(Player otherPlayer)
   {
       if (PhotonNetwork.IsMasterClient)
       {
           startGameButton.GetComponent<Button>().enabled = false;
           startGameButton.GetComponent<Button>().transform.Find("TMP").GetComponent<TextMeshProUGUI>().text = "Waiting Player";
       }
   }*/
}
