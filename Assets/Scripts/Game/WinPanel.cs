using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class WinPanel : Singleton<WinPanel>
{
    public Text txt_WinnerNickName;

    public void SetWinnerNameLocal(string winnerNickName)
    {
        GetComponent<PhotonView>().RPC(nameof(SetWinnerNameGlobal), RpcTarget.All, winnerNickName);
    }

    [PunRPC]
    private void SetWinnerNameGlobal(string winnerNickName)
    {
        txt_WinnerNickName.text = winnerNickName;
    }



}
