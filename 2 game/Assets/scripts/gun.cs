using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform bulletPoint;
    public Transform bulletPoint2;
    private float ShotTime;
    public float StartShotTime;
    private move player;
    public Joystick joystick;
    private float rotz;
    private Vector3 difference;
    public AudioSource shootSound;
    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<move>();
    }

    void Update()
    {
       
        rotz = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);
        if (ShotTime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (joystick.Horizontal != 0 || joystick.Vertical != 0 ) {
                Shot();
            }
            }
        }
        else
        {
            ShotTime -= Time.deltaTime;
        }
    }
    public void Shot()
    {
       if(player.stamina > 0 && player.stamina >=10)
        {
 Instantiate(bullet, bulletPoint.position, transform.rotation);
        Instantiate(bullet, bulletPoint2.position, transform.rotation);
        ShotTime = StartShotTime;
        shootSound.Play();
        player.stamina -= 8f;
        }
       
    }
}
