using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringGoal : Goal
{
    private int itemID;

    public GatheringGoal(Quest quest, bool completed, string description, int itemID, int currentAmount, int requiredAmount)
    {
        this.quest = quest;
        this.completed = completed;
        this.description = description;
        this.currentAmount = currentAmount;
        this.requiredAmount = requiredAmount;
        this.itemID = itemID;
    }
    public override void Init()
    {
        base.Init();
        //подписаться на ивент подбираемых вещей
        //ItemCollectedEvent += ItemCollected(int itemID)
    }

    private void ItemCollected(int itemID)
    {
        if (itemID == this.itemID)
        {
            currentAmount++;
            Evaluate();
        }
    }
}
