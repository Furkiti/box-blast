using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    public static GameController Instance;

    private InputController inputController;

    private UIController uiController;

    //public GameObject prefabtest;
    // public GameObject spawnpos;
    //public TargetGenerator targetGenerator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
    }

    private void Start()
    {
        Application.targetFrameRate = 300;
    }

    private void FixedUpdate()
    {
        
            

    }

}
