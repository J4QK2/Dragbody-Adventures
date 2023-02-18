using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class highscore2 : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI highscore24;
    public TextMeshProUGUI scoreText;

    public GameObject spawnee;
    public int number;
    public int timeL;
    private GreenM secEnemies;
    private CarScr cr;
    public GameObject FadeS;
    private Enemy nemy;
    private move player;
    public GameObject gm;
    bool onetime = false;
    bool onetime1 = false;
    bool onetime2 = false;
    public bool twotime = false;
    public int scoreAmount;
    private SpawnPotion spp;
    public greenmonster grm;
    public selectweapon sw;
    

    void Start()
    {
        Destroy(GameObject.Find("aud"));
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        highscore24.text = PlayerPrefs.GetInt("Highscore2", 0).ToString();
        secEnemies = FindObjectOfType<GreenM>();
        player = FindObjectOfType<move>();
        nemy = FindObjectOfType<Enemy>();
        cr = FindObjectOfType<CarScr>();
        spp = FindObjectOfType<SpawnPotion>();
        
    }
    private void Update()
    {
        
       
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("menu");
        }
        if (number >= 600 && player.health != 0 && !onetime2)
        {
            secEnemies.ToSpawn();
            onetime2 = true;
        }
        if (number % 100 == 0 && number > 0 && !twotime)
        {
            FadeS.SetActive(true);
            sw.Setup2();
            StartCoroutine(rt());
            twotime = true;
        }
        if (number % 100 != 0)
        {
            twotime = false;
        }
        if (!onetime && player.health == 0)
        {
            Destroy(gm);

            onetime = true;
        }
        /*if (number >= 300 && !onetime1)
        {
            cr.Car();
            
            onetime1 = true;
        }
        if (number >= 500 && !onetime2)
        {
            cr.Car2();
            onetime2 = true;
        }*/
        if (number >= 300 && player.health != 0)
        {
            spp.SpawnP();
        }
    }


    public IEnumerator rt()
    {
        yield return new WaitForSeconds(100000);
        twotime = false;
    }
    public void Score()
    {
        if (player.health != 0)
        {
            if (number >= 260)
            {
                number += scoreAmount * 2;
            }
            else
            {
                number += scoreAmount;
            }
            score.text = number.ToString();

            scoreText.text = number.ToString();
            if (number > PlayerPrefs.GetInt("Highscore2", 0))
            {
                PlayerPrefs.SetInt("Highscore2", number);
                highscore.text = number.ToString();
            }
        }


    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
    }

    public void Increase()
    {
        nemy.health += 4;
    }


   public IEnumerator fGun()
    {
        yield return new WaitForSeconds(timeL);
        sw.wapon.SetActive(false);
        sw.defWeapon.SetActive(true);
    }
    

}
