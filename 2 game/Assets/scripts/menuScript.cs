using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    private highscore1 numb;
    private highscore2 hg2;
    public Animator animator;
    public TextMeshProUGUI highscor1;
    public TextMeshProUGUI highscor2;
    public Animator IngAnim;
    public Animator OptAnim;
    public GameObject jf;
    public Animator QuitAnim;
    public Animator stage1Anim;
    public Animator stage2Anim;
    public Animator back;
    public Animator fade;
    public Animator daFade;
    public AudioSource aud;
    public GameObject l;
    public GameObject stage1;
    public GameObject stage2;
    public GameObject backMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        numb = FindObjectOfType<highscore1>();
        highscor1.text = PlayerPrefs.GetInt("Highscore").ToString();
        hg2 = FindObjectOfType<highscore2>();
        highscor2.text = PlayerPrefs.GetInt("Highscore2").ToString();
        
    }

    /*void Update()
    {
        if(som != true)
        {
           GameInto();
        }
       
    }*/

   
    public void ingame()
    {
        SceneManager.LoadScene("game");
    }

    public void jumpng()
    {
        animator.SetTrigger("isjump");
    }
    public void quit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
    public void credits()
    {
        SceneManager.LoadScene("credits");
    }
   
    public void nextScene()
    {
        IngAnim.SetTrigger("Ing");
        OptAnim.SetTrigger("opt");
        QuitAnim.SetTrigger("quit");
        daFade.SetTrigger("daen");
        aud.Play();
        
    }
    public void backScene()
    {
        IngAnim.SetTrigger("Ing2");
        OptAnim.SetTrigger("opt2");
        QuitAnim.SetTrigger("quit2");
        
        
    }
    public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        PlayerPrefs.DeleteKey("Highscore2");
    }
}
