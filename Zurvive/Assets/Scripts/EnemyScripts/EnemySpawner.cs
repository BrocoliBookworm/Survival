using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner _instance;
    public GameObject enemyPrefab;

    float enemyRate = 5.0f; // Timer for spawning the next enemy wave

    float nextEnemy = 1.0f; // Timer to spawning the next enemy 

    float spawnDistance = 10.0f; // How far to spawn enemies

    public int spawnAmount;

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

        if(nextEnemy <= 0)
        {
            Spawn();
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;

            if(enemyRate < 1)
            {
                enemyRate = 1f;
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

       for(int i = 0; i < spawnAmount; i++)
       {
           Vector3 offset = Random.onUnitSphere;
           offset.z = 0;
           offset = offset.normalized * spawnDistance;

           Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
           currentEnemies++;
       }

        wave++;
        Debug.Log("End Wave: " + wave);
    }
}
