using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Photon.Pun;

public class Ball : Singleton<Ball>
{
    private Vector2 topPos;

    private Rigidbody2D rb;

    private Vector2 yon;

    private CircleCollider2D cc;

    private PhotonView pv;



    // Ping problemi algoritması
    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else if (stream.IsReading)
        {
            transform.position = (Vector3)stream.ReceiveNext();// Vector3.Slerp(transform.position, (Vector3)stream.ReceiveNext(), 0.2f);
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }*/

    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    public void Move(Vector2 vuranPos, float guc)
    {
        topPos = transform.position;
        yon = topPos - vuranPos;
        rb.velocity = yon * guc;
    }


    private void ortayaGit()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 1).SetEase(Ease.Flash);
        Invoke("hizSifirla",1f);
        Invoke("ColliderAc", 1f);    // golden 1 saniye sonra triggeri geri açılsın
    }

    void ColliderAc()
    {
        cc.enabled = true;
    }

    void ColliderKapat()
    {
        cc.enabled = false;
    }

    void hizSifirla()
    {
        rb.velocity = new Vector2(0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDuvar>()?.carpisma(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        Vector3 kalePos;
        int golYiyen;

        if (collision.gameObject.tag == "kale")
        {
            ColliderKapat();
            kalePos = collision.gameObject.transform.position;

            if (kalePos.x < -8f)
            {
                golYiyen = 1;
            }
            else if (kalePos.x > 8f)
            {
                golYiyen = 2;
            }
            else if (kalePos.y < -5f)
            {
                golYiyen = 3;
            }
            else
            {
                golYiyen = 4;
            }

            ortayaGit();
            pv.RPC("GolOldu", RpcTarget.All, golYiyen);
        }
    }

    [PunRPC]
    void GolOldu(int golYiyen)
    {
        Oyuncu.Instance.Gol(golYiyen);
    }
}
