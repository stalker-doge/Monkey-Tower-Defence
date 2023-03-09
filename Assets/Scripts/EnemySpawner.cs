using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefab;
    [SerializeField] public GameObject[] enemyBosses;
    [SerializeField] private float spawnDelay = 3f;
    private float spawnTimer;
    private float timer;
    [SerializeField] private int enemyCount = 5;
    private int counter = 0;
    [SerializeField] private int spawnWaves = 5;
    private int waveCounter = 0;
    [SerializeField] private float timeBetweenWaves = 10f;
    private float waveTimer = 0;
    private bool bossSpawn = true;
    [SerializeField] private float restTime = 30f;
    private float restTimer = 0;
    private bool rest = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rest)
        {
            restTimer += Time.deltaTime;
            if (restTimer > restTime)
            {
                rest = false;
                restTimer = 0;
            }
        }
        else
        {
            waveTimer += Time.deltaTime;
            if (waveTimer > timeBetweenWaves)
            {
                waveTimer = 0;
                SpawnWaves();
            }
        }
    }


    IEnumerator SpawnEnemy()
    {
        Vector3 position = new Vector3(transform.position.x + Random.Range(-1f, 1f), 0, transform.position.z + Random.Range(-1, 1f));
        GameObject enemy = Instantiate(enemyPrefab[Random.Range(0, 2)], position, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
    }

    void SpawnBosses()
    {
        Vector3 position = new Vector3(transform.position.x + Random.Range(-1f, 1f), 0, transform.position.z + Random.Range(-1, 1f));
        GameObject enemy = Instantiate(enemyBosses[0], position, Quaternion.identity);
    }

    private void SpawnWave()
    {
        while (counter < enemyCount)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnDelay)
            {
                StartCoroutine(SpawnEnemy());
                spawnTimer = 0;
                counter++;
            }
        }
        counter = 0;
    }

    private void SpawnWaves()
    {
        if (waveCounter < spawnWaves)
        {
            SpawnWave();
            waveCounter++;
        }else if(bossSpawn)
        {
            SpawnBosses();
            bossSpawn = false;
        }
    }
    public int GetWave()
    {
        return waveCounter;
    }
    public int GetTotalWaves()
    {
        return spawnWaves;
    }
}
