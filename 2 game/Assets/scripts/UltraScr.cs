using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltraScr : MonoBehaviour
{
    public Slider slider;
    public float cur;
    private highscore1 hey;
    public bullet bll;
    bool b = false;
    bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        
        hey = FindObjectOfType<highscore1>();
        
        SetMaxHealth();
    }
    
    public void SetMaxHealth()
    {
       
        slider.maxValue = 100;
        slider.value = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(cur != 100 )
        {
          cur = hey.number;

        SetHealth();
        }
        if(cur == 100 && !a)
        {
            
           
        }
        
    }
    public void SetHealth()
    {
        slider.value = cur;
        /*if(cur == 100 && !b)
        {
            bll.damInc();
            b = true;
        }*/
    }
}
