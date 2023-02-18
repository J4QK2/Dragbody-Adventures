using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement and other")]
    public GameObject floatingDamge;
    
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
    
    

    [Header("References")]
    private move player;
    private highscore1 hey;
    private Animator anim;
    private highscore2 hey2;
    private Animator camAnim;
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
        hey = FindObjectOfType<highscore1>();
        sr = GetComponent<SpriteRenderer>();
        matDeath = Resources.Load("redmother", typeof(Material)) as Material;
        matPDeath = Resources.Load("redmf", typeof(Material)) as Material;
        matDefault = sr.material;
        hey2 = FindObjectOfType<highscore2>();
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

        if (health <= 0 && !secTime)
        {
            
            hey.Score();
             secTime = true;
           
            Destroy(gameObject);
           Instantiate(Effect, transform.position, Quaternion.identity);
            camAnim.SetTrigger("shake");
           
        }
        else{
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

        if (hey.number >= 260 && !oneTime)
        {
            health += healthInc;
            oneTime = true;
        }
        
        if(player.health == 0){
            damage = 0;
            normalspeed = 0;
        }
    }
       
    
   
          
            
    void Reset()
    {
        sr.material = matDefault;
    }
        



    public void TakeDamage(int damage)
    {
        stoptime = ststoptime;
        health -= damage;
        sr.material = matDeath;
        s.Play();
       
    }
    public void OnTriggerStay2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            
            if(BetweenAttackTime <= 0)
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
        
        normalspeed =0.9f;
    }
    public void EnemyAttack()
    { 
        if(player.health != 0)
        {
            camAnim.SetTrigger("shake");
        }
        
               player.health -= damage;
               BetweenAttackTime = stAttackTime;

        StartCoroutine(player.ui());

        
    }
    
}
