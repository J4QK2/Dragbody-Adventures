using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet4pl : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    private float BetweenAttackTime;
    public float stAttackTime;
    public LayerMask whatIsSolid;
    public GameObject DamageEffect;
    private Animator camAnim;
    private move pl;

    bool a = false;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        pl = FindObjectOfType<move>();

    }
    private void Update()
    {

        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {camAnim.SetTrigger("shake2");
            if(BetweenAttackTime <= 0)
            {
                  pl.health -= damage;
                BetweenAttackTime = stAttackTime;
                Destroy(gameObject);
                
            }
            else
            {
                BetweenAttackTime -= Time.deltaTime;
            }
            
        }
    }
}
