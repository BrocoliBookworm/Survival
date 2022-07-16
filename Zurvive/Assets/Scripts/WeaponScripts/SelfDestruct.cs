using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private float timer = 0.5f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when timer is over destroy the gameobject
        timer -= Time.deltaTime;

        if(timer <= 0)
        { 
            Destroy(gameObject); 
        }
    }
}
