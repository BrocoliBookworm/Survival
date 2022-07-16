using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform centralFirepoint; // location bullets fire from

    public GameObject bulletPrefab;

    public bool hasMulti = false; // has multi shot ability

    public float reloadTime = 0.9f; // how long it takes the gun to reload

    public float multiShotCooldown = 1.5f; 

    public bool shotAvailable = true; // can you currently shoot regular shots

    public bool multiShotAvailable = true; // can you currently shoot multishot

    protected float bulletForce = 30f; // how fast do the bullets move

    public GameObject multishotPrefab; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if regular shot button is pressed
        if(Input.GetButton("Fire1"))
        {
            if(shotAvailable == true)
            {
                Shoot();
                shotAvailable = false;
            }
        }   
        
        Reload();  

        // if multi-shot button pressed
        if(Input.GetButton("Fire2"))
        {
            if(hasMulti == true && multiShotAvailable == true)
            {  
                MultiShoot();
                multiShotAvailable = false; 
            }
        }

        if(multiShotAvailable != true)
        {
            MultiReload(); 
        }
    }

    //reload timer functionality
    private void Reload()
    {
        reloadTime -= Time.deltaTime;

        if(reloadTime <= 0)
        {
            reloadTime = 0.9f; 
            shotAvailable = true; 
        }
    }

    // reload timer functionality for the multi-shot ability
    private void MultiReload()
    {
        multiShotCooldown -= Time.deltaTime; 

        if(multiShotCooldown <= 0)
        {
            multiShotAvailable = true; 
            multiShotCooldown = 1.5f;
        }
    }

    // player fires explosive shot
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, centralFirepoint.position, centralFirepoint.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Access the bullets rigidbody2d component
        rb.AddForce(centralFirepoint.up * bulletForce, ForceMode2D.Impulse); // Puts force on the bullet
    }

    //Fires MultiShoot
    public void MultiShoot()
    {
        GameObject multiBullet = Instantiate(multishotPrefab, centralFirepoint.position, centralFirepoint.rotation);
        Rigidbody2D[] rb = multiBullet.GetComponentsInChildren<Rigidbody2D>();
        
        for(int i = 0; i < rb.Length; i++)
        {
            rb[i].AddForce(rb[i].transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }
}
