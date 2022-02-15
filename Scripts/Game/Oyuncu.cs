using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Photon.Pun;



public class Oyuncu : Singleton<Oyuncu>,IPunObservable
{
    public static Cihaz cihaz;

    [SerializeField] SpriteRenderer cerceve;

    [SerializeField] private Text nickName;

    [SerializeField] private SpriteRenderer arkaPlan;

    TextMeshProUGUI durum;

    private PhotonView pv;

    private Rigidbody2D rb;

    private Vector3 ilkKonum;



    // Ping problemi algoritması
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            transform.position = Vector3.Slerp(transform.position, (Vector3)stream.ReceiveNext(), 0.2f);
            transform.rotation = (Quaternion)stream.ReceiveNext();
        } 
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
        durum = GameObject.Find("Durum").GetComponent<TextMeshProUGUI>();
       // sut.onClick.AddListener(sutCek);


        if (pv.IsMine)
        {
            renkAyarla();
            nickName.text = PhotonNetwork.NickName;
            ilkKonum = transform.position;
        }
    }


    private void renkAyarla()
    {
        if (PlayerPrefs.GetInt("playerOrder") == 1)
        {
            arkaPlan.color = new Color(255, 0, 0, 255);
        }

        if (PlayerPrefs.GetInt("playerOrder") == 2)
        {
            arkaPlan.color = new Color(0, 255, 0, 255);
        }

        if (PlayerPrefs.GetInt("playerOrder") == 3)
        {
            arkaPlan.color = new Color(0, 0, 255, 255);
        }

        if (PlayerPrefs.GetInt("playerOrder") == 4)
        {
            arkaPlan.color = new Color(255, 255, 0, 255);
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
            TextManager.Instance.Ekle("" + ilkKonum.ToString() + " konumuna gidiyom ");
            transform.DOLocalMove(ilkKonum, 1).SetEase(Ease.Flash);
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
