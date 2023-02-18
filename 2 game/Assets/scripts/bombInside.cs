using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombInside : MonoBehaviour
{
    public float damage = 4;
    private Animator anim;
    private move player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<move>();
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("boom");
        }
    }
    public void TakeDamage()
    {
        player.health -= damage;

    }
}
