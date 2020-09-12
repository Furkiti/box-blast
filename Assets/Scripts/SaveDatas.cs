using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveDatas
{
    //HighScore
    private int _savedHighScore;
    
    //TotalCoin
    private int _totalCoin;
    
    //Current Level
    private int _currentLevel;
    private float _currentLevelValue;

    
    public int GetSavedHighScore()
    {
        return _savedHighScore;
    }

    public void SetSavedHighScore()
    {
        _savedHighScore = GameManager.Instance.GetScoreAndCoinController().GetHighScore();
    }

    public int GetSavedTotalCoin()
    {
        return _totalCoin;
    }

    public void SetSavedTotalCoin()
    {
        _totalCoin = GameManager.Instance.GetScoreAndCoinController().GetCoin();
    }

    public int GetSavedCurrentLevel()
    {
        return _currentLevel;
    }

    public void SetSavedCurrentLevel()
    {
        _currentLevel = GameManager.Instance.GetLevelBarController().GetCurrentLevel();
    }
    
    public float GetSavedCurrentLevelValue()
    {
        return _currentLevelValue;
    }
    
    public void SetSavedCurrentLevelValue()
    {
        _currentLevelValue = GameManager.Instance.GetLevelBarController().GetCurrentLevelValue();
    }
    

   
}