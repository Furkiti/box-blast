using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    private GameObject prefab;
    private Stack<GameObject> pool = new Stack<GameObject>();

    public ObjectPool(GameObject targetprefab)
    {
        this.prefab = targetprefab;
    }

    public void fillpool(int poolsize)
    {

        for(int i = 0; i < poolsize; i++)
        {
            GameObject obj = Object.Instantiate(prefab);
            addobjtopool(obj);
        }
    }

    public void addobjtopool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }

    public GameObject popfrompool()
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
