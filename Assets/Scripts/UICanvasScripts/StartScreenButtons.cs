using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenButtons : MonoBehaviour
{

    [SerializeField] private GameObject[] startPanels;

    private void Start()
    {
        startPanels[0].gameObject.SetActive(true);
        startPanels[1].gameObject.SetActive(false);
        startPanels[2].gameObject.SetActive(false);
        startPanels[3].gameObject.SetActive(false);
    }

    public void UpgradeMarket()
    {
        startPanels[0].gameObject.SetActive(true);
        startPanels[1].gameObject.SetActive(false);
        startPanels[2].gameObject.SetActive(false);
        startPanels[3].gameObject.SetActive(false);
    }

    public void GunMarket()
    {
       
        startPanels[0].gameObject.SetActive(false);
        startPanels[1].gameObject.SetActive(true);
        startPanels[2].gameObject.SetActive(false);
        startPanels[3].gameObject.SetActive(false);
    }

    public void NoAdsMarket()
    {
        startPanels[0].gameObject.SetActive(false);
        startPanels[1].gameObject.SetActive(false);
        startPanels[2].gameObject.SetActive(true);
        startPanels[3].gameObject.SetActive(false);
    }

    public void BackgroundMarket()
    {
        startPanels[0].gameObject.SetActive(false);
        startPanels[1].gameObject.SetActive(false);
        startPanels[2].gameObject.SetActive(false);
        startPanels[3].gameObject.SetActive(true);
    }
}
