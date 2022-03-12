using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class CreateRoom : MonoBehaviour
{
    private ObjectManager om;

    private void Awake()
    {
        om = ObjectManager.Instance;
    }
    public void CreateRoomm()
    {
        if (string.IsNullOrEmpty(om.Input_RoomName.text))
        {
            return;
        }

        if (int.Parse(om.Input_MaxPlayer.text) < 5 && int.Parse(om.Input_MaxPlayer.text) > 0)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = (byte)int.Parse(om.Input_MaxPlayer.text);
            PhotonNetwork.CreateRoom(om.Input_RoomName.text, roomOptions);

            MenuManager.Instance.OpenMenu("room");
        }
        else
        {
            return;
        }
    }
}
