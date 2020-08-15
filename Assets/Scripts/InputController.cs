using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    public GameObject spawnPos;

  
         
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("test");
            
            
            Instantiate(ball, spawnPos.transform.position, spawnPos.transform.rotation);
        }
    }
}



