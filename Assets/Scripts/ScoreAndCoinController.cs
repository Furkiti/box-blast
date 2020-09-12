using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Main.BaseObject;

public class ScoreAndCoinController : BaseObject
{
    [SerializeField] private int scoreAmount = 1;
    [SerializeField] private int coinAmount = 5;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text scoreTextInGameOver;
    
    private int _score = 0;
    private int _coin;
    private int _highScore;

    private void Awake()
    {
        scoreText.text = "0";
        //highScoreText.text = "Best Score: 0";
        scoreTextInGameOver.text = "0";

    }

    public void addScore()
    {
        _score += scoreAmount;
        scoreText.text = _score.ToString();
        scoreTextInGameOver.text = scoreText.text;
        CheckHighScore(_score);
    }

    private void CheckHighScore(int currentScore)
    {
        if (currentScore > _highScore)
        {
            _highScore = currentScore;
            highScoreText.text = "Best Score: " + _highScore.ToString();
        }
    }
    
    public void addCoin()
    {
        _coin += coinAmount;
        coinText.text = FormatNumber(_coin);

    }
    
    public void SetScoreToZero()
    {
        _score = 0;
        scoreText.text = _score.ToString();
    }

    public int GetHighScore()
    {
        return _highScore;
    }

    public void SetHighScore(int tempHighScore)
    {
        _highScore = tempHighScore;
        highScoreText.text = "Best Score: " + _highScore.ToString();
    }

    public int GetCoin()
    {
        return _coin;
    }

    public void SetCoin(int tempCoin)
    {
        _coin = tempCoin;
        coinText.text = FormatNumber(_coin);
    }
    
   
    
    public  string FormatNumber(int num) {
       
        
         if (num >= 100000)
            return FormatNumber(num / 1000) + "k";
        else if (num >= 10000) {
            return (num / 1000D).ToString("0.#") + "k";
        }
        else if (num >= 1000)
        {
            return (num / 1000D).ToString("0.#") + "k";
        }
        return num.ToString("#,0");
    }
}
