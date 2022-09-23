using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;

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
        SetupQuestFile("q_FirstKillLesson");
        Debug.Log(Application.streamingAssetsPath);
        Debug.Log(Application.dataPath);

       
    }

    public void AssignQuest(string questName)
    {
        CheckBoxSystem.instance.missions[questName] = missionStatus.inProgress;

        //gameObject.AddComponent(System.Type.GetType(questName));

        //---
        AddQuest(questName);
    }

    private void AddQuest(string questName)
    {
        Quest questComponent = gameObject.AddComponent<Quest>();
        questComponent.FillQuestAttributes(GetQuest(questName));
    }

    public void CompleteQuest(string questName)
    {
        CheckBoxSystem.instance.missions[questName] = missionStatus.achieved;
        //give reward?
        
    }

    //==========



    public QuestSerializable GetQuest(string questName)
    {
        if (QuestExists(questName))
        {
            string path = Application.streamingAssetsPath + "/Quests/" + questName + ".json";
            QuestSerializable quest = JsonUtility.FromJson<QuestSerializable>(File.ReadAllText(path));
            return quest;
        }
        else
        {
            Debug.Log("Файла квеста с таким именем не существует");
            return new QuestSerializable();
        }

    }

    public bool QuestExists(string quest)
    {
        string path = Application.streamingAssetsPath + "/Quests/" + quest + ".json";
        return File.Exists(path);
    }
    
    public void SetupQuestFile(string questName)
    {
        if (QuestExists(questName))
        {
            Debug.Log(questName + " Файл квеста с таким именем уже существует");
        }
        else
        {
            QuestSerializable quest = new QuestSerializable();
            quest.goals.Add(new Goal());
            quest.goals.Add(new Goal());

            string data = JsonUtility.ToJson(quest);
            string path = Application.streamingAssetsPath + "/Quests/" + questName + ".json";

            //string killGoalData = JsonUtility.ToJson(new KillGoal());
            //string gatheringGoalData = JsonUtility.ToJson(new GatheringGoal());

            //data += "\n" + killGoalData + "\n" + gatheringGoalData;

            System.IO.File.WriteAllText(path, data);
        }

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
