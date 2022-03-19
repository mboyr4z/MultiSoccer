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
        pv = GetComponent<PhotonView>();
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

    public void SetPlayersNameLocal( )      //  her oyuncu localinde isimleri düzenlesin
    {
        pv.RPC("SetPlayersNameGlobal",RpcTarget.All,null);
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
