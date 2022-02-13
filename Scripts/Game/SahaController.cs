using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SahaController : MonoBehaviourPunCallbacks
{
    [SerializeField] List<GameObject> kaleYerleri;

    private void Start()
    {
        kaleYeriAc(PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void kaleYeriAc(int kisiSayisi)
    {
        for (int i = 0; i < kisiSayisi; i++)
        {
            kaleYerleri[i].SetActive(false);
        }
    }

    public void anaMenuyeDon()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            PhotonNetwork.LeaveRoom();
            MenuManager.Instance.OpenMenu("Loading");

        }
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }


    
}
