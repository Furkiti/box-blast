using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Main.BaseObject;

public class Coin : BaseObject
{

    private GameObject CoinIconUI;

    

    // Start is called before the first frame update
    void Start()
    {
        CoinIconUI = GameObject.Find("CoinIconUI");
        startAnim();
        
    }

    private void startAnim()
    {
        
        transform.DOMoveX(CoinIconUI.transform.position.x,0.7f).SetEase(Ease.OutSine).OnComplete(() => Destroy(gameObject));
        transform.DOMoveY(CoinIconUI.transform.position.y,1).SetEase(Ease.OutSine).OnComplete(() => Destroy(gameObject));
       
        
    }

}
