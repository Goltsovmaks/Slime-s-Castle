using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class scr_SaveController : MonoBehaviour
{
    public static scr_SaveController instance = null;

    public delegate SaveGame delGetSaveGame(int numberOfSave);
    public delegate void delSetSaveGame(int numberOfSave, SaveGame newSave);

    public static event delGetSaveGame GetSaveGameEvent;
    public static event delSetSaveGame SetSaveGameEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        GetSaveGameEvent+=GetSaveGame;
        SetSaveGameEvent+=SetSaveGameEvent;
    }
    

    
    public SaveGame GetSaveGame(int numberOfSave)
    {
        if(ExistsSaveGame(numberOfSave))
        {
            string path = Application.streamingAssetsPath + "/Saves/saveGame"+numberOfSave+".json";
            SaveGame saveGame = JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
            return saveGame;
        }
        else
        {
            return new SaveGame(numberOfSave);
        }
    }

    public void SetSaveGame(int numberOfSave, SaveGame newSave)
    {
        string path = Application.streamingAssetsPath + "/Saves/saveGame" + numberOfSave+".json";
        string data = JsonUtility.ToJson(newSave);
        File.WriteAllText(path,data);
    }


    public bool ExistsSaveGame(int numberOfSave)
    {
        string path = Application.streamingAssetsPath + "/Saves/saveGame" + numberOfSave+".json";
        return File.Exists(path);
    }

    public void DeleteSaveGame(int numberOfSave)
    {
        string path= Application.streamingAssetsPath + "/Saves/saveGame" + numberOfSave+".json";
        File.Delete(path);
    }

    public SettingsData GetSettingsData()
    {
        if(ExistsSettingsData())
        {
            string path = Application.streamingAssetsPath + "/SettingsData.json";
            SettingsData settingsData = JsonUtility.FromJson<SettingsData>(File.ReadAllText(path));
            return settingsData;
        }
        else
        {
            SetSettingsData(new SettingsData());
            return new SettingsData();
        }
 
    }

    public void SetSettingsData(SettingsData newSettings)
    {
        string path = Application.streamingAssetsPath + "/SettingsData.json";
        string data = JsonUtility.ToJson(newSettings);
        File.WriteAllText(path,data);
    }

    public bool ExistsSettingsData()
    {
        string path = Application.streamingAssetsPath + "/SettingsData.json";
        return File.Exists(path);
    }

    private void OnDestroy() 
    {
        GetSaveGameEvent-=GetSaveGame;
        SetSaveGameEvent-=SetSaveGameEvent;
    }

    
}


[System.Serializable]
public class SettingsData
{
    [Range(0, 1f)]public float volume;
    public bool fullScreen;
    public bool vsync;

    public int windowWidth;
    public int windowHeight;

    public string keyUp;
    public string keyDown;
    public string keyLeft;
    public string keyRight;

    public string keyJump;

    public string keySkill;

    public string keyUse;


    public string resolution;
    public List<string> list = new List<string>(); 

    public Vector3 testv;

    public void PrintAll()
    {
        Debug.Log("volume:"+volume);
        Debug.Log("fullscreen:"+fullScreen);
        Debug.Log("Vsync:"+vsync);
        Debug.Log("resolution:"+resolution);
        Debug.Log("Count  of list:"+list.Count);
    }
}

public class SaveGame
{

    public string nameOfSave;
    public int numberOfSave;

    public string dataOfLastSave;
    public float totalTime;
    public Vector3 position;

    public bool newGame;

    public int playerCoins;

    public SaveGame(int numberOfSave)
    {
        nameOfSave="saveGame"+ numberOfSave;
        this.numberOfSave=numberOfSave;
        UpdateTimeSave();
    }
    public SaveGame()
    {
        UpdateTimeSave();
    
    }

    public string GetTotalTime()
    {
        int hours = (int)totalTime/3600;
        int minutes = (int)totalTime%3600/60;
        int seconds = (int)totalTime%3600%60;
        return hours +"h "+minutes+"m "+seconds+"s";
    }

    public void UpdateTimeSave()
    {
        dataOfLastSave=System.DateTime.Now.ToString("HH:mm:ss")+" "+System.DateTime.Now.ToString("dd/MM/yyyy");
    }

}
