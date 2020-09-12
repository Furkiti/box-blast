using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Main.BaseObject;
using Random = UnityEngine.Random;

public class Box : BaseObject
{
   
    [Range(1,1000)][SerializeField] private int health;
    [SerializeField] TMP_Text textHealth;
    private int coinAmount = 5;
    private int damageAmount = 1;

    private bool isDying = false;

    [SerializeField] private Animator animator; 
    private AnimController animController;
    private ScoreAndCoinController scoreAndCoinController;
    private UIController uiController;
    
    private int currentLevel;
    [SerializeField] private int multiplier;
    




    private void Start()
    {
        currentLevel = GameManager.Instance.GetLevelBarController().GetCurrentLevel();
        SetHealth();
        animController = GameManager.Instance.GetAnimController();
        scoreAndCoinController = GameManager.Instance.GetScoreAndCoinController();
        uiController = GameManager.Instance.GetUIController();
        textHealth.text = health.ToString();
    }

    private void SetHealth()
    {
        
        int healthRangeMin = currentLevel+1 * multiplier;
        int healthRangeMax = (currentLevel+1 * multiplier) + 5 ;
        health = Random.Range(healthRangeMin, healthRangeMax);
    }




    public void takeDamage(int damage)
    {
        if (health > 1)
        {
            health -= damage;
            
        }
        else
        {
            Vector3 tempvector = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            
            Die(); 
            GameManager.Instance.GetLevelBarController().SetLevelBar();
            if (isDying == false)
            {
                animController.coinAnim(tempvector);
                updateCoinUI(); 
            }
                
           
        }

        updateHealthIU();
    }

    private void updateCoinUI()
    {
        scoreAndCoinController.addCoin();
    }

    private void updateHealthIU()
    {
        textHealth.text = health.ToString();
        scoreAndCoinController.addScore();

    }

    private void Die()
    {
           isDying = true;
           GetComponent<BoxCollider2D>().enabled = false;
            float delay = 1.10f;
            animator.SetBool("IsDead",true);
            Destroy(textHealth.gameObject);
            Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);

            isDying = false;
            
    }

    //collisions

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("boxcollider"))
        {
            Die();
            uiController.getGameCanvases(1).GetComponent<GameScreen>().setIsDead();

        }

        if (collision.gameObject.tag.Equals("cannon"))
        {
            Die();
            uiController.getGameCanvases(1).GetComponent<GameScreen>().setIsDead();
        }

        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag.Equals("bullet"))
        {
            animController.startBoxAnim(gameObject);
            animController.scoreAnim();
            takeDamage(damageAmount);
            collision.gameObject.GetComponent<Bullet>().Die();
          
        }

        if (collision.gameObject.tag.Equals("wall"))
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }

       
    }

    
}
