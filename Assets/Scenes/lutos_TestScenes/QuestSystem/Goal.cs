using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal
{
    protected Quest quest;
    public bool completed;

    public string description;

    public int currentAmount;
    public int requiredAmount;

    public virtual void Init(Quest quest)
    {
        this.quest = quest;
    }

    protected void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        completed = true;
        quest.CheckGoals();
    }

    
}