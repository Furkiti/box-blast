using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Main.BaseObject;
using UnityEngine.UI;
using Object = System.Object;

public class BulletSpawner: BaseObject
{
    //touching area
    //Rect touchableArea = new Rect(0f,Screen.height,Screen.width,Screen)
    Rect touchableArea = new Rect(0, 300, Screen.width, Screen.height);  
    //Rect topRight = new Rect(Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2);

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject cannonPos;
    [SerializeField] private float impulseForce = 100f;

    //Object Pooling
    private ObjectPool bulletPool;
    private int poolSize = 150;

    //Spawn Rate
    private float nextSpawnTime;
    [SerializeField] private float delay = 1f;

    //Angle Degrees
    private float minRot = -0.64f;
    private float maxRot = 0.64f;

    private void Start()
    {
        bulletPool = new ObjectPool(bulletPrefab);
        bulletPool.fillpool(poolSize);
    }


    public void preparebullet()
    {
        StartCoroutine(createbullets());
    }

    private void FixedUpdate()
    {
        getPcInput();
        getMobileInput();
    }

   

    private void getPcInput()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("screen height" + Screen.height);
            //Debug.Log("screen width" + Screen.width);
            Vector2 mousePos = Input.mousePosition;
            
            if (touchableArea.Contains(mousePos))
            {
                if (readyToSpawnBullet)
                {
                    preparebullet();

                }
            }
            
        }
    }

    private void getMobileInput()
    {
        if (Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;

            if (touchableArea.Contains(touchPos))
            {
                if (touchableArea.Contains(touchPos))
                    
                if (readyToSpawnBullet)
                {
                    preparebullet();
                }
            }
           
           
            
        }
    }

    public bool readyToSpawnBullet
    {
        get
        {
            return Time.time >= nextSpawnTime;
        }
    }

    IEnumerator createbullets()
    {
        nextSpawnTime = Time.time + delay;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = mousePos - cannonPos.gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;
        StartCoroutine(launchingBalls(mouseDir));
        
        yield return null;       
    }

    IEnumerator launchingBalls(Vector3 mouseDir)
    {
        GameObject tempobj = bulletPool.PopFromPool();
        tempobj.transform.position = cannonPos.gameObject.transform.position;
        tempobj.GetComponent<Rigidbody2D>().AddForce(mouseDir * impulseForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);
    }

    

 
}
