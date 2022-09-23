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

    public string goalType;
    public int itemID;
    public int mobID;

    public virtual void Init(Quest quest)
    {
        this.quest = quest;

        switch (goalType)
        {
            case "GatheringGoal":
                QuestSystem.instance.mushroomCollected.AddListener(ItemCollected);
                break;
            case "KillGoal":
                scr_EventSystem.instance.mobDeath.AddListener(MobKilled);
                break;
        }
        
    }

    public virtual void Uninit()
    {
        switch (goalType)
        {
            case "GatheringGoal":
                QuestSystem.instance.mushroomCollected.RemoveListener(ItemCollected);
                break;
            case "KillGoal":
                scr_EventSystem.instance.mobDeath.RemoveListener(MobKilled);
                break;
        }

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

    private void ItemCollected(int itemID)
    {
        if (itemID == this.itemID)
        {
            currentAmount++;
            Evaluate();
        }
    }

    private void MobKilled(int mobID)
    {
        if (mobID == this.mobID)
        {
            Debug.Log("nice one, correct mob was killed");
            currentAmount++;
            Evaluate();
        }
    }

}
