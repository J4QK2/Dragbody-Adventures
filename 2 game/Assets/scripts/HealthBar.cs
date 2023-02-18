using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float cur;
    private move player;
    

    void Start()
    {
        player = FindObjectOfType<move>();
        SetMaxHealth();
    }
 
    public void SetMaxHealth()
    {
        slider.maxValue = player.health;
        slider.value = player.health;
    }

    private void Update()
    {
        cur = player.health;

        SetHealth();
    }

    public void SetHealth()
    {
        slider.value = cur;
    }
}
