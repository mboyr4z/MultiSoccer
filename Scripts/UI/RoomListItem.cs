using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using Photon.Realtime;


public class RoomListItem : MonoBehaviourPunCallbacks
{
    public string name;
    [SerializeField] TMP_Text roomName;
    [SerializeField] TMP_Text cur_max;

    
    // odaya ait ID değeri alınacak
    private RoomInfo info;
    
    public void setup(RoomInfo _info)
    {
        this.name = _info.Name;
        roomName.text = _info.Name;
        cur_max.text = _info.PlayerCount.ToString() + " / " + _info.MaxPlayers.ToString();
        
        info = _info;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
