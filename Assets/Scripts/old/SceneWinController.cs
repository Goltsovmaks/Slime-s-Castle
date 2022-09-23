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
    [SerializeField]private Text SumOfMusroomsEaten;

    [SerializeField]private GameObject[] Mushrooms;

    void Start()
    {
        string levelName = SlimeData.currentLevel;
        // SceneManager.GetActiveScene().name;
        // string LoadLevel="";

        // switch(SlimeData.currentLevel){
        //     case "trainLevel":
        //     NumberOfLevel=0;
        //     break;

        //     case "Level1":
        //     NumberOfLevel=1;
        //     break;
        //     case "Level2":
        //     NumberOfLevel=2;
        //     break;
        //     case "Level3":
        //     NumberOfLevel=3;
        //     break;
        //     case "Level4":
        //     NumberOfLevel=4;
        //     break;

        // }
        if(levelName=="scn_trainLevel"){
            LoadLevel="scn_levelSt1";
        }
        if(levelName=="scn_levelSt1"){
            LoadLevel="scn_levelSt2";
        }
        if(levelName=="scn_levelSt2"){
            LoadLevel="scn_SyrioLevel";
        }


        if(levelName=="scn_SyrioLevel"){
            LoadLevel="scn_menu";
        }
        if(levelName=="scn_Level1"){
            LoadLevel="scn_Level2";
        }
        if(levelName=="scn_Level2"){
            LoadLevel="scn_Level3";
        }
        if(levelName=="scn_Level3"){
            LoadLevel="scn_Level4";
        }
        SlimeData.currentLevel=LoadLevel;
        


        // for(int i=0;i<SlimeData.FinishedLevelTime.Count;i++){
        //     print(SlimeData.FinishedLevelTime[i]);
        // }
        // SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2]+"."+SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-2]
        // ComplitedTime.text;
        ComplitedTime.text+=SlimeData.FinishedLevelTime[SlimeData.NumberOfLevel-1]+" s";
        SumOfMusroomsEaten.text+=SlimeData.SumEatMushroomOnLevel[SlimeData.NumberOfLevel-1];
        SumOfMusroomsEaten.text+=" / "+SlimeData.SumMushroomOnLevel[SlimeData.NumberOfLevel-1];
        showMusroomsEaten();


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

    void showMusroomsEaten(){
        for(int i=0;i<Mushrooms.Length;i++){
            if(((Dictionary<string,int>)SlimeData.SumTypesOfEatMushroomOnLevel[SlimeData.NumberOfLevel-1]).ContainsKey(Mushrooms[i].name)){
                // Text mush1=Mushrooms[i].transform.GetChild(0).Text;
                // print(Mushrooms[i].transform.GetChild(0).GetComponent<Text>());
                Mushrooms[i].transform.GetChild(0).GetComponent<Text>().text+=((Dictionary<string,int>)SlimeData.SumTypesOfEatMushroomOnLevel[SlimeData.NumberOfLevel-1])[Mushrooms[i].name];
            }else{
                Mushrooms[i].SetActive(false);
            }
            
        }



    }

}
