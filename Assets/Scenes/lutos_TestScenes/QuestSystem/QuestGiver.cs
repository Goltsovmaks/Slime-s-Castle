using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{ 
    public Quest currentQuest;
    QuestStatus currentQuestStatus = QuestStatus.notAssigned;

    //public List<Quest> quests = new List<Quest>();

    //грузится из джысона ^_^
    List<string> quests = new List<string>()
    {
        "MushroomCollector",
        "MushroomCollector 2.0"
    };

    //private void Start()
    //{
    //    Init();
    //}

    //public override void Init()
    //{
    //    //base.Init();

    //}


    

    public void GiveReward()
    {
        // give some [currentQuest.reward];
    }
}
