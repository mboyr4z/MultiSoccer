using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IPunObservable
{
    

    [SerializeField] private float hiz;

    private FixedJoystick joystick;

    private float yatay, dikey;

    private Rigidbody2D rb;

    private bool isMine = false;

    private void Awake()
    {
        isMine = GetComponent<PhotonView>().IsMine;
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Ping problemi algoritması
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting && isMine)
        {
            stream.SendNext(rb.velocity);
        }
        else
        {
            rb.velocity = (Vector2)stream.ReceiveNext();
        }         
    }

    
    private void FixedUpdate()
    {
            if (MyPlayer.cihaz == Cihaz.android)
            {
                yatay = joystick.Horizontal;
                dikey = joystick.Vertical;
            }
            else
            {
                yatay = Input.GetAxis("Horizontal");
                dikey = Input.GetAxis("Vertical");
            }

            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(rb.velocity.x + yatay * Time.deltaTime * hiz, rb.velocity.y + dikey * Time.deltaTime * hiz), .3f);
    }
}

