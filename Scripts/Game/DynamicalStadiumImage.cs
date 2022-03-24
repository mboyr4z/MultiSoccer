using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicalStadiumImage : MonoBehaviour
{
    private int width, height;

    const float Y = 1.54f;

    private float X;





    void Start()
    {

        width = Screen.width;
        height = Screen.height;;

        X = (Y / 2) / height * width;
        transform.localScale = new Vector3(X,Y,0);
    }

    
}
