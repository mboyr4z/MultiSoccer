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

    public void ChangeColorWhenKnockedOutLocal()
    {
        GetComponent<PhotonView>().RPC(nameof(ChangeColorWhenKnockedOutGlobal), RpcTarget.All, null);
    }

    [PunRPC]
    private void ChangeColorWhenKnockedOutGlobal()
    {
        GetComponent<SpriteRenderer>().color = Data.KnockedOut;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))  // HER CİHAZDA golYiyen kalede çalıştırır
        {
            SoundManager.Instance.PlaySound("Whistle");
            SoundManager.Instance.PlaySound("Goal");

            if (GetComponent<PhotonView>().IsMine)      // sadece gol yiyen kale tek bir cihazda çalışır
            {
                _localPlayer.GetComponent<MyPlayer>().GolLocal();  // sadece gol yiyen kişide çalışır
                GoalEffects.Instance.StartBadGoalKeeperEffectLocal(PhotonNetwork.NickName);
            }
            

            // Tüm Makinelerde gol yiyen kalelerde çalışır
            Ball.Instance.GoFirstPos();
            
            
            //TextManager.Instance.Ekle("Tüm Makineler");
            foreach (var goal in GameObject.FindGameObjectsWithTag("Goal"))         // Tüm makineler de tüm kalelerde çalışır
            {
                //TextManager.Instance.Ekle("Tüm Kaleler");
                if (goal.GetComponent<PhotonView>().IsMine)     // ve sadece kendine ait olan kalelerde çalışır
                {
                    
                    //TextManager.Instance.Ekle("Sadece Benim Kalem");
                    goal.GetComponent<Goal>()._localPlayer.GetComponent<MyPlayer>().GoFirstSpawnPosition();     // sadece bana ait oyuncu yerine geçsin
                    goal.GetComponent<Goal>()._localPlayer.GetComponent<MyPlayer>().DisableMovement();          // oyuncumun hareketi kısıtlansın
                    GoalParticleSystem.Instance?.StartParticalSystem();                                         // komfeti patlasın
                    GoalEffects.Instance?.StartGoalTextEffect();         // yazı efecti gelsin
                    break;
                }
            }
        }
    }
}
