using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBullet : MonoBehaviour
{
    public float timer;
    public Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the bullets forwards at the velocity * the time
        transform.position += velocity * Time.deltaTime;

        timer -= Time.deltaTime;

        if(timer <= 0) // if the timer runs out destroy the bullet
        {
            Destroy(gameObject); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == other.tag)
        {
            return;
        }

        // if you hit an enemy destroy yourself immediately
        if(other.GetComponent<EnemyController>())
        {
            Debug.Log("hit enemy controller");
            Destroy(gameObject);
        }
    }
}
