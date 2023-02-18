using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenM : MonoBehaviour
{
    public GameObject enemy;

    public Transform whereToSpawn;
    public Animator anim;
    public float rate;
    float nextSpawn = 0.0f;
    private move player;
    public GameObject potPos;

    private void Start()
    {
        player = FindObjectOfType<move>();
    }

    void Update()
    {

    }
    public void ToSpawn()
    {
        
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rate;
            
            Instantiate(enemy, whereToSpawn.position, whereToSpawn.rotation);

            anim.SetTrigger("luke");
        }
    }


}
