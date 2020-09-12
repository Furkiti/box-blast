using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverAfterScreen : MonoBehaviour
{
    Rect touchableArea = new Rect(0, 0, Screen.width, Screen.height);
    private bool restartGame = false;

    [SerializeField] private Text afterScore;
    // Start is called before the first frame update
   
    // Update is called once per frame

    private void getMobileInput()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            Debug.Log(touchPos);

            if (touchableArea.Contains(touchPos))
            {
                GameManager.Instance.GetAnimController().gameOverAfterAnim();
                StartCoroutine(hideCanvas());
                //hideCanvas();
                GameManager.Instance.GetUIController().setIsRestart();

            }

        }
    }

    private void getPcInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
      
            Vector2 mousePos = Input.mousePosition;
            Debug.Log(mousePos);

            if (touchableArea.Contains(mousePos))
            {
                GameManager.Instance.GetAnimController().gameOverAfterAnim();
                StartCoroutine(hideCanvas());
      
                
            }

        }
    }

    public void tapContinueButton()
    {
        GameManager.Instance.GetUIController().getGameCanvases(5).GetComponent<Canvas>().gameObject.SetActive(false);
        GameManager.Instance.GetAnimController().gameOverAfterAnim();
        
        StartCoroutine(hideCanvas());
        GameManager.Instance.GetScoreAndCoinController().SetScoreToZero();
      
    }

    IEnumerator hideCanvas()
    {
        var wait = new WaitForSeconds(0.7f);
        yield return wait;
        GameManager.Instance.GetUIController().setIsRestart();
        gameObject.SetActive(false);

    }
}
