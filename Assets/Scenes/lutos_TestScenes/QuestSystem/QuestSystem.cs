using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestSystem : MonoBehaviour
{
    //public Dictionary<string, QuestStatus> quests = new Dictionary<string, QuestStatus>();

    public static QuestSystem instance;

    //test!!!==========================================
    public UnityEvent<int> mushroomCollected;

    public void CollectMushroom(int itemID)
    {
        mushroomCollected.Invoke(itemID);
    }
    //test!!!==========================================
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
    
    private void Start()
    {
        //singleton?

        //get quests from textFile
    }

    public void AssignQuest(string questName)
    {
        CheckBoxSystem.instance.missions[questName] = missionStatus.inProgress;
        gameObject.AddComponent(System.Type.GetType(questName));
    }
    public void CompleteQuest(string questName)
    {
        CheckBoxSystem.instance.missions[questName] = missionStatus.achieved;
        //give reward?
        
    }
}

//public enum QuestStatus
//{
//    notAssigned,
//    inProgress,
//    achieved,
//    completed,
//    failed
//}
