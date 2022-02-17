using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Goal : MonoBehaviour
{

    public GameObject _localPlayer;
    public void Setup(GameObject _localPlayer)
    {
        this._localPlayer = _localPlayer;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))  // kaleyi üreten cihaz çalıştırır
        {
            if (GetComponent<PhotonView>().IsMine)      // sadece gol yiyen kale tek bir cihazda çalışır
            {
                _localPlayer.GetComponent<Player>().GolLocal();  // sadece gol yiyen kişide çalışır
            }


            TextManager.Instance.Ekle("Tüm Makineler");
            foreach (var goal in GameObject.FindGameObjectsWithTag("Goal"))         // Tüm makineler de tüm kalelerde çalışır
            {
                TextManager.Instance.Ekle("Tüm Kaleler");
                if (goal.GetComponent<PhotonView>().IsMine)     // ve sadece kendine ait olan kalelerde çalışır
                {
                    TextManager.Instance.Ekle("Sadece Benim Kalem");
                    goal.GetComponent<Goal>()._localPlayer.GetComponent<Player>().EskiKonumunaDon();
                    break;
                }
            }
        }
    }

    
}
