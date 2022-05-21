using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;

    public int correctLayer;

    public SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Die()
    {

    }

    public virtual void HealthBoost()
    {

    }

    public virtual void TakeDamage(int damageTaken)
    {

    }
}
