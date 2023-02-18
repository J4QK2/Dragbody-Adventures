using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAllScript : MonoBehaviour
{
    public bool t = false;
    bool f = false;
    public Animator camAnim;
    public Animator pl;
    public float time;
    public float timeForF;
    public Animator KillAll;
    public GameObject KillAll2;
    public Animator KillAllim;
    public GameObject KillAll2im;
    public GameObject left;
    public GameObject right;
    void Start()
    {
        camAnim.updateMode = AnimatorUpdateMode.UnscaledTime;
        KillAll.updateMode = AnimatorUpdateMode.UnscaledTime;
        pl.updateMode = AnimatorUpdateMode.UnscaledTime;
        KillAllim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
	void Update()
    {
        if (!f && !t)
        {
              StartCoroutine(wait());
            t = true;
            
        }else if (f = true)
        {
            Time.timeScale = 1f;
            f = false;
           
        }
            
       
        
    }
	IEnumerator wait()
    {

        Time.timeScale = 0f;
        KillAll2.SetActive(true);
        KillAll.SetTrigger("kill");
        pl.SetTrigger("K");
        left.SetActive(false);
        right.SetActive(false);
        
        KillAll2im.SetActive(true);
        
        /*yield return new WaitForSeconds(1);*/
        yield return new WaitForSecondsRealtime(time);
        KillAll2.SetActive(false);
        camAnim.SetTrigger("shakeGun");
        KillAll2im.SetActive(false);
        
        left.SetActive(true);
        right.SetActive(true);
        f = true;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }

        
    }
   
}
