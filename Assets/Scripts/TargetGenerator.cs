﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetGenerator : MonoBehaviour
{
    //Targets properties
    [SerializeField]
    private GameObject targetprefabsmall;
    [SerializeField]
    private GameObject targetprefabmedium;
    [SerializeField]
    private GameObject targetprefablarge;

    [SerializeField]
    private GameObject targetSpawnPos;
    private ObjectPool targetPool;
    private int poolSize = 10;
    
    private float[] posArray = {-2,-0.69f,0.62f,1.95f};

    void Start()
    {
        targetPool = new ObjectPool(targetprefabsmall);
        targetPool.fillpool(poolSize);

        StartCoroutine(createobj());
    }

    IEnumerator createobj()
    {
        while (true)
        {
            var wait = new WaitForSeconds(2f);

            Vector3 pos = setpos();

            GameObject tempobj = targetPool.popfrompool();
            tempobj.transform.position = pos;

            yield return wait;
        }
        
    }

    private Vector3 setpos()
    {
        int indexposx = Random.Range(0, posArray.Length);
        
       return new Vector3(posArray[indexposx],targetSpawnPos.transform.position.y,targetSpawnPos.transform.position.z);

    }
}
