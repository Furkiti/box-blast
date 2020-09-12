using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
using System.Runtime.InteropServices;

public class UIController : BaseObject
{
    [SerializeField] private Canvas[] gameCanvases;
    private bool isGameStarted = false;
    private bool isDead = false;
    private bool isAfterDead = false;
    private bool isRestart = false;



    [SerializeField]  private BulletSpawner bulletSpawner;
    [SerializeField]  private BoxSpawner boxSpawner;
    [SerializeField]  private GameObject cannon;
    [SerializeField] private GameObject pauseButton;
    private AnimController animController;

    private void Start()
    {
        animController = GameManager.Instance.GetAnimController();
        gameCanvases[0].gameObject.SetActive(true);
        gameCanvases[1].gameObject.SetActive(false);
        gameCanvases[2].gameObject.SetActive(false);
        gameCanvases[3].gameObject.SetActive(false);
        gameCanvases[4].gameObject.SetActive(false);
    }
    private void Update()
    {
        if(isGameStarted == true)
        {
            gameCanvases[1].gameObject.SetActive(true);
        }

        if(isDead == true)
        {
            animController.boxDeadAnim();
            gameCanvases[3].gameObject.SetActive(true);
            
        }

        if(isAfterDead == true)
        {
            GameManager.Instance.GetAnimController().gameOverAnim2();
            gameCanvases[3].GetComponent<GameOverScreen>().setIsDead();

            gameCanvases[4].gameObject.SetActive(true);
        }

        if(isRestart == true)
        {
            GameManager.Instance.GetAnimController().gameOverAfterAnim2();
            gameCanvases[0].gameObject.SetActive(true);
            isRestart = false;
        }
        
    }

    public void setIsGameStartedTrue()
    {
        isGameStarted = true;
    }

    


    public Canvas getGameCanvases(int index)
    {
        return gameCanvases[index];
    }

    public void setIsDead()
    {
        isGameStarted = false;
        isDead = true;
    }

    public void setIsAfterDead()
    {
        isDead = false;
        isAfterDead = true;
        
    }

    public void setIsRestart()
    {
        isRestart = true;
        isAfterDead = false;
    }


}

