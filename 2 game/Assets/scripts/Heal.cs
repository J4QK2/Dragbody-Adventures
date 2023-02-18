using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private move player;
    float playerMax;
    public float heal;
    private SpawnPotion sph;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<move>();
        sph = FindObjectOfType<SpawnPotion>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch(player.health == 14 ? 1: player.health == 13 ? 2: player.health < 12 ? 3: -1)
            {
                case 1:
                    player.health += heal - 2;
                    Destroy(gameObject);

                    break;
                case 2:
                    player.health += heal - 1;
                    Destroy(gameObject);
                    break;
                case 3:
                    player.health += heal;
                    Destroy(gameObject);
                    break;
            }
        }
    }
    
}
