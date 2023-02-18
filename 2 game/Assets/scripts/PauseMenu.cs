using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public Animator transition;
    public float iime;
    public GameObject left;
    public GameObject right;
    public GameObject opt;
    public Animator anim;
    public float audTime;
    public t aud;
    public AudioMixer audmix;
   void Start()
    {
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
    }

    public void SetVolume(float volume)
    {
        audmix.SetFloat("volume", volume);
    }
    public void NextScene()
    {
        StartCoroutine(l());
Time.timeScale = 1f;
    }
    IEnumerator l()
    {
        transition.SetTrigger("trans(start)");
        yield return new WaitForSeconds(iime);
        SceneManager.LoadScene("menu");
        
    }

    public void Options()
    {
        opt.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OptEnd()
    {
        opt.SetActive(false);
        gameObject.SetActive(true);
    }
    public void Setup2()
    {

        gameObject.SetActive(true);
        anim.SetBool("tyrar", true);
        left.SetActive(false);
        right.SetActive(false);
        Time.timeScale = 0f;
        aud.audioSource.spatialBlend = audTime;
    }
    public void BackTotheGame()
    {
        gameObject.SetActive(false);
        left.SetActive(true);
        right.SetActive(true);
        Time.timeScale = 1f;
        aud.audioSource.spatialBlend = 0;
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("menu");
        
    }
}
