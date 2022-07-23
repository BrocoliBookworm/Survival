using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerExplosion : MonoBehaviour
{
    private Vector2 center; 
    public float radius; 

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, radius); 

        foreach(Collider2D c in enemiesHit)
        {
            EnemyController enemies = c.GetComponent<EnemyController>(); 

            if(enemies != null)
            {
                enemies.TakeDamage(3); 
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius); 
    }

    public void Destroy()
    {
        Destroy(gameObject); 
    }
}
