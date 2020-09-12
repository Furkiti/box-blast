using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Main.BaseObject;


public class AnimController : BaseObject
{
    [SerializeField] GameObject cannon;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject scoreText;
    private GameObject[] boxClones;
    [SerializeField] private GameObject gameTitle;
    [SerializeField] private GameObject gameStartButtons;
    [SerializeField] private GameObject swipeToStart;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameOverAfter;

   

    private void Start()
    {
        DOTween.Init();
      
    }

    public void cannonAnim()
    {
        cannon.transform.DOLocalMoveY(0.5f, 0.9f).SetEase(Ease.InOutBounce);
    }

    public void startBoxAnim(GameObject gameobject)
    {
        gameobject.GetComponent<Animator>().SetTrigger("Sizing");
        //gameObject.GetComponent<Renderer>().material.DOFade(3f, 3);
    }

    public void shakeCamAnim()
    {
        Vector3 firstPosition = new Vector3(0, 0, -10);
        Sequence cameraShake;
        cameraShake = DOTween.Sequence();
        cameraShake.Append(mainCamera.DOShakePosition(1f, 1f));
        mainCamera.transform.localPosition = firstPosition;
    }

 
    public void coinAnim(Vector3 tempvector)
    {
        Instantiate(coinPrefab, tempvector, Quaternion.identity);
    }

    public void scoreAnim()
    {
        Vector3 firstScale = new Vector3(1f, 1f, 1f);
        Sequence scoreAnimation;
        scoreAnimation = DOTween.Sequence();
        scoreAnimation.Append(scoreText.transform.DOScale(new Vector3(1.2f, 1.2f, 1f), 0.2f));
        scoreAnimation.Append(scoreText.transform.DOScale(firstScale, 0.1f));
        
    }

    public void gameTitleAnim()
    {
        Vector3 initialScale = new Vector3(38f, 38f, 0f);
        Sequence gameTitleAnim;
        
        gameTitleAnim = DOTween.Sequence();
        gameTitleAnim.Append(gameTitle.gameObject.transform.DOScale(Vector3.zero,0.6f));
        gameTitleAnim.Append(gameTitle.gameObject.transform.DOScale(initialScale,0.5f));
        
        
    }

    public void gameStartButtonsAnim()
    {
        //gameStartButtons.gameObject.SetActive(!gameStartButtons.gameObject.activeSelf);
        Sequence gameStartButtonSeq;
        gameStartButtonSeq = DOTween.Sequence();
        gameStartButtonSeq.Append(gameStartButtons.gameObject.transform.DOLocalMoveY( -500f, 0.5f));
        gameStartButtonSeq.Append(gameStartButtons.gameObject.transform.DOLocalMoveY( 0f, 0.5f));


    }

    

    public void swipeToStartAnim()
    {
        Vector3 initialSwipeScale = new Vector3(1f, 1f, 0f);
        Sequence swipeToStartSeq;
        swipeToStartSeq = DOTween.Sequence();
        swipeToStartSeq.Append(swipeToStart.gameObject.transform.DOScale(Vector3.zero, 0.9f));
        swipeToStartSeq.Append(swipeToStart.gameObject.transform.DOScale(initialSwipeScale, 0.5f));
        
    }

    public void boxDeadAnim()
    {
        boxClones = GameObject.FindGameObjectsWithTag("target");
        
        for(int i = 0; i < boxClones.Length; i++)
        {
            Destroy(boxClones[i]);  
        }

    }

    public void gameOverAnim()
    {
        gameOver.transform.DOScale(Vector3.one, 1f);
    }

    public void gameOverAnim2()
    {
        gameOver.transform.DOScale(Vector3.zero, 0f);
        
    }

    public void gameOverAfterAnim()
    {
        gameOverAfter.transform.DOScale(Vector3.zero, 0.5f);
    }

    public void gameOverAfterAnim2()
    {
        gameOverAfter.transform.DOScale(Vector3.one, 0.5f);
    }




}
