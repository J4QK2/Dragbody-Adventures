using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2darkEnemy : MonoBehaviour
{
    [Header("Movement and other")]
    public GameObject floatingDamge;

    /*public float offset;*/
    public int health;
    public float speed;
    public int healthInc;
    private float stoptime;
    public float ststoptime;
    public float normalspeed;
    private float BetweenAttackTime;
    public float stAttackTime;
    public float damage;
    public float effecttime;
    public float deatheffect;
    public float deathTime;
    public AudioSource s;
    /*public float deltaX;
    public float deltaY;
    public GameObject bullet;
    public Transform bulletPoint;*/


    [Header("References")]
    private move player;
    private highscore2 hey2;
    private Animator anim;
    private Animator camAnim;
    /*private float rotz;*/
    [Header("Materials")]
    public GameObject Effect;
    private Material matDeath;
    private Material matDefault;
    private Material matPDeath;
    
    SpriteRenderer sr;

    bool oneTime = false;
    bool secTime = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<move>();
        normalspeed = speed;
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        hey2 = FindObjectOfType<highscore2>();
        sr = GetComponent<SpriteRenderer>();
        matDeath = Resources.Load("redmother", typeof(Material)) as Material;
        matPDeath = Resources.Load("redmf", typeof(Material)) as Material;
        matDefault = sr.material;

    }

    private void Update()
    {
        if (stoptime <= 0)
        {
            speed = normalspeed;
        }
        else
        {
            speed = -0.9f;
            stoptime -= Time.deltaTime;
        }

        if (health <= 0 && !secTime)
        {
           
            hey2.Score();
            secTime = true;

            Destroy(gameObject);
            Instantiate(Effect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
            /*rotz = Mathf.Atan2(deltaX, deltaY) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
            if (deltaX != 0 || deltaY != 0)
            {
                Shot();
            }*/
        }
        else
        {
            Invoke("Reset", deatheffect);
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

        if (hey2.number >= 260 && !oneTime)
        {
            health += healthInc;
            oneTime = true;
        }

        if (player.health == 0)
        {
            damage = 0;
            normalspeed = 0;
        }
    }


    /*public void Shot()
    {
        Instantiate(bullet, bulletPoint.position, transform.rotation);
   
        
    }*/


    void Reset()
    {
        sr.material = matDefault;
    }




    public void TakeDamage(int damage)
    {
        stoptime = ststoptime;
        health -= damage;
        
        s.Play();

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
    IEnumerator lol()
    {
        normalspeed = 0;


        yield return new WaitForSeconds(effecttime);

        normalspeed = 5f;
    }
    public void EnemyAttack()
    {
        if (player.health != 0)
        {
            camAnim.SetTrigger("sdark");
        
        }

        StartCoroutine(lol());
        player.health -= damage;
        BetweenAttackTime = stAttackTime;
        
        Destroy(gameObject);
    }
    
}
