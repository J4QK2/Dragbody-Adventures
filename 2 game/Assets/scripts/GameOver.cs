using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    
    public GameObject left;
    public GameObject right;
    private highscore1 hey;
    
    public int number1;
    public int number2;
    public GameObject ES2;
    public Animator anim;
    public float time;
    
    void Start()
    {
        hey = FindObjectOfType<highscore1>();
        number1 = hey.number;
        
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        
    }
    
    public void Setup()
    {
        gameObject.SetActive(true);
        
        anim.SetBool("aaa", true);
        
        left.SetActive(false);
        right.SetActive(false);
        Time.timeScale = 0f;
    }
    public IEnumerator st()
    {
        yield return new WaitForSeconds(time);

        Setup();
        
    }
}
