using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HealthManager
{
    // How fast player moves
    public float speed = 10;

    // maximum health they have
    private int maxHealth = 5;
    public Rigidbody2D rb2d; 

    private float invulnerableTimer = 0; // invulnerability from damage timer

    Vector2 movement; // velocity for player movement
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement();
        FaceMouse();
        Invulnerability();

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    // use LateUpdate because you want to move the player after all the other checks were done
    void LateUpdate()
    {
        Movement(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.layer == other.gameObject.layer)
        {
            return;
        }

        // if you touch the enemy take one unit of damage
        if(other.GetComponent<EnemyController>())
        {
            TakeDamage(1);
            return;
        }

        // if you touch the collectible pick it up
        if(other.GetComponent<Collectibles>())
        {
            GameManager.Instance().Collected(); 
        }

        // if you touch the barrier & you've collected all the collectibles go to the next level
        if(other.gameObject.layer == 16 && GameManager.Instance().collectibleRequired == true)
        { 
            GameManager.Instance().NextLevel(); 
        }
    }

    // temp invulnerability so player's don't die to multiple enemies touching them at once
    public override void Invulnerability()
    {
        if(invulnerableTimer > 0)
        {
            invulnerableTimer -= Time.deltaTime;
            Debug.Log(invulnerableTimer);

            if(invulnerableTimer <= 0)
            {
                gameObject.layer = correctLayer; // place the gameobject onto the correct gameobject layer for the player that was preset

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

        gameObject.layer = 10; // puts the player on the invulnerability layer
    }

    public void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // movement for horizontal is stored in this
        movement.y = Input.GetAxisRaw("Vertical"); // movement for vertical movement is stored in this


        // move based off the rigidbody's position plus the velocity mulitplied by speed and time
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime); 

        // movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        // movement = movement.normalized * speed * Time.deltaTime;

        // pos += movement;
        // transform.position = pos;
    }

    // player faces the direction of the mouse
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
