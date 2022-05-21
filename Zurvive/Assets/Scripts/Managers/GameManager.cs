using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject thePlayer;

    public GameObject theBoss;

    public bool bossSpawn = false;

    public Transform bossSpawnPoint;

    public GameObject deathEffect;

    private static bool won = false;

    private static bool gamePaused = false;

    private static bool playing = false;

    public static GameManager Instance()
    {
        if(_instance == null)
        {
            GameObject go = new GameObject("GameManager");
            go.AddComponent<GameManager>();
        }

        return _instance;
    }

    public int score;

    void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
