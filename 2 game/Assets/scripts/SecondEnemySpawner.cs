using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondEnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Animator transition;
    public float iime;
    Vector2 whereToSpawn;
    public float rate = 2f;
    float nextSpawn = 0.0f;
    private move player;
    public GameObject potPos;

    private void Start()
    {
        player = FindObjectOfType<move>();
        transition.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
    public void quit()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }
    
   
        

    public void ingame()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1f;

    }
    void Update()
    {
        
    }
        public void ToSpawn()
    {
        MeshCollider c = potPos.GetComponent<MeshCollider>();
        float screenX;
        float screenY;
        
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rate;
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            whereToSpawn = new Vector2(screenX, screenY);
            Instantiate(enemy, whereToSpawn, enemy.transform.rotation);
        }
    }
        
        
    }
