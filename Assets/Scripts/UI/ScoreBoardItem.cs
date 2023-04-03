using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardItem : MonoBehaviour
{
    [SerializeField] private Text Name;
    [SerializeField] private Text Level;
    [SerializeField] private Text Gol;
    

    private int _playerOrder;
    
    public void Setup(string name, int level, int gol, int playerOrder )
    {
        Name.text = name;
        Level.text = level.ToString();
        Gol.text = gol.ToString();
        _playerOrder = playerOrder;
    }
}
