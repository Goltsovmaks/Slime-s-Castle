using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    private bool completed;

    public string title;
    public string description;

    public string requiredState;

    //reward?
    
    public List<Goal> goals = new List<Goal>();

    public void Init()
    {
        QuestSystem.instance.quests[this.name] = QuestStatus.inProgress;
        goals.ForEach(g => g.Init());
    }

    public void CheckGoals()
    {
        //check if all goals are completed
        completed = goals.All(g => g.completed);
        if (completed)
        {
            Completed();
        }
    }

    public void Completed()
    {
        //update questProgress
        QuestSystem.instance.quests[this.name] = QuestStatus.achieved;
        Destroy(this);
    }

}
