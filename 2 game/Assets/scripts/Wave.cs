using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
   public class vave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;

    }
    public vave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoints;

    public float timeBwWaves = 5f;
    public float wavecount;

    private float searchCount = 1f;

    private SpawnState state = SpawnState.COUNTING;
    void Start()
    {
        wavecount = timeBwWaves;
        if(spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points stupid");
        }
    }

    void Update()
    {
       
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if(wavecount <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            wavecount -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Complete");

        state = SpawnState.COUNTING;
        wavecount = timeBwWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All complete");
        }
        else
        {
            nextWave++;
        }

       
    }

    bool EnemyIsAlive()
    { 
        searchCount -= Time.deltaTime;
        if (searchCount <= 0f)
        {
            searchCount = 1f;
           if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            return false;
        }
        }
        return true;
    }

    IEnumerator SpawnWave(vave _wave)
    {
        Debug.Log("spawning wave" + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i=0; i<_wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
       Debug.Log("Spawning enemy: " + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
