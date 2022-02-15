using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Shot : MonoBehaviour
{
    private Button sut;

    private PhotonView pv;

    void Start()
    {
        sut = GameObject.Find("Sut").GetComponent<Button>();
        pv = GetComponent<PhotonView>();
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
           // cerceve.DOColor(new Color(0, 255, 255, 255), 0.01f).OnComplete(() => rengiEskiHalineGetir());
        }
    }
}
