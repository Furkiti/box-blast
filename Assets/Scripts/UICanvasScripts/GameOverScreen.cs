using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{

    
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {  
        GameManager.Instance.GetAnimController().gameOverAnim();
        isDead = true;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            GameManager.Instance.GetAnimController().gameOverAnim();
            isDead = true;
        }
        
        
    }

    public void tapRetryButton()
    {
       hideCanvas();  
       GameManager.Instance.GetUIController().getGameCanvases(5).GetComponent<Canvas>().gameObject.SetActive(false);
    }

    public void hideCanvas()
    {
        GameManager.Instance.GetUIController().setIsAfterDead();
        gameObject.SetActive(false);
       
    }

    public void setIsDead()
    {
        isDead = false;
    }

   
}
