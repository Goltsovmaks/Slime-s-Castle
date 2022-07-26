using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] protected List<string> myMissions = new List<string>();
    [SerializeField] protected List<string> myQuests = new List<string>();
    [SerializeField] protected List<string> myQuestsRequiredState = new List<string>();
    [SerializeField] protected int currentQuestIndex = 0;

    public void Interact()
    {
        string myState = CheckBoxSystem.instance.CheckMissionStatus(myMissions);
        DialogueManager.instance.StartDialogue(myState);
        //complete quest!??
        TryAssignNextQuest(myState);
    }

    protected void TryAssignNextQuest(string myState)
    {
        if (currentQuestIndex < myQuests.Count)
        {
            if (myQuestsRequiredState[currentQuestIndex] == myState)
            {
                QuestSystem.instance.AssignQuest(myQuests[currentQuestIndex]);
                currentQuestIndex += 1;
            }
        }
    }

}

