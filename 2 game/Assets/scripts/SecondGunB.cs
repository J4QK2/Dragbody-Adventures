using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGunB : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject DamageEffect;
    private Animator camAnim;
    private move pl;
    private UltraScr k;
    bool a = false;

    private void Start()
    {
        camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        pl = FindObjectOfType<move>();
        k = FindObjectOfType<UltraScr>();
    }
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Enemyv2"))
            {
                hitInfo.collider.GetComponent<Enemylvl2>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Enemyv22"))
            {
                hitInfo.collider.GetComponent<lvl2darkEnemy>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Enemy2"))
            {

                hitInfo.collider.GetComponent<enemy2>().TakeDamage(damage);
            }
            Instantiate(DamageEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            camAnim.SetTrigger("shake3");
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }

}
