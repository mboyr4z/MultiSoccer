using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using DG.Tweening;

public class Shot : MonoBehaviour
{

    [SerializeField] private float vurusGucu;

    public SpriteRenderer cerceve;

    private Button shotButton;

    private PhotonView pv;

    private float fireRate = 0.5f;

    private float nextFire = 0.0f;






    void Start()
    {
        shotButton = GameObject.Find("ShotButton").GetComponent<Button>();

        if(Player.cihaz == Cihaz.android)
        {
            shotButton.onClick.AddListener(Shoot);
        }
        
        
        pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Player.cihaz != Cihaz.android && Input.GetKey(KeyCode.Space))
        {
            //print("Distance : " + Vector3.Distance(transform.position, Ball.Instance.transform.position).ToString());
            Shoot();
        }
    }

    private void Shoot()
    {
        pv.RPC("RPC_ChangeColorOnShot", RpcTarget.All, pv.ViewID);
        if (Time.time > nextFire && pv.IsMine)   // after 0.5f and isMine 
        {       
            if (Vector3.Distance(transform.position, Ball.Instance.transform.position ) < 1.4f){ // player and ball distance smaller than 1.1f
                nextFire = Time.time + fireRate;
                Ball.Instance.MoveLocal(transform.position, vurusGucu);   // move functions is run
            }
        }
    }

    [PunRPC]
    public void RPC_ChangeColorOnShot(int viewID)
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("player"))
        { 
            if(item.GetComponent<PhotonView>().ViewID == viewID)
            {
                item.GetComponent<Shot>().ChangeColorOnShoot();
            }
        }
    }

    

    private void ChangeColorOnShoot()
    {
        print("vuruyom");
        cerceve.DOColor(new Color(8, 181, 171, 255), 2f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
    }
}
