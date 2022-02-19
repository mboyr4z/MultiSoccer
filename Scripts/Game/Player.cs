using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Photon.Pun;



public class Player : Singleton<Player>,IPunObservable
{

    public static Cihaz cihaz;

    public SpriteRenderer arkaPlan;

    public SpriteRenderer cerceve;

    public GameObject Goal;

    public Text nickName;

    private PhotonView pv;

    private Rigidbody2D rb;

    private Vector3 firstSpawnPoint;



    // Ping problemi algoritması
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            transform.position = Vector3.Slerp(transform.position, (Vector3)stream.ReceiveNext(), 0.2f);
            transform.rotation = (Quaternion)stream.ReceiveNext();
        } 
        */
    }


    private void Awake()
    {
#if UNITY_STANDALONE_WIN

        cihaz = Cihaz.windows;

#endif

#if UNITY_ANDROID

        cihaz = Cihaz.android;

#endif

#if UNITY_EDITOR

        cihaz = Cihaz.unity;

#endif
    }

    private void Start()
    {
        pv = GetComponent<PhotonView>();        
        
        rb = GetComponent<Rigidbody2D>();
    }



    public void GolLocal()
    {
        PlayerPrefs.SetInt("gol", PlayerPrefs.GetInt("gol") + 1);   // gol skorunu 1 artırır
        TextManager.Instance.Ekle("Gol Yedim. Golüm : " + PlayerPrefs.GetInt("gol").ToString());
        AmILose();
    }


    public void GoFirstSpawnPosition()
    {
            transform.DOLocalMove(PlayerSpawner.spawnPoint, 1).SetEase(Ease.Flash);
            Invoke("ResetVelocity", 1f);
    }
    
    public void AmILose()
    {

        if(PlayerPrefs.GetInt("gol") == 3)
        {
            PhotonNetwork.LeaveRoom();
        }
        
    }


    void ResetVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }

}



public enum Cihaz
{
    unity,
    windows,
    android
}
