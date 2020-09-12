using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
using System;

public class StartScreen : BaseObject
{
    Rect touchableArea = new Rect(0, 600, Screen.width, Screen.height/2);
    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.GetUIController().getGameCanvases(5).gameObject.SetActive(false);
        
            //getMobileInput();
            //getPcInput();
        
    }

    private void getPcInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("screen height" + Screen.height);
            //Debug.Log("screen width" + Screen.width);
            Vector2 mousePos = Input.mousePosition;
            
            if (touchableArea.Contains(mousePos))
            {
                
                startAnimations();
                
                
                GameManager.Instance.GetUIController().setIsGameStartedTrue();
                StartCoroutine(hideCanvas());
            }

        }
    }


    private void getMobileInput()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            

            if (touchableArea.Contains(touchPos))
            {
                Debug.Log("touched");

                //startAnimations();
               
                GameManager.Instance.GetUIController().setIsGameStartedTrue();
                StartCoroutine(hideCanvas());

            }

        }
    }

    public void startAnimations()
    {
        GameManager.Instance.GetAnimController().gameTitleAnim();
        GameManager.Instance.GetAnimController().gameStartButtonsAnim();
        GameManager.Instance.GetAnimController().swipeToStartAnim();
        GameManager.Instance.GetAnimController().cannonAnim();

    }

    IEnumerator hideCanvas()
    {
        var wait = new WaitForSeconds(0.5f);
        yield return wait;
        gameObject.SetActive(false);
    }

    public void TapStartButton()
    {
       
        startAnimations();
                
        GameManager.Instance.GetUIController().setIsGameStartedTrue();
        StartCoroutine(hideCanvas());
    }

}
