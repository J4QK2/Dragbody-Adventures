using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class t : MonoBehaviour
{
    public int startingPitch = 1;
    public int timeToDecrease = 5;
    private move player;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.pitch > 0 && player.health == 0)
        {
            audioSource.pitch -= Time.deltaTime * startingPitch / timeToDecrease;
        }
    }
}
