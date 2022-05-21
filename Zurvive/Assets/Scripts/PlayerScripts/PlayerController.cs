using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HealthManager
{
    public float speed = 10;

    private int maxHealth;

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

        if(currentHealth <= 0)
        {
            Die();
        }
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

    public override void TakeDamage(int damageTaken)
    {
        currentHealth = currentHealth - damageTaken;
    }

    public override void Die()
    {
        
    }
}
