using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class CreateRoom : MonoBehaviour
{
    private ObjectManager om;

    

    private void Awake()
    {
        om = ObjectManager.Instance;
    }

    private void OnEnable()
    {
        om.Text_CreateRoomErrorText.gameObject.SetActive(true);
        om.Text_CreateRoomErrorText.text = string.Empty;
    }

    private void OnDisable()
    {
        om.Text_CreateRoomErrorText.gameObject.SetActive(false);
    }

    public void CreateRoomm()
    {

        if (string.IsNullOrEmpty(om.Input_RoomName.text))
        {
            om.Text_CreateRoomErrorText.text = "Room Name cant be null!";
            return;
        }

        string roomName = om.Input_RoomName.text.Trim();

        if(roomName.Length == 0)
        {
            om.Text_CreateRoomErrorText.text = "Room Name must not contain only space char!";
            return;
        }

        if (int.Parse(om.Input_MaxPlayer.text) < 5 && int.Parse(om.Input_MaxPlayer.text) > 0)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.CleanupCacheOnLeave = false;        // biri odadan ayrıldıpında ürettiğin nesneler yok olmasın.
            roomOptions.MaxPlayers = (byte)int.Parse(om.Input_MaxPlayer.text);
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }
    }

  

}
