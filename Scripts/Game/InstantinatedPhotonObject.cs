using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InstantinatedPhotonObject : MonoBehaviour
{
    public void DestroyInstantinatedObjectLocal()
    {
        GetComponent<PhotonView>().RPC("DestroyInstantinatedObjectGlobal", RpcTarget.All, null);
    }

    [PunRPC]
    private void DestroyInstantinatedObjectGlobal()
    {
        Destroy(gameObject);
    }
    
}
