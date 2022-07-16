using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    public float timer;
    public Vector3 velocity;
    public GameObject explosion; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the bullet forwards at the velocity * the time
        transform.position += velocity * Time.deltaTime;

        timer -= Time.deltaTime;

        if(timer <= 0) // if the timer runs out explode the exploding bullet
        {
            StartCoroutine(Explode(1));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag == other.tag)
        {
            return;
        }

        // if you hit an enemy explode immediately
        if(other.GetComponent<EnemyController>()) // hit tilemap collider explode)
        {
            StartCoroutine(Explode(0));
        }
    }

    // spawns the explosion
    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time); 
        Destroy(gameObject); 
        Instantiate(explosion, transform.position, transform.rotation); 
    }
}
