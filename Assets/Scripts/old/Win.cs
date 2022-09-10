using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    // public Transform slime;
    public Animator Anim;
    // private Vector3 StartPos;
    //  [SerializeField]private GameObject WinWindow;

    // [SerializeField]private Text ComplitedTime;

    scr_TimeManager TimeManager;
    scr_GameManager GameManager;



    void Start()
    {
        TimeManager = scr_TimeManager.instance;
        GameManager = scr_GameManager.instance;



        // StartPos=new Vector3;
        // StartPos.y+=10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D myTrigger)
    {
        if (myTrigger.CompareTag("Player"))
        {
            Anim.SetBool("Play",true);
            // new WaitForSeconds(2.9f);

        }
    }
    public void win(){
        // WinWindow.SetActive(true);
        // while(0==0){
        //     if (Input.anyKey == true) {
        //         break;
        //         }
        // }

        // string levelName = SceneManager.GetActiveScene().name;
        // // print(levelName);

        // string LoadLevel="";
        // if(levelName=="LevelTest"){
        //     LoadLevel="Level1";
        // }
        // WinWindow.SetActive(false);
                // SlimeData.Add(Time.timeSinceLevelLoad)

        // SlimeData.currentLevel=SceneManager.GetActiveScene().name;

        // SlimeData.FinishedLevelTime.Add(Time.timeSinceLevelLoad);
        // SlimeData.NumberOfLevel++;

        // TimeManager.GetSinceStartLevel();
        // ComplitedTime.text = "Level complited in "+TimeManager.GetSinceStartLevel()+" s";

        TimeManager.SetTimeCompleteLevel();

        //         save.totalTime += 

        // GameManager.currentSaveGame.totalTime +=TimeManager.GetTimeCompleteLevel();
        
        SceneManager.LoadScene("scn_Win");
    }
}
