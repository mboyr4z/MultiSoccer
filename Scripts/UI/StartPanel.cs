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
        string nickName = txtNickName.text.Trim();

        if (nickName.Length == 0)
        {
            return;
        }
        Data.nickName = nickName;
        PhotonNetwork.NickName = nickName;
        MenuManager.Instance.OpenMenu("TitleMenu");
    }
}
