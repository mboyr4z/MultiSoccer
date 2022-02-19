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


    private void Start()
    {
        pv = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    public void MoveLocal(Vector2 vuranPos, float guc)
    {
        pv.RPC("MoveGlobal", RpcTarget.All, vuranPos, guc);
    }

    [PunRPC]
    public void MoveGlobal(Vector2 vuranPos, float guc)
    {
        topPos = transform.position;
        yon = topPos - vuranPos;
        rb.velocity = yon * guc;
    }


    public void GoFirstPos()
    {
        transform.DOLocalMove(new Vector3(0, 0, 0), 1).SetEase(Ease.Flash);
        CloseCollider();
        ResetVelocity();
        Invoke("OpenCollider", 1f);    // golden 1 saniye sonra triggeri geri açılsın
    }

    private void OpenCollider()
    {
        cc.enabled = true;
    }

    private void CloseCollider()
    {
        cc.enabled = false;
    }

    void ResetVelocity()
    {
        rb.velocity = new Vector2(0,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDuvar>()?.carpisma(gameObject);
    }
}
