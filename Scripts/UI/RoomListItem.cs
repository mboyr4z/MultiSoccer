using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;


public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text roomName;
    [SerializeField] TMP_Text cur_max;

    RoomInfo info;

    public void setup(RoomInfo _info)
    {
        roomName.text = _info.Name;
        cur_max.text = _info.PlayerCount.ToString() + " / " + _info.MaxPlayers.ToString();

        info = _info;
    }

    public void OnClick()
    {
        //Launcher.Instance.JoinRoom(info);
    }
}
