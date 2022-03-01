using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{

    [SerializeField] private GameObject ScoreListItem;
    [SerializeField] private Transform ScoreListContent;

    public void IsLocalPlayer()
    {
        GetComponent<Movement>().enabled = true;    // hareket aktif
        GetComponent<Shot>().enabled = true;        // şut aktif
        GetComponent<GoalSpawner>().SpawnGoal();    // kale aktif

        //MenuManager.Instance.menus[0].GetComponent<ScoreBoard>().SetActiveScoreBoardItemsLocal(PhotonNetwork.CountOfPlayersInRooms + 1); // scoreboıarda erişir
        ScoreBoard.Instance.SetActiveScoreBoardItemsLocal(PhotonNetwork.CountOfPlayersInRooms + 1);     // biri ordaya girdiğinde scoreBoard elemanlarının aktifliği açılsın

        Room.Instance.SetPlayersNameLocal();        // biri odaya girdiğinde tüm oyuncuların adları düzenlensin
        ScoreController.Instance.SetScorsLocal();    // biri odaya girdiğinde herkesin skor tablosu konusun
        Invoke("SetColor", 0.1f);
        Invoke("SetTriggerGoal",0.1f);
    }

    private void SetColor()     // herkesin odadaki kişi sayısınca renk koyanilmesi için
    {
        Room.Instance.SetPlayersColorsLocal();
    }

    private void SetTriggerGoal()       // herkesin odadaki kişi sayısınca kale triggerlarını açması için
    {
        Stadium.Instance.OpenTriggerGoalLocal();
    }

 

}
