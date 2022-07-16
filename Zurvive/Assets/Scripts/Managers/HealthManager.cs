using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    // current health of gameobject
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

    // are you on the correct sprite layer
    public void CheckSprite()
    {
        correctLayer = gameObject.layer;

        spriteRend = GetComponent<SpriteRenderer>();

        if(spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if(spriteRend == null)
            {
                Debug.Log("Object " + gameObject.name + " has no sprite renderer");
            }
        }
    }

    public virtual void Die()
    {

    }

    public virtual void HealthBoost()
    {

    }

    public virtual void Invulnerability()
    {

    }

    public virtual void TakeDamage(int damageTaken)
    {

    }
}
