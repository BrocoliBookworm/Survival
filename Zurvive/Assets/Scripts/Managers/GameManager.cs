using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject thePlayer;

    public Transform playerLocation;

    public GameObject theBoss;

    public bool bossSpawn = false;

    public Transform bossSpawnPoint;

    public GameObject deathEffect;

    private static bool won = false;

    private static bool gamePaused = false;

    private static bool playing = false;

    public int score;

    private int addScore = 10;  

    public static GameManager Instance()
    {
        if(_instance == null)
        {
            GameObject go = new GameObject("GameManager");
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
        playing = true;
        score = 0;

        Instantiate(thePlayer, transform.position, Quaternion.identity);

        playerLocation = thePlayer.transform; 

    }

    public void AddScore()
    {
        score += addScore;
        // text update
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinGame()
    {

    }

    public void EndGame()
    {

    }

    public void Pause()
    {
        Time.timeScale = 0f; 
        gamePaused = true;
        playing = false; 
    }

    public void Resume()
    {
        Time.timeScale = 1f; 
        gamePaused = false; 
        playing = true; 
    }
}
