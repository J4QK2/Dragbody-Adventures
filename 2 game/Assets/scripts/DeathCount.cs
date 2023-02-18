using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public static int deaths;
    public TextMeshProUGUI deathScore;
    void Start()
    {
      deathScore.text = PlayerPrefs.GetInt("Deathscore").ToString();
    }
   

    public void Unc()
    {
        
        deaths++;
       deathScore.text = deaths.ToString();
       PlayerPrefs.SetInt("Deathscore", deaths);


    }
    public void Get()
    {
        deathScore.text = PlayerPrefs.GetInt("deth").ToString();
    }
    public void Set()
    {
           PlayerPrefs.SetInt("deth", deaths);
    }
}
