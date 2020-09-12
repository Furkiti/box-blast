using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
public class Bullet : BaseObject
{
    
    //private float speed = 10f;
    private int triggerCount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("bulletcollider"))
        {
            
            Die();
        }

  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("UWall"))
        {
            Die();
        }
        
       
        if (triggerCount > 3)
        {

            Die();
        }

        triggerCount++;

    }

    public void Die()
    {
        
        Destroy(gameObject);
    }
}
