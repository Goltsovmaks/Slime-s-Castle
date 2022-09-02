using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    private bool completed;

    public string title;
    public string description;

    //public string requiredState;

    //reward?

    private void Start()
    {
        //add info from file (such as title/goals etc)
        Init();
    }

    public List<Goal> goals = new List<Goal>();

    public void Init()
    {
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
        QuestSystem.instance.CompleteQuest(this.GetType().ToString());
        Destroy(this);
    }

}
