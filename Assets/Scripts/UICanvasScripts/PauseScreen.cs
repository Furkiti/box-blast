using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    private UIController UIController;
    [SerializeField] private GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        UIController = GameManager.Instance.GetUIController();
        
    }

    // Update is called once per frame
    void Update()
    {
        disablePauseButton();
        stopGame();

        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            enablePauseButton();
            UIController.getGameCanvases(1).GetComponent<GameScreen>().setIsPausedFalse();
            hideCanvas();
              
        }
    }

  
    private void disablePauseButton()
    {
        pauseButton.gameObject.SetActive(false);
    }

    private void enablePauseButton()
    {
        pauseButton.gameObject.SetActive(true);
    }

    private void hideCanvas()
    {
        gameObject.SetActive(false);
    }
    private void stopGame()
    {
        Time.timeScale = 0f;
    }


}
