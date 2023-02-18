using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float fieldImpact;
    public float force;
    private Animator anim;
    private float waiting = 0.17f;

    public LayerMask LayerToHit;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("boom");
            StartCoroutine(wait());
            Explode();
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(waiting);
    }

    void Explode()
    {
      Collider2D[] objects =  Physics2D.OverlapCircleAll(transform.position, fieldImpact, LayerToHit);

        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldImpact);
    }
        }
