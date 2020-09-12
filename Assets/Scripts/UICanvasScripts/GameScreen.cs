using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
using System;

public class GameScreen : BaseObject
{
    private bool isPaused = false;
    private bool isDead = false;
    private UIController UIController;
    private Canvas pauseScreen;
    [SerializeField] GameObject pauseButton;
    [SerializeField] private BulletSpawner bulletSpawner;
    [SerializeField] private BoxSpawner boxSpawner;
    [SerializeField] private GameObject cannon;
   
 


    private void Start()
    {
        pauseScreen = GameManager.Instance.GetUIController().getGameCanvases(2);
        UIController = GameManager.Instance.GetUIController();
        createobjects();
    }

    private void Update()
    {
        GameManager.Instance.GetUIController().getGameCanvases(5).gameObject.SetActive(true);
        if (bulletSpawner.gameObject.active == false || boxSpawner.gameObject.active == false || cannon.gameObject.active == false)
        {
            createobjects();
            isDead = false;
            boxSpawner.setIsRestart();
        }

        if(isPaused == true)
        {
            pauseScreen.gameObject.SetActive(true);
        }

        if(isDead == true)
        {
            
            
            destroyobjects();
            isDead = false;
            UIController.setIsDead();
            hideCanvas();

        }
    }

   
    private void createobjects()
    {
        bulletSpawner.gameObject.SetActive(true);   
        boxSpawner.gameObject.SetActive(true);   
        cannon.gameObject.SetActive(true);
    
    }

    private void hideCanvas()
    {
        gameObject.SetActive(false);
    }

    private void destroyobjects()
    {
        bulletSpawner.gameObject.SetActive(false);
        boxSpawner.gameObject.SetActive(false);
        cannon.gameObject.SetActive(false);
    }

    public void setIsPausedTrue()
    {
        isPaused = true;
    }
    public void setIsPausedFalse()
    {
        isPaused = false;
    }

    public void setIsDead()
    {
        isDead = true;
    }

  
    
}
