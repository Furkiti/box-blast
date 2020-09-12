using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BoxSpawner: BaseObject
{
  
    [SerializeField] private GameObject boxPrefabRed;
    [SerializeField] private GameObject boxPrefabPurple;
    [SerializeField] private GameObject boxPrefabBlue;
    [SerializeField] private GameObject boxSpawnPos;
    [SerializeField] private GameObject boxDestPos;

  
   
    private bool isRestart = false;
  
    //Object Pooling
    private ObjectPool boxPoolingRed;
    private ObjectPool boxPoolingPurple;
    private ObjectPool boxPoolingBlue;
    private int poolSize = 50;
    
    
    private GameObject tempobj;
    
    
    //Level Creation
    private int currentLevel;
    private float leftSidex = -2f;
    private float rightSidex = 2f;
    [SerializeField] private int minAmount = 3;
    [SerializeField] private int maxAmount = 5;
    private float widthDistance = 4f;
    private float waitTime = 3f;
    private WaitForSeconds wait;


    private void Start()
    {
        currentLevel = GameManager.Instance.GetLevelBarController().GetCurrentLevel();
        Debug.Log("<color=orange> current level at start </color>" +currentLevel);
        
        for (float i = 0; i <= currentLevel; i++)
        {
            waitTime += i / 8;
            Debug.Log("for loop");
        }
        
        prepareBoxes();
    }

    private void Update()
    {
        if(isRestart == true)
        {
            prepareBoxes();
            isRestart = false;
        }
    }

    private void prepareBoxes()
    {
        boxPoolingRed = new ObjectPool(boxPrefabRed);
        boxPoolingPurple = new ObjectPool(boxPrefabPurple);
        boxPoolingBlue = new ObjectPool(boxPrefabBlue);
        
        
        boxPoolingRed.fillpool(poolSize);
        boxPoolingPurple.fillpool(poolSize);
        boxPoolingBlue.fillpool(poolSize);
        
        StartCoroutine(createobj());
    }

    public void setIsRestart()
    {
        isRestart = true;
    }

    


    IEnumerator createobj()
    {
        
        while (true)
        {
            Debug.Log("<color=red> wait time </color>" + waitTime);
            Debug.Log("<color=orange> current level </color>" +currentLevel);
            
            int howManyBox =  RandomDelete();
            int howManyPurple = RandomPurple(howManyBox);
            int[] colorArray = new int[howManyBox];

            for (int i = 0; i < colorArray.Length; i++)
            {
                colorArray[i] = 0;
            }

            for (int i = 0; i < howManyPurple; i++)
            {
                //2.sefer yine aynı indexe purple atarsa purple sayısı azalır. index check
                int index = Random.Range(0, colorArray.Length);
                colorArray[index] = 1;
            }
            float levelDistance = widthDistance / (howManyBox-1);
            float spawnPosx = leftSidex;

            for (int i = 0; i < howManyBox; i++)
            {
                Vector3 pos = new Vector3(spawnPosx, boxSpawnPos.transform.position.y, boxSpawnPos.transform.position.z);

                if (colorArray[i].Equals(0))
                {
                    tempobj = boxPoolingRed.PopFromPool();
                }
                
                else if (colorArray[i].Equals(1))
                {
                    tempobj = boxPoolingPurple.PopFromPool();
                }
                
                tempobj.transform.position = pos;
                spawnPosx += levelDistance;
            }

            
            yield return new WaitForSeconds(waitTime);
            
        }

        
    }
    

    private int RandomDelete()
    {
        return Random.Range(minAmount,maxAmount+1);
    }
    
    private int RandomPurple(int howManyBox)
    {
        return Random.Range(0, howManyBox-1);
    }

    public void NextLevel()
    {
        waitTime += (float)currentLevel / 4;
    }
}
