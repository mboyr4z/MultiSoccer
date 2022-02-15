using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Shot : MonoBehaviour
{

    [SerializeField] private float vurusGucu;

    private Button shotButton;

    private PhotonView pv;

    private float fireRate = 0.5f;

    private float nextFire = 0.0f;

    


    void Start()
    {
        shotButton = GameObject.Find("ShotButton").GetComponent<Button>();

        if(Oyuncu.cihaz == Cihaz.android)
        {
            shotButton.onClick.AddListener(Shoot);
        }
        
        
        pv = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (Oyuncu.cihaz != Cihaz.android && Input.GetKey(KeyCode.Space))
        {
            //print("Distance : " + Vector3.Distance(transform.position, Ball.Instance.transform.position).ToString());
            Shoot();
        }
    }

    void Shoot()
    {
        if(Time.time > nextFire && pv.IsMine)   // after 0.5f and isMine 
        {       
            if (Vector3.Distance(transform.position, Ball.Instance.transform.position ) < 1.4f){ // player and ball distance smaller than 1.1f
                nextFire = Time.time + fireRate;
                Ball.Instance.MoveLocal(transform.position, vurusGucu);   // move functions is run
            }
        }
           // cerceve.DOColor(new Color(0, 255, 255, 255), 0.01f).OnComplete(() => rengiEskiHalineGetir());
    }
}
