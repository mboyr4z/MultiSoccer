using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duvar : MonoBehaviour, IDuvar
{

    public void carpisma(GameObject top)
    {
       /* print(top.GetComponent<Rigidbody2D>().velocity);

        Vector2 relativePos = new Vector2(top.transform.position.x- transform.position.x, top.transform.position.y - transform.position.y);

        top.GetComponent<Rigidbody2D>().AddForce(relativePos.normalized * 100);*/
    }
}
