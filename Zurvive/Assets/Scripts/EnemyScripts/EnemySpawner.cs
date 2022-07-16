using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner _instance;
    public GameObject walkerPrefab; // walker enemy

    public float walkerEnemyRate = 5.0f; // Timer for spawning the next enemy wave

    // spawning enemy rates
    public float runnerEnemyRate; 

    public float tankEnemyRate; 

    public float bossEnemyRate; 

    float nextEnemy = 1.0f; // Timer to spawning the next enemy 

    float spawnDistance = 2.0f; // How far to spawn enemies

    public int spawnAmount; // how many do you spawn

    [SerializeField]
    private int multiplierEffect = 1;

    public int currentEnemies = 0;
    public int wave = 0;

    public static EnemySpawner Instance()
    {
        if(_instance == null)
        {
            GameObject go = new GameObject("EnemySpawner"); //assign instance to this instance of the class
            go.AddComponent<GameManager>();
        }

        return _instance;
    }

    void Awake() 
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;

        // if the timer to spawning the next enemy is <= 0 spawn enemies
        if(nextEnemy <= 0)
        {
            Spawn();
            nextEnemy = walkerEnemyRate; // reset the timer
            walkerEnemyRate *= 0.9f; // decrease the timer by 10%

            if(walkerEnemyRate < 1) // if the timer is less than 1 set it to 1
            {
                walkerEnemyRate = 1f;
            }
        }
    }

    void Spawn()
    {
        // nextEnemy -= Time.deltaTime;

        // if(nextEnemy <= 0)
        // {
        //     nextEnemy = enemyRate;
        //     enemyRate *= 0.9f; 
        //     Debug.Log("Enemy Rate: " + enemyRate);
        //     Debug.Log("Next Enemy: " + nextEnemy);

        //     if(enemyRate < 15)
        //     {
        //         enemyRate = 15f;
        //     }
        // }

        if(wave > 0) // if the wave is larger than 1
        {
            spawnAmount *= multiplierEffect; // multiply the amount of enemies that spawn next wave by the spawn amount
            Debug.Log("Wave: " + wave);
            Debug.Log("Spawn Amount: " + spawnAmount);
        }

       for(int i = 0; i <= spawnAmount; i++)
       {
           Vector3 offset = Random.onUnitSphere;
           offset.z = 0;
           offset = offset.normalized * spawnDistance;

           Instantiate(walkerPrefab, transform.position + offset, Quaternion.identity);
           currentEnemies++;
       }

       // maybe randomize the enemies spawned????? 

       // multiple for loops is super time intensive. randomizing more efficient that way

       // look at how spawn worked for Emergency Rescue, might be better method of using spawners

       //if level 2 spawn walkers

       // if level 3 spawn tanks

       // spawn for every enemy

        wave++;
        Debug.Log("End Wave: " + wave);
    }

    void SpawnWalker()
    {

    }

    void SpawnTank()
    {

    }

    void SpawnBoss()
    {

    }
}
