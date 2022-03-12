using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectManager : Singleton<ObjectManager>
{
    public TMP_InputField Input_RoomName;
    public TMP_InputField Input_MaxPlayer;

    public TMP_Text Text_Error;
    public Text Text_RoomName;

    public Transform RoomListContent;
    public Transform PlayerListContent;

    public GameObject Button_StartGame;

    public GameObject pre_RoomListItemPrefab;
    public GameObject pre_PlayerListItemPrefab;

    
}
