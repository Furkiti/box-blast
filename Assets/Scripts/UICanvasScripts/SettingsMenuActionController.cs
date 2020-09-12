using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuActionController : MonoBehaviour
{
    //Sound Sprites
    private Sprite soundOn;
    private Sprite soundOff;
    private bool isSoundOn = true; // save data and reassign it
    
    //Music Sprites
    private Sprite musicOn;
    private Sprite musicOff;
    private bool isMusicOn = true;
    
    //Vibrations Sprites
    private Sprite vibrationOn;
    private Sprite vibrationOff;
    private bool isVibrationOn = true;
    
    
    //Notifications Sprites
    
    private Sprite notificationsOn;
    private Sprite notificationsOff;
    private bool isNotificationsOn = true;

    
    

    private void Awake()
    {
        GetSprites();
    }
    
    public void GetSprites()
    {
        soundOn = Resources.Load<Sprite>("SoundOn");
        soundOff = Resources.Load<Sprite>("SoundOff");
        
        musicOn = Resources.Load<Sprite>("MusicOn");
        musicOff = Resources.Load<Sprite>("SoundOff");
        
        vibrationOn = Resources.Load<Sprite>("VibrationOn");
        vibrationOff = Resources.Load<Sprite>("VibrationOff");
        
        notificationsOn = Resources.Load<Sprite>("NotifOn");
        notificationsOff = Resources.Load<Sprite>("NotifOff");
        
       
    }

    public void ChangeSound(MenuItem sound)
    {
        
        if (isSoundOn == true)
        {
            sound.GetComponent<Image>().sprite = soundOff;
            isSoundOn = false;
        }

        else if (isSoundOn == false)
        {
            sound.GetComponent<Image>().sprite = soundOn;
            isSoundOn = true;

        }
        
    }
    
    
    public void ChangeMusic(MenuItem notifications)
    {
        
        if (isMusicOn == true)
        {
            notifications.GetComponent<Image>().sprite = musicOff;
            isMusicOn = false;
        }

        else if (isMusicOn == false)
        {
            notifications.GetComponent<Image>().sprite = musicOn;
            isMusicOn = true;

        }
        
    }
    
    public void ChangeVibration(MenuItem vibration)
    {
        
        if (isVibrationOn == true)
        {
            vibration.GetComponent<Image>().sprite = vibrationOff;
            isVibrationOn = false;
        }

        else if (isVibrationOn == false)
        {
            vibration.GetComponent<Image>().sprite = vibrationOn;
            isVibrationOn = true;

        }
    }
    
    
    public void ChangeNotifications(MenuItem notifications)
    {
        
        if (isNotificationsOn == true)
        {
            notifications.GetComponent<Image>().sprite = notificationsOff;
            isNotificationsOn = false;
        }

        else if (isNotificationsOn == false)
        {
            notifications.GetComponent<Image>().sprite = notificationsOn;
            isNotificationsOn = true;

        }
        
    }
}
