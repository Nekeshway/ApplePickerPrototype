using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    static public int score;
  
     private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", score);
    }
    
     public void UpdateScore()
     {
         _textMeshPro.text = "High Score: " +score;
         if (score > PlayerPrefs.GetInt("HighScore"))
         {
             PlayerPrefs.SetInt("HighScore", score);
         }
     }
}
