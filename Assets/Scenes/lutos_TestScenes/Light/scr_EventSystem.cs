using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class scr_EventSystem : MonoBehaviour
{
    public static scr_EventSystem instance = null;

    public UnityEvent<string> playerEnteredDialogTrigger;
    public UnityEvent<string> playerEnteredObjectTrigger;
    public UnityEvent<string, missionStatus> playerEnteredMissionTrigger;

    public UnityEvent<string> playerLeftDialogTrigger;
    public UnityEvent<string> playerLeftObjectTrigger;
    public UnityEvent<string, missionStatus> playerLeftMissionTrigger;

    public UnityEvent<int> playerTriggerExit; // ???

    public UnityEvent slimeHasAttacked;
    public UnityEvent<int> mobDeath;

    public UnityEvent<GameObject> playerAwake;




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
    }


   
    
}
