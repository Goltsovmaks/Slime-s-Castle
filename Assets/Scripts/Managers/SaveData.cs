using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveData : MonoBehaviour
{
    // [SerializeField] private SavedData _SavedData = new SavedData();

    public void SaveDataIntoJson(){
        Debug.Log("save");
        // _SavedData.list.Add("first");
        // _SavedData.list.Add("second");
        Resolution res=Screen.resolutions[Screen.resolutions.Length-1];
        // _SavedData.list.Add(res.width + "x" + res.height+" "+res.refreshRate);

        // string Data = JsonUtility.ToJson(_SavedData);
        // System.IO.File.WriteAllText(Application.persistentDataPath + "/_SavedData.json",Data);
    }

    public void LoadDataFromJson(){

        // string Data= System.IO.File.ReadAllText(Application.persistentDataPath + "/_SavedData.json");
        // SavedData myObject = JsonUtility.FromJson<SavedData>(Data);


        // myObject.PrintAll();


    }

    public void DO(){
        string path =Application.persistentDataPath;
        // if(File.Exists(path+"/_SavedData.json")){
        //     Debug.Log("exists");
        // }
        foreach (string pathFr in Directory.GetFiles(path)) {
                        Debug.Log(Path.GetFileName(pathFr));

        }
        
        // Debug.Log(System.DateTime.Now.ToString("HH:mm:ss"));
        // Debug.Log(System.DateTime.Now.ToString("dd/MM/yyyy"));

    }

}

