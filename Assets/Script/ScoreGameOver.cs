using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreGameOver : MonoBehaviour
{
   
    [SerializeField] private TextMeshProUGUI text;
    private int score;
    private void Awake()
    {
        score = PlayerPrefs.GetInt("SaveScore");
    }

    private void Score()
    {
        text.text = score.ToString();
    }
}
