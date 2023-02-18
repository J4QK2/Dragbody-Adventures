using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover2 : MonoBehaviour
{
    public Animator transition;
    public float iime;
    public GameObject left;
    public GameObject right;
    
    private highscore2 hey2;
    
    public int number2;
    public GameObject ES2;
    public Animator anim;
    public float time;

    void Start()
    {
        hey2 = FindObjectOfType<highscore2>();
        number2 = hey2.number;
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
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
    public void GameOverCity()
    {SceneManager.LoadScene("2 level");
        
        Time.timeScale = 1f;
    }
    public void GameOverCity2()
    {
        SceneManager.LoadScene("menu");

        Time.timeScale = 1f;
    }
}
