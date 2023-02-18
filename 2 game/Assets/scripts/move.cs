using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class move : MonoBehaviour
{
    [Header("Movement")]
    public Joystick joystick;
    bool slow = false;
    Vector2 movement;
    public float speed = 5f;
    float a = 0.01f;
    public float health;
    public Rigidbody2D rb;
    public float push;
    public GameObject DamageEffect;
    public float deathEffect;
    public float iime;
    public float stamina;
    public GameObject lowst;
    private int startingPitch = 1;
    private int timeToDecrease = 5;

    [Header("References")]
    public GameOver gameo;
    public KillAllScript KAS;
    public gameover2 gameo2;
    public PauseMenu pause;
    public selectweapon sw;
    private Animator camAnim;
    public Enemy enen;
    private highscore1 hey;
    private highscore2 hey2;
    public Animator animator;
    

    [Header("Bools")]
    bool thirdTime = false;
    bool onetime = false;
    private bool facingRight = true;
    bool g = false;
    // Update is called once per frame
    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        hey = FindObjectOfType<highscore1>();
        hey2 = FindObjectOfType<highscore2>();
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        
    }



    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
        if(movement.x != 0)
        {
            animator.SetBool("Iswalking", true);
           
        }
        else
        {
            animator.SetBool("Iswalking", false);
        }

        if(!facingRight && movement.x > 0)
        {
            Flip();
        }
        else if(facingRight && movement.x < 0)
        {
                Flip();
            
        }
        
        if(stamina < 30)
        {
            lowst.SetActive(true);
        }
        if(stamina > 30)
        {
            lowst.SetActive(false);
        }
        if(stamina < 100 && Time.timeScale != 0)
        {
            StartCoroutine(stam());
            
        }
        
        if (health <= 0 && GameObject.Find("tb") == null)
        {
           
            StartCoroutine(gameo.st());
            camAnim.SetTrigger("dead");
        }
        if(health <= 0 && GameObject.Find("tt") == null)
        {
            StartCoroutine(gameo2.st());
            camAnim.SetTrigger("citydeath");
        }

        if (health <= 0 && !thirdTime)
        {
            animator.SetTrigger("isdead");
           
            thirdTime = true;
        }
        
    }
void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime * 1 / Time.timeScale);
    }
    public IEnumerator stam()
    {
        yield return new WaitForSeconds(1);

        stamina += Time.deltaTime * 14;
    }
    public void TakeDamage(int damage)
    {
       
        health -= damage;
    }
    
    public void EnemySpeed()
    {
        
        slow = !slow;
        Time.timeScale = slow ? .1f : 1f;
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BOMB"))
        {
            enen.dead();
            onetime = true;
            Destroy(other.gameObject);
        }
    }*/

    public IEnumerator ui()
    {
        DamageEffect.SetActive(true);
        yield return new WaitForSeconds(deathEffect);
        DamageEffect.SetActive(false);
    }
    public void ForTest()
    {
        sw.wapon = sw.Weapons[1];
        sw.wapon.SetActive(true);
        StartCoroutine(hey.sGun());
    }
    public void FirstWeopon()
    {
        
        int sizeOfWeapons;
        sizeOfWeapons = Random.Range(0, sw.Weapons.Length);
        sw.wapon = sw.Weapons[sizeOfWeapons];
        switch (sizeOfWeapons)
        {
            case 0:
                
                sw.wapon.SetActive(true);
                StartCoroutine(hey.fGun());
                break;
            case 1:
                KAS.t = false;
                sw.wapon.SetActive(true);
                StartCoroutine(hey.sGun());
                break;
            case 2:
                sw.defWeapon.SetActive(false);
                sw.wapon.SetActive(true);
                StartCoroutine(hey.tGun());
                break;
        }
        
    }
    public void FirstWeopon2()
    {

        int sizeOfWeapons;
        sizeOfWeapons = Random.Range(0, sw.Weapons.Length);
        sw.wapon = sw.Weapons[sizeOfWeapons];
        switch (sizeOfWeapons)
        {
            case 0:

                sw.wapon.SetActive(true);
                StartCoroutine(hey2.fGun());
                break;
            case 1:
                KAS.t = false;
                sw.wapon.SetActive(true);
                StartCoroutine(hey2.fGun());
                break;
            case 2:
                sw.defWeapon.SetActive(false);
                sw.wapon.SetActive(true);
                StartCoroutine(hey2.fGun());
                break;
        }

    }
}
