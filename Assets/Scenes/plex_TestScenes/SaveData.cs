using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private SavedData _SavedData = new SavedData();

    public void SaveDataIntoJson(){
        _SavedData.list.Add("first");
        _SavedData.list.Add("second");
        Resolution res=Screen.resolutions[Screen.resolutions.Length-1];
        _SavedData.list.Add(res.width + "x" + res.height+" "+res.refreshRate);

        string Data = JsonUtility.ToJson(_SavedData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/_SavedData.json",Data);
    }

    public void LoadDataFromJson(){

        string Data= System.IO.File.ReadAllText(Application.persistentDataPath + "/_SavedData.json");
        SavedData myObject = JsonUtility.FromJson<SavedData>(Data);


        myObject.PrintAll();


    }

    public void DO(){
        Debug.Log(System.DateTime.Now.ToString("HH:mm:ss"));
        Debug.Log(System.DateTime.Now.ToString("dd/MM/yyyy"));

    }

}

[System.Serializable]
public class SavedData{
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



    public void PrintAll(){
        Debug.Log("volume:"+volume);
        Debug.Log("fullscreen:"+fullScreen);
        Debug.Log("Vsync:"+vsync);
        Debug.Log("resolution:"+resolution);
        Debug.Log("Count  of list:"+list.Count);
        // foreach (Resolution res in Screen.resolutions) {
        //                 Debug.Log(res.width + "x" + res.height+" "+res.refreshRate);
        //                 Debug.Log(res);
        //         }
        // // Debug.Log(Screen.resolutions);
    }
}

[System.Serializable]
public class SaveGame{

    public string dataOfSave;
    public int xPositions;
    public int yPositions;
    public int zPositions;

}
