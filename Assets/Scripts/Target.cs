using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
   // TextMesh healthText;
    [Range(50,100)] private int health;
    private String color;
    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    TMP_Text textHealth;

    private void Start()
    {
        textHealth.text = health.ToString();
    }

    public void takeDamage(int damage)
    {
        if (health > 1)
        {
            health -= damage;
        }
        else
        {
            Die();
        }

        updateHealthIU();
    }

    private void updateHealthIU()
    {
        textHealth.text = health.ToString();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    //collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("dangerzonetargets"))
        {
            Debug.Log("worked");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals("bullet"))
        {
            Debug.Log("hit");
            takeDamage(1);
        }
    }
}
