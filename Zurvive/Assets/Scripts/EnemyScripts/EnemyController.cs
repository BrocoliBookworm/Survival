using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : HealthManager
{
    public float rotationSpeed;

    public Transform player;

    public Transform target;

    public float speed;

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
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
            TakeDamage(1);
            return;
        }
    }

    public void Movement()
    {
        Vector3 pos = transform.position;
        
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);

        pos += transform.rotation * velocity;

        transform.position = pos;
    }

    public void Target()
    {
        if(player == null)
        {
            //Find the player
            target = GameObject.FindWithTag("Player").transform;
            
            if(target != null)
            {
                player = target.transform;
            }
        }
        
        if(player == null)
        {
            return; //Try again
        }

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
    }

    public override void TakeDamage(int damageTaken)
    {
        currentHealth = currentHealth - damageTaken;
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
