using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject healthPickUpEffect; // effect of the health pickup for later

    private HealthSpawner healthSpawn; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("HealthPickup");

        healthSpawn = temp.GetComponent<HealthSpawner>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerController>())
        {
            Pickup(other); 
        }
    }

    void Pickup(Collider2D player)
    {
        // Spawn the effect here
        // var clone = Instantiate(healthPickUpEffect, transform.position, transform.rotation);

        // Remove the object
        // Destroy(clone, 2f); 
        healthSpawn.healthExists = false; 
        healthSpawn.SetTimer(); 
        Destroy(gameObject); 
    }
}
