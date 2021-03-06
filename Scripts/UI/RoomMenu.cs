using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class RoomMenu : MonoBehaviourPunCallbacks
{
    private ObjectManager om;


    private void Start()
    {
        om = ObjectManager.Instance;
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }



    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(om.pre_PlayerListItemPrefab, om.PlayerListContent).GetComponent<PlayerListItem>().setup(newPlayer);
        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
            om.Button_StartGame.transform.Find("Text").GetComponent<Text>().text = "Start Game";
            om.Button_StartGame.GetComponent<Button>().enabled = true;
        }
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        print("biri odadan ayrıldı");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsVisible = true;
            om.Button_StartGame.GetComponent<Button>().enabled = false;
            om.Button_StartGame.GetComponent<Button>().transform.Find("Text").GetComponent<Text>().text = "Waiting Player";
        }
    }
    public override void OnJoinedRoom()
    {
        Data.PlayerOrder = PhotonNetwork.CurrentRoom.PlayerCount;       // playerOrder belli oldu


        Player[] players = PhotonNetwork.PlayerList;


        foreach (Transform child in om.PlayerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(om.pre_PlayerListItemPrefab, om.PlayerListContent).GetComponent<PlayerListItem>().setup(players[i]);
        }


        om.Button_StartGame.SetActive(PhotonNetwork.IsMasterClient);
        if (PhotonNetwork.IsMasterClient)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                om.Button_StartGame.GetComponent<Button>().enabled = true;
                om.Button_StartGame.GetComponent<Button>().transform.Find("Text").GetComponent<Text>().text = "Start Game";
            }
            else
            {
                om.Button_StartGame.GetComponent<Button>().enabled = false;
                om.Button_StartGame.GetComponent<Button>().transform.Find("Text").GetComponent<Text>().text = "Waiting Player";
            }

        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        om.Button_StartGame.SetActive(PhotonNetwork.IsMasterClient);
        om.Button_StartGame.GetComponent<Button>().enabled = false;
        om.Button_StartGame.GetComponent<Button>().transform.Find("Text").GetComponent<Text>().text = "Waiting Player";
    }
}
