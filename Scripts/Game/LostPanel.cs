using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class LostPanel : Singleton<LostPanel>
{

    private void OnEnable()
    {
        SetLoserNickName(PhotonNetwork.NickName);
        SetLoserRank(Data.leftPlayer + 1);
    }
    public Text TXT_LoserNickName;

    public Text TXT_LoserRank;

    public void SetLoserNickName(string nickName)
    {
        TXT_LoserNickName.text = nickName;
    }

    public void SetLoserRank(int rank)
    {
        TXT_LoserRank.text = rank.ToString();
    }
}
