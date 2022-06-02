using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public Transform centralFirepoint;

    public GameObject bulletPrefab;

    public GameObject rifleBulletPrefab;

    public GameObject grenade;

    protected float pistolChamberTime = 0.2f;

    protected float rifleReloadTime = 0.3f;

    protected bool shotAvailable = true;

    protected float bulletForce = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Reload();

        if(Input.GetButton("Fire1"))
        {
            if(shotAvailable)
            {
                PistolShot();
                shotAvailable = false;
            }
        }

        // if(Input.GetButton("Fire2"))
        // {
        //     RifleShot();
        // }
    }

    public void Reload()
    {
        pistolChamberTime -= Time.deltaTime;
        if(pistolChamberTime <= 0)
        {
            pistolChamberTime = 0.2f;
            shotAvailable = true;
        }
    }

    private void PistolShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, centralFirepoint.position, centralFirepoint.rotation); 
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //Access the bullets rigidbody2d component
        rb.AddForce(centralFirepoint.up * bulletForce, ForceMode2D.Impulse); // Puts force on the bullet
    }
}
