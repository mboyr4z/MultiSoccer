using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class FindRoom : MonoBehaviourPunCallbacks
{
    private ObjectManager om;


    private void Start()
    {
        om = ObjectManager.Instance;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //DeleteAllRoomItems();

        foreach (var roomAttr in roomList)
        {
            
            if (!roomAttr.RemovedFromList)
            {
                Instantiate(om.pre_RoomListItemPrefab, om.RoomListContent).GetComponent<RoomListItem>().setup(roomAttr);     // odalar sabitse
                
            }
            else
            {
                foreach (Transform roomItem in om.RoomListContent)
                {
                    if(roomItem.gameObject.GetComponent<RoomListItem>().name == roomAttr.Name)
                    {
                        Destroy(roomItem.gameObject);
                    }
                }
            }
        }


    }

    private void DeleteAllRoomItems()
    {
        foreach (Transform room in om.RoomListContent)      // tüm elemanları kaldır
        {
            Destroy(room.gameObject);
        }
    }

    public override void OnJoinedRoom()
    {
        om.Text_RoomName.text = PhotonNetwork.CurrentRoom.Name;
        MenuManager.Instance.OpenMenu("room");
    }
}
