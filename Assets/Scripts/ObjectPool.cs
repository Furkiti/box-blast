using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
using Object = UnityEngine.Object;

public class ObjectPool : BaseObject
{
    
    private GameObject prefab;
    private Stack<GameObject> pool = new Stack<GameObject>();
    
    [SerializeField] private GameObject _Dynamic;

    private void Awake()
    {
        Debug.Log("object pool awake!!");
        _Dynamic = GameObject.Find("_Dynamic");
    }

    public ObjectPool(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public void fillpool(int poolsize)
    {
        _Dynamic = GameObject.Find("_Dynamic");
        for(int i = 0; i < poolsize; i++)
        {
            GameObject obj = Object.Instantiate(prefab,_Dynamic.transform);
            addobjtopool(obj);
        }
    }

    public void addobjtopool(GameObject obj)
    {
      
        obj.gameObject.SetActive(false);
        
        pool.Push(obj);
    }

    public GameObject PopFromPool()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Pop();
            obj.gameObject.SetActive(true);

            return obj;
        }

        return Object.Instantiate(prefab);
    }

   
}