using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPotion : MonoBehaviour
{
    public GameObject pot;
    public float rate = 2f;
    public GameObject potPos;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnP()
    {
        MeshCollider c = potPos.GetComponent<MeshCollider>();
        float screenX;
        float screenY;
        Vector2 whereToSpawn;
        if (Time.time > nextSpawn && GameObject.Find("heart(Clone)") == null)
        {
            nextSpawn = Time.time + rate;
            StartCoroutine(sp());
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            whereToSpawn = new Vector2(screenX, screenY);
            Instantiate(pot, whereToSpawn, pot.transform.rotation);
        }
    }
    IEnumerator sp()
    {
        yield return new WaitForSeconds(4);
    }
}

