using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    private Button sut;
    void Start()
    {
        sut = GameObject.Find("Sut").GetComponent<Button>();
    }

    
    void Update()
    {
        
    }
}
