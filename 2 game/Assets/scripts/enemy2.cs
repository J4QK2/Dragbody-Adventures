using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    [Header("Movement and other")]
    public int health;
    public float speed;
    private float stoptime;
    public float ststoptime;
    public float normalspeed;
    private float BetweenAttackTime;
    public float stAttackTime;
    public float damage;
    public float effecttime;
    [Header("Materials")]
    public GameObject Effect;
    [Header("References")]
    private move player;
    private highscore1 hey;
    private Animator anim;
    private Animator camAnim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<move>();
        normalspeed = speed;
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        hey = FindObjectOfType<highscore1>();
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        normalspeed = 0;

        yield return new WaitForSeconds(1);

        normalspeed = 0.9f;
    }

    private void Update()
    {
            if (stoptime <= 0)
            {
                speed = normalspeed;
            }
            else
            {
                speed = -normalspeed;
                stoptime -= Time.deltaTime;
            }

            if (health <= 0)
            {
                hey.Score();
                Instantiate(Effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                camAnim.SetTrigger("shake");
            }
            if (player.transform.position.x > transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(player.health == 0)
        {
            damage = 0;
            normalspeed = 0;
          
        }
           
    }

    public void TakeDamage(int damage)
    {
        stoptime = ststoptime;
        health -= damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (BetweenAttackTime <= 0 && player.health != 0)
            {
                anim.SetTrigger("enemyAttack");
                
            }
            else
            {

                BetweenAttackTime -= Time.deltaTime;
            }

        }
    }
    IEnumerator lol()
    {
        normalspeed = 0;


        yield return new WaitForSeconds(effecttime);

        normalspeed = 0.9f;
    }
    public void EnemyAttack()
    {
        if(player.health != 0)
        {
          camAnim.SetTrigger("shake");
    
        }
          
        
        player.health -= damage;
        BetweenAttackTime = stAttackTime;
        StartCoroutine(lol());
        
    }

}


