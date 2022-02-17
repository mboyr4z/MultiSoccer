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
       // sut.onClick.AddListener(sutCek);


        if (pv.IsMine)
        {
            firstSpawnPoint = transform.position;
        }
    }



    public void Gol(int golYiyen)
    {
        TextManager.Instance.Ekle(" gol ");
        GolKontrolEt(golYiyen);
        EskiKonumunaDon(golYiyen);
        
    }

    public void EskiKonumunaDon(int golYiyen)
    {
            TextManager.Instance.Ekle("" + firstSpawnPoint.ToString() + " konumuna gidiyom ");
            transform.DOLocalMove(firstSpawnPoint, 1).SetEase(Ease.Flash);
            Invoke("hizSifirla", 1f);
       
    }


    public void GolKontrolEt(int golYiyen)
    {
        if(golYiyen == PlayerPrefs.GetInt("playerOrder") && pv.IsMine )
        {
            PlayerPrefs.SetInt("gol", PlayerPrefs.GetInt("gol") + 1);
            yenildimi();
        }
    }
    
    private void yenildimi()
    {

        if(PlayerPrefs.GetInt("gol") == 3)
        {
            PhotonNetwork.LeaveRoom();
        }
        
    }



    void rengiEskiHalineGetir()
    {
        if (pv.IsMine)
        {
            cerceve.DOColor(new Color(255, 255, 255, 255), 1f);
        }
    }


    void hizSifirla()
    {
        if(pv.IsMine)
        rb.velocity = new Vector2(0, 0);
    }

}



public enum Cihaz
{
    unity,
    windows,
    android
}
