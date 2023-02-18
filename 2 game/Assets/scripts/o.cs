using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class o : MonoBehaviour
{
    private Enemy en;
    bool sec = false;
    // Start is called before the first frame update
    void Start()
    {
        en = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(en.health <= 0 && !sec)
        {
            gameObject.transform.SetParent(null);
            sec = true;
        }
    }
}
