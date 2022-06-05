using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    private static WaveSpawner _instance;

    public enum spawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform Walker;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    private int cycleComplete = 0;

    public Transform[] walkerSpawnPoints;

    private float timerBetweenWaves = 10f;
    private float waveCountDown;

    private float walkerSpawnDistance = 2f;

    private Transform _sp;

    private spawnState state = spawnState.COUNTING;

    public static WaveSpawner Instance()
    {
        if(_instance == null)
        {
            GameObject go = new GameObject("WaveSpawner");
            go.AddComponent<WaveSpawner>();
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
        waveCountDown = timerBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == spawnState.WAITING)
        {
            WaveCompleted();
        }

        if(waveCountDown <= 0)
        {
            if(state != spawnState.SPAWNING)
            {
                StartCoroutine(spawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    IEnumerator spawnWave(Wave _wave)
    {
        state = spawnState.SPAWNING;

        // spawn
        for(int i = 0; i < _wave.count; i++)
        {
            SpawnWalkers(_wave.Walker);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = spawnState.WAITING;

        yield break;
    }

    void WaveCompleted()
    {
        state = spawnState.COUNTING;
        waveCountDown = timerBetweenWaves;

        if(nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            cycleComplete++;
        }
        else
        {
            nextWave++;
        }
    }

    void SpawnWalkers(Transform walker)
    {
        Transform _spWalker = walkerSpawnPoints[Random.Range(0, walkerSpawnPoints.Length)];

        Vector3 offset = Random.onUnitSphere;
        offset.z = 0;
        
        offset = offset.normalized * walkerSpawnDistance;

        Instantiate(walker, _spWalker.position + offset, _spWalker.rotation);
    }
}
