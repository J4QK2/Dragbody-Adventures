using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class highscore1 : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeLimit;
    public int timeL;
    public float tm;
    public selectweapon sw;
    public GameObject spawnee;
    public GameObject FadeS;
    public int number;
    private SecondEnemySpawner secEnemies;
    private CarScr cr;
    private Enemy nemy;
    private move player;
    public GameObject gm;
    bool onetime = false;
    bool onetime1 = false;
    bool onetime2 = false;
    public bool twotime = false;
    public int scoreAmount;
    private SpawnPotion spp;
   
    void Start()
    {
        Destroy(GameObject.Find("aud"));
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        secEnemies = FindObjectOfType<SecondEnemySpawner>();
        player = FindObjectOfType<move>();
        nemy = FindObjectOfType<Enemy>();
        cr = FindObjectOfType<CarScr>();
        spp = FindObjectOfType<SpawnPotion>();
    }
    private void Update()
    {
       
        if(number%100 == 0 && number > 0 && !twotime)
        {
            FadeS.SetActive(true);
              sw.Setup2();
            StartCoroutine(rt());
            twotime = true;
        }
        if(number%100 != 0)
        {
            twotime = false;
        }
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("menu");
        }
        if (number >= 600 && player.health !=0)
        {
            secEnemies.ToSpawn();
        }
        if(!onetime && player.health == 0)
        {
            Destroy(gm);
            
            onetime = true;
        }
        if(number >= 300 && !onetime1)
        {
            cr.Car();
            onetime1 = true;
        }
        if (number >= 500 && !onetime2)
        {
            cr.Car2();
            onetime2 = true;
        }
        if(number >= 300 && player.health != 0)
        {
            spp.SpawnP();
        }
    }
    public void quit()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }
    public IEnumerator rt()
    {
        yield return new WaitForSeconds(100000);
        twotime = false;
    }
    


    public void ingame()
    {
       
        SceneManager.LoadScene("game");
        Time.timeScale = 1f;

    }


    public void Score()
    {
        if (player.health != 0)
        {
        if(number >= 260)
        {
            number += scoreAmount * 2;
        }
        else
        {
             number += scoreAmount;
        }
        score.text = number.ToString();
           
            scoreText.text = number.ToString();
        if(number > PlayerPrefs.GetInt("Highscore", 0))
        {
             PlayerPrefs.SetInt("Highscore", number);
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
        yield return new WaitForSeconds(15);
        
        sw.wapon.SetActive(false);
    sw.defWeapon.SetActive(true);
    }
    
    public IEnumerator sGun()
    {
        
        yield return new WaitForSeconds(tm);
        sw.wapon.SetActive(false);
        sw.defWeapon.SetActive(true);
        
    }
    public IEnumerator tGun()
    {
        yield return new WaitForSeconds(10);
        sw.wapon.SetActive(false);
        sw.defWeapon.SetActive(true);
    }
}
