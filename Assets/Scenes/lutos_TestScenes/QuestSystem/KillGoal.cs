using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KillGoal : Goal
{
    public int mobID;

    //public KillGoal(Quest quest, bool completed, string description, int mobID, int currentAmount, int requiredAmount)
    //{
    //    this.quest = quest;
    //    this.completed = completed;
    //    this.description = description;
    //    this.currentAmount = currentAmount;
    //    this.requiredAmount = requiredAmount;
    //    this.mobID = mobID;
    //}
    public override void Init(Quest quest)
    {
        base.Init(quest);
        //����������� �� ����� ����������� �����
        //ItemCollectedEvent += ItemCollected(int itemID)
        scr_EventSystem.instance.mobDeath.AddListener(MobKilled);
    }



    private void MobKilled(int mobID)
    {
        if (mobID == this.mobID)
        {
            currentAmount++;
            Evaluate();
        }
    }
}
