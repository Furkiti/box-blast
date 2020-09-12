using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Main.BaseObject;

public class GameManager: MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private UIController UIController;
    [SerializeField] private ScoreAndCoinController ScoreAndCoinController;
    [SerializeField] private AnimController AnimController;
    [SerializeField] private SettingsMenuController SettingsMenuController;
    [SerializeField] private SettingsMenuActionController SettingsMenuActionController;
    [SerializeField] private LevelBarController LevelBarController;
    //[SerializeField] private LevelBarController LevelBarControllerGameOver;
    [SerializeField] private BulletSpawner BulletSpawner;
    [SerializeField] private BoxSpawner BoxSpawner;
    
    
    private void Awake()
    {
        SingletonPattern();
        LoadGame();
        Application.targetFrameRate = 60;
    }
    
    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        SaveGame();
        Destroy(gameObject);
    }
    
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerdatas"))
        {
            //Debug.Log("wtf bro");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerdatas", FileMode.Open);
            SaveDatas savedDatas = (SaveDatas) bf.Deserialize(file);
            file.Close();
            
            SetLoadedDatas(savedDatas);
            
        }

        else
        {
            Debug.Log("no game saved");
        }
    }

    private void SetLoadedDatas(SaveDatas tempSavedDatas)
    {
       GameManager.Instance.GetScoreAndCoinController().SetHighScore(tempSavedDatas.GetSavedHighScore());
       GameManager.Instance.GetScoreAndCoinController().SetCoin(tempSavedDatas.GetSavedTotalCoin());
       GameManager.Instance.GetLevelBarController().SetCurrentLevel(tempSavedDatas.GetSavedCurrentLevel());
       GameManager.Instance.GetLevelBarController().SetCurrentLevelValue(tempSavedDatas.GetSavedCurrentLevelValue());
    }

    private SaveDatas CreateSaveGameObject()
    {
        SaveDatas saveDatas = new SaveDatas();
        saveDatas.SetSavedHighScore();
        saveDatas.SetSavedTotalCoin();
        saveDatas.SetSavedCurrentLevel();
        saveDatas.SetSavedCurrentLevelValue();

        return saveDatas;
    }
    
    
    public void SaveGame()
    {
        Debug.Log("game is saved");
        SaveDatas saveDatas = CreateSaveGameObject();
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerdatas");
        bf.Serialize(file,saveDatas);
        file.Close();
        
    }

    

    public UIController GetUIController()
    {
        return UIController;
    }

    public AnimController GetAnimController()
    {
        return AnimController;
    }

    public ScoreAndCoinController GetScoreAndCoinController()
    {
        return ScoreAndCoinController;
    }

    public SettingsMenuActionController GetSettingsMenuActionController()
    {
        return SettingsMenuActionController;
    }

    public LevelBarController GetLevelBarController()
    {
        return LevelBarController;
    }

    public BulletSpawner GetBulletSpawner()
    {
        return BulletSpawner;
    }

    public BoxSpawner GetBoxSpawner()
    {
        return BoxSpawner;
    }

}
