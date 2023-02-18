using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class selectweapon : MonoBehaviour
{
    
    public Animator transition;
    public GameObject Seltext2;
    public Animator SelText;
    public float iime;
    public GameObject left;
    public GameObject right;
    public GameObject opt;
    public Animator anim;
    public float audTime;
    public t aud;
    public GameObject defWeapon;
    private highscore1 hey;
    private highscore2 hey2;
    public GameObject firstWeapon;
    public GameObject secondWeapon;
    public GameObject thirdWeapon;
    public GameObject wapon;
    public GameObject[] Weapons;
    


    void Start()
    {
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        SelText.updateMode = AnimatorUpdateMode.UnscaledTime;
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
        hey = FindObjectOfType<highscore1>();
        hey2 = FindObjectOfType<highscore2>();
    }

   
    
    public void Setup2()
    {
        Seltext2.SetActive(true);
        SelText.SetBool("a", true);
        gameObject.SetActive(true);
        anim.SetBool("ryt", true);
        left.SetActive(false);
        right.SetActive(false);
        Time.timeScale = 0f;
        aud.audioSource.spatialBlend = audTime;
    }
    public void FirstWeopon()
    {
        int sizeOfWeapons;
        sizeOfWeapons = Random.Range(0, Weapons.Length);
        wapon = Weapons[sizeOfWeapons];

        switch (sizeOfWeapons)
        {
            case 0:
                wapon.SetActive(true);
               StartCoroutine(hey.fGun());
                break;
            case 1:
                wapon.SetActive(true);
                StartCoroutine(hey.sGun());
                break;
            case 2:
                wapon.SetActive(true);
                StartCoroutine(hey.tGun());
                break;
        }

        
    }
    
    public void BackTotheGame()
    {
        hey.FadeS.SetActive(false);
        gameObject.SetActive(false);
        Seltext2.SetActive(false);
        left.SetActive(true);
        right.transform.position.Set(0, 0, 0);
        right.SetActive(true);
        Time.timeScale = 1f;
        aud.audioSource.spatialBlend = 0;
        
    }
    public void BackTotheGame2()
    {
        hey2.FadeS.SetActive(false);
        gameObject.SetActive(false);
        left.SetActive(true);
        right.SetActive(true);
        Time.timeScale = 1f;
        aud.audioSource.spatialBlend = 0;

    }
    public void For2Lvl()
    {
hey2.FadeS.SetActive(false);
    }
    

}
