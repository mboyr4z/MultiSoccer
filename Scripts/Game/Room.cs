using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System.IO;

public class Room : MonoBehaviourPunCallbacks
{
    public static Room Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // sahne yüklendiğinde, managerlar aktif olur ve her oyuncunun controllerları açılır
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)      //s ahne 1 yüklendiğinde
        {
            foreach (Transform manager in transform)
            {
                manager.gameObject.SetActive(true);
            }
        }
    }

    public void SetPlayersColorsLocal(BackgroundColors backgroundColor, int playerViewId)
    {

        photonView.RPC("SetPlayersColorsGlobal", RpcTarget.All, backgroundColor, playerViewId);
    }

    [PunRPC]
    private void SetPlayersColorsGlobal(BackgroundColors backgroundColor, int playerViewId)
    {
        TextManager.Instance.Ekle("Background Color : " + backgroundColor.ToString());
        TextManager.Instance.Ekle("View ID : " + playerViewId.ToString());
        /*foreach (var playerObject in GameObject.FindGameObjectsWithTag("player"))
        {
            
        }*/
    }

    public void SetPlayersNameLocal( )      //  her oyuncu localinde isimleri düzenlesin
    {
        photonView.RPC("SetPlayersNameGlobal",RpcTarget.All,null);
    }

    [PunRPC]
    private void SetPlayersNameGlobal()
    {
        
        foreach (var playerObject in GameObject.FindGameObjectsWithTag("player"))
        {
            playerObject.GetComponent<Player>().nickName.text = playerObject.GetComponent<PhotonView>().Owner.NickName;  // her oyuncunun texti nicknamei olsun    
        }
        
    }


}

public enum BackgroundColors
{
    Blue,
    Red,
    Yellow,
    Green
}
