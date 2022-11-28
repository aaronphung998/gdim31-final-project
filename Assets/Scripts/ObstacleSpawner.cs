using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> groundObstPrefabs;   // list of obstacle prefabs to spawn
    [SerializeField]
    private List<GameObject> groundCoinPrefabs;
    [SerializeField]
    private List<GameObject> airObstPrefabs;
    [SerializeField]
    private List<GameObject> airCoinPrefabs;
    [SerializeField]
    private GameObject flyPowerup;
    [SerializeField]
    private GameObject flyPowerdown;
    [SerializeField]
    private float spawnMinTime;         // minimum amount of time to wait before spawning
    [SerializeField]
    private float spawnMaxTime;         // maximum amount of time to wait before spawning
    [SerializeField]
    private int minSpawnsBeforePowerup;
    [SerializeField]
    private int maxSpawnsBeforePowerup;
    [SerializeField]
    private float chanceOfCoin;         // percentage chance of a coin spawning

    private float nextSpawnTime;

    private int spawnedObstacles;

    private int nextPowerupTime;

    private bool spawning;

    private bool spawnAirObstacles;

    // Start is called before the first frame update
    void Start()
    {
        spawning = true;
        nextSpawnTime = UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
        GameStateManager.OnGameOver += StopSpawning;
        spawnAirObstacles = false;
        nextPowerupTime = UnityEngine.Random.Range(minSpawnsBeforePowerup, maxSpawnsBeforePowerup + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning && Time.time >= nextSpawnTime)
        {
            if (spawnedObstacles >= nextPowerupTime)
            {
                if (spawnAirObstacles)
                {
                    GameObject obstacleObject = GameObject.Instantiate(flyPowerdown, transform);
                    spawnedObstacles = 0;
                    spawnAirObstacles = false;
                }
                else
                {
                    GameObject obstacleObject = GameObject.Instantiate(flyPowerup, transform);
                    spawnedObstacles = 0;
                    spawnAirObstacles = true;
                }

                nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
            }
            else if (spawnAirObstacles)
            {
                if (UnityEngine.Random.value < chanceOfCoin)
                {
                    int obstNum = UnityEngine.Random.Range(0, airCoinPrefabs.Count);
                    GameObject obstacleObject = GameObject.Instantiate(airCoinPrefabs[obstNum], transform);

                    nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
                    spawnedObstacles++;
                }
                else
                {
                    int obstNum = UnityEngine.Random.Range(0, airObstPrefabs.Count);
                    GameObject obstacleObject = GameObject.Instantiate(airObstPrefabs[obstNum], transform);

                    nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
                    spawnedObstacles++;
                }
                
            }
            else
            {
                if (UnityEngine.Random.value < chanceOfCoin)
                {
                    int obstNum = UnityEngine.Random.Range(0, groundCoinPrefabs.Count);
                    GameObject obstacleObject = GameObject.Instantiate(groundCoinPrefabs[obstNum], transform);

                    nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
                    spawnedObstacles++;
                }
                else
                {
                    int obstNum = UnityEngine.Random.Range(0, groundObstPrefabs.Count);
                    GameObject obstacleObject = GameObject.Instantiate(groundObstPrefabs[obstNum], transform);

                    nextSpawnTime = Time.time + UnityEngine.Random.Range(spawnMinTime, spawnMaxTime);
                    spawnedObstacles++;
                }
                
            }
            
        }
    }

    public void OnDestroy()
    {
        GameStateManager.OnGameOver -= StopSpawning;
    }

    public void StopSpawning()
    {
        spawning = false;
    }
}
