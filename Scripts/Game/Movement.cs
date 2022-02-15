using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float hiz;

    private FixedJoystick joystick;

    private Cihaz cihaz;

    private float yatay, dikey;

    private Rigidbody2D rb;

    private void Start()
    {


#if UNITY_STANDALONE_WIN

        cihaz = Cihaz.windows;

#endif

#if UNITY_ANDROID

        cihaz = Cihaz.android;

#endif

#if UNITY_EDITOR

        cihaz = Cihaz.unity;

#endif

        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
            if (cihaz == Cihaz.android)
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

public enum Cihaz
{
    unity,
    windows,
    android
}
