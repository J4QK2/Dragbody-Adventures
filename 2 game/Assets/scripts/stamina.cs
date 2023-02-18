using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : MonoBehaviour
{
    public Slider slider;
    public float cur;
    private move player;


    void Start()
    {
        player = FindObjectOfType<move>();
        SetMaxStamina();
    }

    public void SetMaxStamina()
    {
        slider.maxValue = player.stamina;
        slider.value = player.stamina;
    }

    private void Update()
    {
        cur = player.stamina;

        SetHealth();
        
    }

    public void SetHealth()
    {
        slider.value = cur;
    }
}
