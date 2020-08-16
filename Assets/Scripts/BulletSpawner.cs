using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner: MonoBehaviour
{
    [SerializeField]
    private GameObject bulletprefab;

    [SerializeField]
    private GameObject bulletSpawnPos;
    private ObjectPool bulletPool;
    private int poolSize = 10;

    private float[] posArray = { -2, -0.69f, 0.62f, 1.95f };




    // Start is called before the first frame update
    void Start()
    {
        //preparebullet();
    }

    private void preparebullet()
    {
        bulletPool = new ObjectPool(bulletprefab);
        bulletPool.fillpool(poolSize);
        StartCoroutine(createobj());
    }

    IEnumerator createobj()
    {
       
            Debug.Log("test");
            Vector3 pos = setpos();

            GameObject tempobj = bulletPool.popfrompool();
            tempobj.transform.position = pos;
            setvelocity(tempobj);

            yield return null;
        
            
    }

    private Vector3 setpos()
    {
        int indexposx = UnityEngine.Random.Range(0, posArray.Length);

        return new Vector3(posArray[indexposx], bulletSpawnPos.transform.position.y, bulletSpawnPos.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            preparebullet();
           
        }
        
    }

    private void setvelocity(GameObject tempobj)
    {

        tempobj.GetComponent<Rigidbody2D>().velocity = Vector2.up;
    }
}
