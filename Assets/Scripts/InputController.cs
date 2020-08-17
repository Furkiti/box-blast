using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public BulletSpawner bulletSpawner;
         
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletSpawner.preparebullet();
        }
    }
}



