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
            Shoot();
        }
    }

    private void Shoot()
    {
        
        if (Time.time > nextFire && pv.IsMine)   // after 0.5f and isMine 
        {
            pv.RPC("RPC_ChangeColorOnShot", RpcTarget.All, pv.ViewID);
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



    private void ChangeColorOnShoot()       // 2 harekette önceden varsa durdurur daha sonra hareketlere tekrar başlar
    {
        DOTween.Kill(1);
        DOTween.Kill(2);        // önce beyazlamayı durdur
        cerceve.DOColor(Color.blue, 0.1f).SetEase(Ease.OutFlash).SetId(1) // mavileşme başlar
        .OnComplete(() =>
        {
            cerceve.DOColor(Color.white, 0.3f).SetEase(Ease.Linear).SetId(2);
        });
    }
}
