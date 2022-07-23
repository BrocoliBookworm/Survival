using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : HealthManager
{
    public float fireSpeed = 2f; // how fast the turret fires
    public float radius; // radius where the turret will fire
    public Transform target; 
    public bool detected = false; 
    public GameObject bulletPrefab; 
    public bool shotAvailable = true; 
    public Transform firepoint; 
    public float bulletForce = 30f; // speed of bullet

    private Collider2D[] enemies;
    private EnemyController enemiesHit; 
    private Vector2 dir; 

    public List<GameObject> killList = new List<GameObject>(); // kill list for turrets

    public GameObject gun; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, radius); 

        // foreach(Collider2D c in enemies)
        // {
        //     Debug.Log("Checking GO " + c.gameObject.name + " for B tag.");
        //     if(c.gameObject.GetComponent<EnemyController>())
        //     {
        //         killList.Add(c.gameObject); 
        //     }
        // }

        // if(killList.Count > 0)
        // {
        //     target = killList[0].transform; 
        // }

        // Debug.Log(enemies); 

        // Find object of type within radius

        // if(enemies[0].GetComponent<EnemyController>())
        // {
        //     target = enemies[0].transform;
        // }

        Debug.Log("target: " + target); 
        Debug.Log("target transform: " + target.transform);
        Debug.Log("target name: " + target.name);  

        // target = enemies[0].transform;
        // Debug.Log(target); 

        // if(enemies != null)
        // {
        //     target = enemies.
        // }

        Vector2 targetPos = target.position;
        Debug.Log("TargetPos: " + targetPos); 

        dir = targetPos - (Vector2)transform.position;
        Debug.Log("dir: " + dir); 

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, dir, radius);

        if(rayInfo)
        {
            Debug.Log("rayinfo true"); 
            Debug.Log("comp: " + rayInfo.collider.gameObject.layer);

            if(target.gameObject.layer == 6)
            {
                detected = true; 
                Debug.Log("detected is true"); 
            }
            else
            {
                Debug.Log("hit the else statement"); 
                detected = false; 
            }
        }

        if(detected)
        {
            gun.transform.up = dir; 
            Debug.Log("gun transform: " + gun.transform); 
        }

        // foreach(Collider2D c in enemies)
        // {
        //     enemiesHit = c.GetComponent<EnemyController>();

        //     if(enemiesHit != null)
        //     {
        //         if(shotAvailable)
        //         {
        //             // FirePointMove(); 
        //             ShootEnemies(); 
        //             shotAvailable = false; 
        //         }
        //     }
        // }

        Reload(); 

        if(currentHealth <= 0)
        {
            Die(); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if you touch the enemy take one unit of damage
        if(other.GetComponent<EnemyController>())
        {
            TakeDamage(1);
            return;
        }
    }

    // public void FirePointMove()
    // {
    //     if(enemiesHit != null)
    //     {
    //         dir = (enemiesHit.transform.position - firepoint.position).normalized;
    //     }
    // }

    public override void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

    public override void Die()
    {
        Destroy(gameObject); 
    }

    public void ShootEnemies()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, Quaternion.LookRotation(dir)); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * bulletForce, ForceMode2D.Impulse);
    }

    public void Reload()
    {
        fireSpeed -= Time.deltaTime;

        if(fireSpeed <= 0)
        {
            fireSpeed = 2f; 
            shotAvailable = true; 
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
}
