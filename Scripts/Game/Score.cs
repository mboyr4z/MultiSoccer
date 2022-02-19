using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public void SetScoreLocal(int score)
    {
        GetComponent<Text>().text = score.ToString();
    }

    
}
