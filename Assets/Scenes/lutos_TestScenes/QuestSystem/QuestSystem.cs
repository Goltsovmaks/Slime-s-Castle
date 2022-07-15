using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public Dictionary<string, QuestStatus> quests = new Dictionary<string, QuestStatus>();

    public static QuestSystem instance;

    private void Start()
    {
        //singleton?

        //get quests from textFile
    }

    public void AssignQuest(string questName)
    {
        if (quests[questName] == QuestStatus.notAssigned)
        {
            gameObject.AddComponent(System.Type.GetType(questName));
            quests[questName] = QuestStatus.inProgress;
        }
    }
    public void CompleteQuest(string questName)
    {
        if (quests[questName] == QuestStatus.achieved)
        {
            //уничтожить квест
            quests[questName] = QuestStatus.completed;
            //GiveReward();
        }
    }
}




public enum QuestStatus
{
    notAssigned,
    inProgress,
    achieved,
    completed,
    failed
}
