using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float hiz;

    private FixedJoystick joystick;

    private float yatay, dikey;

    private Rigidbody2D rb;

    private void Start()
    {

        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
            if (Player.cihaz == Cihaz.android)
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

