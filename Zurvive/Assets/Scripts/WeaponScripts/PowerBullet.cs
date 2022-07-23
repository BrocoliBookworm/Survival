using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBullet : MonoBehaviour
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
        transform.position += velocity * Time.deltaTime;

        timer -= Time.deltaTime; 

        if(timer <= 0)
        {
            StartCoroutine(Explode(0)); 
        }   
    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time); 
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation); 
    }
}
