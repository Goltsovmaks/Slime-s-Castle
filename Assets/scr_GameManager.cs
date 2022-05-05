using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GameManager : MonoBehaviour
{
    public static scr_GameManager instance = null;

    public GameObject startPosition;
    public GameObject player;

    scr_SaveController SaveController;

    public SaveGame currentSaveGame;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Удаляю " + gameObject.name);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        
        player = GameObject.Find("Slime");
        // Debug.Log(startPosition.transform.position);
        Debug.Log("startPosition.transform.position");

        // Событие, которое извещает о том, что уровень загружается, в это время нужно найти на уровне объекты
    }

    public void SetStartPosition(){
        
        if(currentSaveGame.newGame){
            startPosition=GameObject.Find("StartPosition");
            player.transform.position = startPosition.transform.position;
        }else{
            player.transform.position = currentSaveGame.position;
        }

    }



}
