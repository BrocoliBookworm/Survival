using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : HealthManager
{
    public float rotationSpeed;

    // where is the player
    public Transform player;

    // target to chase
    public Transform target;

    // hit with explosive bullet check
    public bool explosionHit = false; 

    public float speed;

    public Transform spawnPoint;

    NavMeshAgent agent; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
        agent.updateRotation = false;
        agent.updateUpAxis = false; 
    }

    // Update is called once per frame
    void Update()
    {
        // Movement();
        Target();

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<EnemyController>())
        {
            return;
        }

        if(other.GetComponent<Bullet>())
        {
            return;
        }

        if(other.GetComponent<MultiBullet>())
        {
            Debug.Log("hit multi");
            Destroy(other.gameObject);
            TakeDamage(1);
        }
    }

    // public void Movement()
    // {
    //     Vector3 pos = transform.position;
        
    //     Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);

    //     pos += transform.rotation * velocity;

    //     transform.position = pos;
    // }

    public void Target()
    {
        // if the player is null
        if(player == null)
        {
            //Find the player and make them the target
            target = GameObject.FindWithTag("Player").transform;
            
            // if the target is not null 
            if(target != null)
            {
                // the player is the target's transform
                player = target.transform;
            }
        }

        // your destination is player's (target's) transform
        agent.SetDestination(player.position);
        
        if(player == null)
        {
            return; //Try again
        }

        // Vector3 dir = player.position - transform.position;
        // dir.Normalize();

        // float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        // Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        // transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
    }

    // Cooldown on getting damaged by enemies
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.2f);
        explosionHit = false; 
    }

    public override void TakeDamage(int damageTaken)
    {
        if(!explosionHit)
        {
            explosionHit = true; 
            currentHealth = currentHealth - damageTaken;
            StartCoroutine(Cooldown()); 
        }
    }

    public override void Die()
    {
        EnemySpawner.Instance().currentEnemies--;
        
        Destroy(gameObject);
    }
}
