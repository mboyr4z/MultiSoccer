using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;



public class StartPanel : MonoBehaviour
{
    public void SetNickName(Text txtNickName)
    {
        PhotonNetwork.NickName = txtNickName.text;
        MenuManager.Instance.OpenMenu("title");
    }
}
