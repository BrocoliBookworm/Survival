using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform centralFirepoint; // location bullets fire from

    public GameObject bulletPrefab;

    public GameObject grenade; 

    public int grenadesAvailable; 

    protected float pistolChamberTime = 0.5f; // how long it takes a bullet to go into the chamber of the pistol

    protected float rifleReloadTime = 0.3f; // how long it takes to reload the rifle

    public bool hasRifle = false;  // do you have the rifle

    public bool rifleActive = false; // are you currently using the rifle

    public int rifleAmmo; 

    public int rifleCapacity; 

    public bool shotAvailable = true; // can you currently shoot

    protected float bulletForce = 30f; // how fast do the bullets move

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if(hasRifle == false || rifleActive == false)
            {
                if(shotAvailable == true)
                {
                    Shoot();
                    shotAvailable = false;
                }
            } 
            

            // if the rifle is both acquired and active reload the rifle
            if(hasRifle == true && rifleActive == true)
            {
                if(rifleAmmo > 0)
                {
                    rifleAmmo--;
                    Shoot();
                }
                else
                {
                    RifleReload();
                }
            }
        }   

        Reload();   

        if(Input.GetButtonDown("Reload"))
        {
            RifleReload();
        }

        if(Input.GetButton("Fire2"))
        {
            if(grenadesAvailable > 0)
            {
                ThrowGrenade();
            }
        }
    }

    //reload the pistol
    private void Reload()
    {
        pistolChamberTime -= Time.deltaTime;

        if(pistolChamberTime <= 0)
        {
            pistolChamberTime = 0.5f; 
            shotAvailable = true; 
        }
    }

    private void RifleReload()
    {
        if(rifleCapacity >= 30)
        {
            rifleAmmo = 30;
            rifleCapacity -= 30;
        }
        else
        {
            rifleAmmo = rifleCapacity;
            rifleCapacity = 0; 
        }
    }

    // private void ShotSelect()
    // {
        // test shot available here
        // if(hasRifle == false)
        // {
        //     if(shotAvailable)
        //     {
        //         shotAvailable = false;
        //         Shoot();
        //     }   
        // }
        
    //     if(hasRifle == true)
    //     {s
    //         if(rifleActive == true)
    //         {
    //             shotAvailable = false;
    //             RifleShot();
    //         }
    //         else
    //         {
    //             shotAvailable = false;                
    //             PistolShot();
    //         }
    //     }
    // }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, centralFirepoint.position, centralFirepoint.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Access the bullets rigidbody2d component
        rb.AddForce(centralFirepoint.up * bulletForce, ForceMode2D.Impulse); // Puts force on the bullet
    }

    //Throws the Grenade
    public void ThrowGrenade()
    {

    }
}
