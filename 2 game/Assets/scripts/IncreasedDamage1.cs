using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedDamage1 : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
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
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {

            if (hitInfo.collider.CompareTag("Enemyv2"))
            {
                hitInfo.collider.GetComponent<Enemylvl2>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Enemyv22"))
            {
                hitInfo.collider.GetComponent<lvl2darkEnemy>().TakeDamage(damage);
            }
            if (hitInfo.collider.CompareTag("Enemyv223"))
            {
                hitInfo.collider.GetComponent<greenmonster>().TakeDamage(damage);
            }
            Instantiate(DamageEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            camAnim.SetTrigger("sh3");
        }


    }

}
