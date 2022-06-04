using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HealthManager
{
    public float speed = 10;

    private int maxHealth = 5;

    private float invulnerableTimer = 0; // invulnerability from damage timer

    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        FaceMouse();
        Invulnerability();

        if(currentHealth <= 0)
        {
            // Die();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.layer == other.gameObject.layer)
        {
            return;
        }

        if(other.GetComponent<EnemyController>())
        {
            Debug.Log("HIT BY ENEMYCONTROLLER");
            TakeDamage(1);
            return;
        }
    }

    public override void Invulnerability()
    {
        if(invulnerableTimer > 0)
        {
            invulnerableTimer -= Time.deltaTime;
            Debug.Log(invulnerableTimer);

            if(invulnerableTimer <= 0)
            {
                gameObject.layer = correctLayer;

                if(spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
            }
            else
            {
                if(spriteRend != null)
                {
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }
    }

    public override void TakeDamage(int damageTaken)
    {
        Debug.Log(currentHealth);
        currentHealth = currentHealth - damageTaken;

        invulnerableTimer = 2f;

        gameObject.layer = 10;
    }

    public void Movement()
    {
        Vector3 pos = transform.position;

        velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        velocity = velocity.normalized * speed * Time.deltaTime;

        pos += velocity;
        transform.position = pos;
    }

    void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    public override void Die()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
