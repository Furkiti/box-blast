using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Main.BaseObject;

public class LevelBarController : BaseObject
{
   private float increaseAmount = 0.05f;
   private float sliderFull = 1f;
   [SerializeField] private Slider levelBar;
   [SerializeField] private Text startLevel;
   [SerializeField] private Text finishLevel;
   private int currentLevel = 0;

   private void Awake()
   {
      CheckSave();
      SliderSettings();
   }

   private void CheckSave()
   {
      if (!File.Exists(Application.persistentDataPath + "/playerdatas"))
      {
         Debug.Log("no level for level controller");
         currentLevel = 0;
         startLevel.text = currentLevel.ToString();
         finishLevel.text = (currentLevel + 1).ToString();
         levelBar.value = 0f;
      }
         
      
   }

   private void SliderSettings()
   {
      //levelBar.maxValue = 
   }


   public void SetLevelBar()
   {
     
      levelBar.value += increaseAmount;
      NextLevel();
   }

   private void NextLevel()
   {
      if (levelBar.value == sliderFull)
      {
         PassLevel();
         
      }
   }

   private void PassLevel()
   {
      currentLevel++;
      startLevel.text = currentLevel.ToString();
      finishLevel.text = (currentLevel + 1).ToString();
      levelBar.value = 0f;
      GameManager.Instance.GetBoxSpawner().NextLevel();
   }

   public int GetCurrentLevel()
   {
      return currentLevel;
   }

   public void SetCurrentLevel(int tempCurrentLevel)
   {
      currentLevel = tempCurrentLevel;
      startLevel.text = currentLevel.ToString();
      finishLevel.text = (currentLevel + 1).ToString();
   }
   
   public float GetCurrentLevelValue()
   {
      return levelBar.value;
   }
   
   public void SetCurrentLevelValue(float tempCurrentLevelValue)
   {
      levelBar.value = tempCurrentLevelValue;
   }

   
   

   
}