using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreNum;
    private PlayerMove player;
    private ButtonSwitch beatSwitch;
    private int scoreTemp;
    
    public void NumScore(int Score)
    {
        scoreTemp += Score;
        scoreNum.text = scoreTemp.ToString();
        
    }

}
