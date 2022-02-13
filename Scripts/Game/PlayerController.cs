using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Photon.Pun;



public class PlayerController : Singleton<PlayerController>,IPunObservable
{

    public static PlayerController instance;

    private Cihaz cihaz;

    [SerializeField] private float hiz;

    [SerializeField] SpriteRenderer cerceve;

    [SerializeField] private Text nickName;

    [SerializeField] private SpriteRenderer arkaPlan;

    TextMeshProUGUI durum;

    private PhotonView pv;

    private FixedJoystick joystick;

    Rigidbody2D rb;

    private Button sut;

    private float yatay, dikey;

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
        instance = this;
    }

    private void Start()
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

        
        pv = GetComponent<PhotonView>();        
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        

        sut = GameObject.Find("Sut").GetComponent<Button>();
        rb = GetComponent<Rigidbody2D>();
        durum = GameObject.Find("Durum").GetComponent<TextMeshProUGUI>();
        sut.onClick.AddListener(sutCek);


        if (pv.IsMine)
        {
            renkAyarla();
            nickName.text = PhotonNetwork.NickName;
            ilkKonum = transform.position;
        }
    }


    private void renkAyarla()
    {
        if (PlayerPrefs.GetInt("oyuncuSirasi") == 1)
        {
            arkaPlan.color = new Color(255, 0, 0, 255);
        }

        if (PlayerPrefs.GetInt("oyuncuSirasi") == 2)
        {
            arkaPlan.color = new Color(0, 255, 0, 255);
        }

        if (PlayerPrefs.GetInt("oyuncuSirasi") == 3)
        {
            arkaPlan.color = new Color(0, 0, 255, 255);
        }

        if (PlayerPrefs.GetInt("oyuncuSirasi") == 4)
        {
            arkaPlan.color = new Color(255, 255, 0, 255);
        }
    }

    public void Gol(int golYiyen)
    {
        if (pv.IsMine)
        {
            print("BAKEM KAC KEZ OLACAK");
            GolKontrolEt(golYiyen);
            EskiKonumunaDon(golYiyen);
        }
    }

    public void GolKontrolEt(int golYiyen)
    {
        if(golYiyen == PlayerPrefs.GetInt("oyuncuSirasi") && pv.IsMine )
        {
            print(PlayerPrefs.GetInt("oyuncuSirasi"));
            print("gol yiyen : " + golYiyen);
            PlayerPrefs.SetInt("gol", PlayerPrefs.GetInt("gol") + 1);
            yenildimi();
        }
    }
    
    private void yenildimi()
    {
        print("yenilme kontrol");
        if(PlayerPrefs.GetInt("gol") == 3)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    void sutCek()
    {
        if (pv.IsMine)
        {
            print("sut cekiliyor");
            print("fark bu " + Vector3.Distance(transform.position, GameObject.Find("TopController(Clone)").transform.position).ToString());
            if (Vector3.Distance(transform.position, GameObject.Find("TopController(Clone)").transform.position) < 1.5f) 
            {
                GameObject.Find("TopController(Clone)").GetComponent<TopController>().hareketEt(transform.position, 20);
            }
            cerceve.DOColor(new Color(0, 255, 255, 255), 0.01f).OnComplete( () => rengiEskiHalineGetir());
        }      
    }

    void rengiEskiHalineGetir()
    {
        if (pv.IsMine)
        {
            cerceve.DOColor(new Color(255, 255, 255, 255), 1f);
        }
    }

    public void EskiKonumunaDon(int golYiyen)
    {
        if (pv.IsMine)
        {
            if(golYiyen == PlayerPrefs.GetInt("oyuncuSirasi"))
            {
                print("GOL OLDU VE GOLU YİYEN BENİM");

            }
            else
            {
                print("GOL YİYEN BEN DEGİLİM");
            }
            transform.DOLocalMove(ilkKonum, 1).SetEase(Ease.Flash);
            //durum.text = "Gol Oldu KONUM : " + ilkKonum.ToString();
            Invoke("hizSifirla", 1f);
        }
    }

    void hizSifirla()
    {
        rb.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {

        

        if (pv.IsMine)
        {
            if(cihaz == Cihaz.android)
            {
                yatay = joystick.Horizontal;

                dikey = joystick.Vertical;

                

                //rb.AddForce(new Vector3(yatay * Time.deltaTime * hiz, dikey * Time.deltaTime * hiz, 0));
            }else
            {
                yatay = Input.GetAxis("Horizontal");
                dikey = Input.GetAxis("Vertical");

                
            }
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(rb.velocity.x + yatay * Time.deltaTime * hiz, rb.velocity.y + dikey * Time.deltaTime * hiz), .3f);
        }
    }
}

public enum Cihaz
{
    unity,
    windows,
    android
}
