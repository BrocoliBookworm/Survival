using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPickup; 

    public float minWait; 
    public float maxWait; 

    public bool healthExists; 

    public float timer; 

    float spawnDistance = 2.0f; 

    // Start is called before the first frame update
    void Start()
    {
        healthExists = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!healthExists && timer > 0) 
        {
            timer -= Time.deltaTime; 
        }

        if(timer <= 0 && !healthExists)
        {
            healthExists = true; 
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 offset = Random.onUnitSphere;
        offset.z = 0; 

        offset = offset.normalized * spawnDistance;

        Instantiate(healthPickup, transform.position + offset, transform.rotation); 
    }

    public void SetTimer()
    {
        timer = Random.Range(minWait, maxWait); 
    }
}
