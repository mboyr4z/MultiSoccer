using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.IO;

public class Room : Singleton<Room>
{
    private PhotonView pv;

    private void Start()
    {
       
        Data.Gol = 0;
        Data.AmILose = false;

        pv = GetComponent<PhotonView>();
        //Debug.LogError("Odaya Girerken Left Player : " + Data.LeftPlayer);
    }

    public void IsWinnerBeenLocal()
    {
        //Debug.LogError("Kazanan var mı diye bağırdım");
        pv.RPC(nameof(IsWinnerBeenGlobal), RpcTarget.All, null);
    }

    [PunRPC]
    private void IsWinnerBeenGlobal()
    {
        //Debug.LogError("Duyduk");
        Data.LeftPlayer--;
        if (Data.LeftPlayer == 1 && !Data.AmILose)        // O ZAMAN tek ben hayatta kaldım
        {
            //Debug.LogError("Ben Kazanmışım");
            pv.RPC(nameof(TheWinnerBeen), RpcTarget.All, PhotonNetwork.NickName);
        }
    }

    [PunRPC]
    private void TheWinnerBeen(string nickName)
    {
        MenuManager.Instance.OpenMenu("WinPanel");
        WinPanel.Instance.SetWinnerNameLocal(nickName);
    }

    public void SetGoalsColorsLocal()
    {
        pv.RPC("SetGoalsColorsGlobal", RpcTarget.All, null);
    }

    [PunRPC]
    private void SetGoalsColorsGlobal()
    {
        foreach (var goalObject in GameObject.FindGameObjectsWithTag("Goal"))
        {
            switch ((int)(goalObject.GetComponent<PhotonView>().ViewID / 1000))
            {
                case 1:
                    goalObject.GetComponent<SpriteRenderer>().color = Data.gray;
                    break;
                case 2:
                    goalObject.GetComponent<SpriteRenderer>().color = Data.pink;
                    break;

                case 3:
                    goalObject.GetComponent<SpriteRenderer>().color = Data.blue;
                    break;

                case 4:
                    goalObject.GetComponent<SpriteRenderer>().color = Data.yellow;
                    break;

                default:
                    goalObject.GetComponent<SpriteRenderer>().color = Data.gray;
                    break;

            }
        }
    }

    public void SetPlayersColorsLocal()
    {
        pv.RPC("SetPlayersColorsGlobal", RpcTarget.All, null);
    }

    public void DestroyAllInstantinatedObjects()
    {
        ScoreBoard.Instance?.SetCloseScoreBoardItemForLeavedPlayerLocal(Data.PlayerOrder);      // odadan ayrılırken scoreboarddan ismini sil

        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))        // odadan ayrılırken sadece kendine ait olan playeri sil
        {
            if (obj.name.Contains("Clone") && obj.GetComponent<PhotonView>().IsMine && obj.tag == "player")
            {
                obj.GetComponent<InstantinatedPhotonObject>().DestroyInstantinatedObjectLocal();
            }
        }
    }


    [PunRPC]
    private void SetPlayersColorsGlobal()
    {
        foreach (var playerObject in GameObject.FindGameObjectsWithTag("player"))
        {
            switch ((int)(playerObject.GetComponent<PhotonView>().ViewID / 1000))
            {
                case 1:
                    playerObject.GetComponent<MyPlayer>().arkaPlan.color = Data.gray;
                    break;
                case 2:
                    playerObject.GetComponent<MyPlayer>().arkaPlan.color = Data.pink;
                    break;

                case 3:
                    playerObject.GetComponent<MyPlayer>().arkaPlan.color = Data.blue;
                    break;

                case 4:
                    playerObject.GetComponent<MyPlayer>().arkaPlan.color = Data.yellow;
                    break;

                default:
                    playerObject.GetComponent<MyPlayer>().arkaPlan.color = Data.gray;
                    break;

            }
        }
    }

    public void SetPlayersNameLocal()      //  her oyuncu localinde isimleri düzenlesin
    {
        pv.RPC("SetPlayersNameGlobal", RpcTarget.All, null);
    }

    [PunRPC]
    private void SetPlayersNameGlobal()
    {
        foreach (var playerObject in GameObject.FindGameObjectsWithTag("player"))
        {
            playerObject.GetComponent<MyPlayer>().nickName.text = playerObject.GetComponent<PhotonView>().Owner.NickName;  // her oyuncunun texti nicknamei olsun    
        }
    }


}
