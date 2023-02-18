using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
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
    float nextSpawn = 0.0f;
    public float effecttime;
    public float rateBullet;

    public GameObject bullet;
    public Transform bulletPoint;



    [Header("Materials")]
    public GameObject Effect;
    [Header("References")]
    private move player;
    private highscore2 hey2;
    private Animator anim;
    private Animator camAnim;
    private float rotz;
    private float rotz2;
    private float rotz3;
    private float rotz4;
    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<move>();
        normalspeed = speed;
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        hey2 = FindObjectOfType<highscore2>();
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
        Shot();
        if (health <= 0)
        {
            hey2.Score();
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
        if (player.health == 0)
        {
            damage = 0;
            normalspeed = 0;

        }


    }
    public void Shot()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rateBullet;

            Instantiate(bullet, bulletPoint.position, transform.rotation);

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


        }
    }

}
