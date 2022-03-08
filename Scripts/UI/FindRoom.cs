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
        foreach (Transform room in om.RoomListContent)
        {
            Destroy(room.gameObject);
        }


        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(om.pre_RoomListItemPrefab, om.RoomListContent).GetComponent<RoomListItem>().setup(roomList[i]);
        }

    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("room");
    }
}
