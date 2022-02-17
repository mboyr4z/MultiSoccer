using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSetup : MonoBehaviour
{
    public void IsLocalPlayer()
    {
        TextManager.Instance.Ekle("Geldim");
        GetComponent<Movement>().enabled = true;    // hareket aktif
        GetComponent<Shot>().enabled = true;        // şut aktif
        GetComponent<GoalSpawner>().SpawnGoal();    // kale aktif

        Room.Instance.SetPlayersNameLocal();        // biri odaya girdiğinde tüm oyuncuların adları düzenlensin
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
