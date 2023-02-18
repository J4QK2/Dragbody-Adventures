using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    private float BetweenAttackTime;
    public float stAttackTime;
    private move player;
    private Animator camAnim;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<move>();
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (BetweenAttackTime <= 0)
            {

                EnemyAttack();
            }
            else
            {

                BetweenAttackTime -= Time.deltaTime;
            }
        }
    }
    public void EnemyAttack()
    {
        if (player.health != 0)
        {
            camAnim.SetTrigger("shake");
        }

        player.health -= damage;
        BetweenAttackTime = stAttackTime;

    }
}
