using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trans : MonoBehaviour
{
    public Animator transition;
    public Animator transition2;
    public GameObject transtion2;
    public Animator stage1;
    public Animator stage2;
    
    public Animator backButt;
    private highscore1 hey;
    public float Time;
    public float Time2;
    public Button stag2;
    void Start()
    {
        transition2.SetTrigger("tr");
        StartCoroutine(k());
        hey = FindObjectOfType<highscore1>();
        
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("Highscore", 0) > 1000)
        {
            stag2.interactable = true;
            
        }
    }

    public void NextScene()
    {
        StartCoroutine(l());

    }
    public void NextLevelScene()
    {
        StartCoroutine(m());
    }
    public void Back()
    {
        StartCoroutine(back());
    }
    public void ghfghfj()
    {
         stage1.SetTrigger("stage1");
        stage2.SetTrigger("stage2");
        backButt.SetTrigger("back");
    }
    IEnumerator m()
    {
        transition.SetTrigger("trans(start)");
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("levelScene");
    }
    IEnumerator back()
    {
        transition.SetTrigger("trans(start)");
        yield return new WaitForSeconds(Time);
        SceneManager.LoadScene("menu");
        
    }
    IEnumerator l()
    {
        transition.SetTrigger("trans(start)");
        yield return new WaitForSeconds(Time2);
        SceneManager.LoadScene("game");
    }
    IEnumerator y()
    {
        transition.SetTrigger("trans(start)");
        yield return new WaitForSeconds(Time2);
        SceneManager.LoadScene("2 level");
    }
    IEnumerator k()
    {
        yield return new WaitForSeconds(1);
        /*transtion2.SetActive(false);*/
    }
    
    public void gh()
    {
        
        StartCoroutine(y());
    }
}
