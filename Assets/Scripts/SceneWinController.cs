using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneWinController : MonoBehaviour
{
    private string LoadLevel="";
    // private string FinishedLevelTime=SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2].toString();
    // Start is called before the first frame update
    [SerializeField]private Text ComplitedTime;
    void Start()
    {
        string levelName = SlimeData.currentLevel;
        // SceneManager.GetActiveScene().name;
        // string LoadLevel="";
        if(levelName=="LevelTest"){
            LoadLevel="Level1";
        }
        if(levelName=="Level1"){
            LoadLevel="Level2";
        }
        if(levelName=="Level2"){
            LoadLevel="Level3";
        }
        if(levelName=="Level3"){
            LoadLevel="Level4";
        }


        // for(int i=0;i<SlimeData.FinishedLevelTime.Count;i++){
        //     print(SlimeData.FinishedLevelTime[i]);
        // }
        // SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2]+"."+SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2]
        // ComplitedTime.text;
        ComplitedTime.text+=SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2]+" s";


        // private int CountAfterPoint=0;
        // for(int i=0;i<FinishedLevelTime.Length();i++){
        //     if(FinishedLevelTime[i]==","){
        //         // FinishedLevelTime[i]=".";
        //         ComplitedTime.text+="."+ FinishedLevelTime[i+1]+FinishedLevelTime[i+2]+FinishedLevelTime[i+3];
        //         break;
        //     }
        //     ComplitedTime.text+= FinishedLevelTime[i]

        //     // print(SlimeData.FinishedLevelTime[i]);
        // }
        // ComplitedTime.text+=" s";


        // +SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2]+" s";
    }

    // Update is called once per frame
    void Update()
    
    {
        
        // print(Time.timeSinceLevelLoad);
        if (Input.anyKey == true && Time.timeSinceLevelLoad>1) {
             SceneManager.LoadScene(LoadLevel);
                // break;
        }
    }

}
