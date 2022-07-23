using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject thePlayer;

    public Transform playerLocation;

    public GameObject theBoss;

    // is the boss spawned
    public bool bossSpawn = false;

    public Transform bossSpawnPoint;

    public GameObject deathEffect;

    // did you win
    private static bool won = false;

    private static bool gamePaused = false;

    private static bool playing = false;

    public int score;

    public GameObject powerGunHolder; // holder for the power gun transform 

    // reference to player controller
    public PlayerShooter playerShoot; 

    private int addScore = 10;  

    // how many multishot collectibles have you collected
    public int multiCollect = 0; 

    // how many power gun collectibles have you collected
    public int powerCollect = 0; 

    // how many turret supplies have you collected
    public int turretCollect = 0; 

    // do you have the required amount of collectibles to unlock the power Gun weapon
    public bool powerGunAcquired = false; 

    // do you have enough supplies to place a turret
    public bool turretPlace = false; 

    public static GameManager Instance() // creates a singular instance of a gamemanager
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
        GameObject shot = GameObject.FindGameObjectWithTag("Player");

        playerShoot = shot.GetComponent<PlayerShooter>();

        // Instantiate(thePlayer, transform.position, Quaternion.identity);

        // playerLocation = thePlayer.transform; 

    }

    public void AddScore()
    {
        score += addScore;
        // text update
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
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

    public void PlayGame() 
    {

    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    // ran when a player picks up a multishot collectible
    public void MultiCollected()
    {
        multiCollect++; 

        if(multiCollect >= 4) // if you have the multi shot requirements set it active
        {
            playerShoot.hasMulti = true;
            powerGunHolder.SetActive(true);  
        }
    }

    // ran when a player picks up a power gun collectible
    public void PowerCollected()
    {
        powerCollect++;

        if(powerCollect >= 4)
        {
            playerShoot.hasPowerGun = true; 
        }
    }
}
