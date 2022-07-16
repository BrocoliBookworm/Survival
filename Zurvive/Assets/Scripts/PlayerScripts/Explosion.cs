using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Explosion : MonoBehaviour
{
    private Vector2 center; 
    public float radius = 5.0f; 

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // collect the collider of every enemy in the overlap circle
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, radius);

        // for each enemy within the array, have them take damage as long as the array is not null
        foreach(Collider2D c in enemiesHit)
        {
            EnemyController enemies = c.GetComponent<EnemyController>();

            if(enemies != null)
            {
                enemies.TakeDamage(1); 
            }
        }
    }

    // draws the sphere for overlap circle
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius); 
    }

    public void Destroy()
    {
        Destroy(gameObject); 
    }
}
