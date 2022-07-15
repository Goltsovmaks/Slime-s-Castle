using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]private List<string> myMissions = new List<string>();
    private List<Quest> myQuests = new List<Quest>();
    private int currentQuestIndex = 0;



    public void Interact()
    {
        string myState = CheckBoxSystem.instance.CheckMissionStatus(myMissions);
        ShowDialog(myState);
        TryAssignNextQuest(myState);
        
        //запустить диалог
        //дать квест, если требуется
    }

    private void TryAssignNextQuest(string myState)
    {
        if (myQuests[currentQuestIndex].requiredState == myState)
        {
            //запускаем квест
        }
    }

    private void ShowDialog(string code)
    {

    }
}
public enum npcState
{
    welcome,
    needHelp,
    inProgress,
    helped
}

