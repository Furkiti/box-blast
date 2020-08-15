using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    public float spawnRate;
    private float nextSpawn;

    public GameObject targetSpawnPos;
    public GameObject targets;
    public GameObject targetParents;

    public Text displayScore;
    public static int gameScore;


     void Update()
    {
        
            if(Time.time > nextSpawn)
            {
                float randomdir = Random.Range(-2.4f, 2.4f);
                float sizeNum = Random.Range(0.7f, 1.3f);

                nextSpawn = Time.time + spawnRate;

                GameObject target = Instantiate(targets, new Vector2(targetSpawnPos.transform.position.x + randomdir,targetSpawnPos.transform.position.y),targetSpawnPos.transform.rotation);

                target.transform.localScale = new Vector3(sizeNum, sizeNum, 0f);

                target.transform.SetParent(targetParents.transform, true);
            }

            displayScore.text = gameScore.ToString();
        }   
    
}
