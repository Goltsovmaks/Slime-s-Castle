﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{
    // public Transform slime;
    public Animator Anim;
    // private Vector3 StartPos;
    //  [SerializeField]private GameObject WinWindow;



    void Start()
    {


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
        SlimeData.currentLevel=SceneManager.GetActiveScene().name;

        SlimeData.FinishedLevelTime.Add(Time.timeSinceLevelLoad);
        SlimeData.NumberOfLevel++;
        
        
        SceneManager.LoadScene("scn_Win");
    }
}
