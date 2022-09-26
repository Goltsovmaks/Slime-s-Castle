using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Quest : MonoBehaviour
{
    private bool completed;

    public string title;
    public string description;

    public List<Goal> goals = new List<Goal>();

    public void Init()
    {
        goals.ForEach(g => g.Init(this));
    }

    public void CheckGoals()
    {
        completed = goals.All(g => g.completed);
        if (completed)
        {
            Completed();
        }
    }
    public void Completed()
    {
        QuestSystem.instance.CompleteQuest(this.GetType().ToString());
        Destroy(this);
    }

    public void FillQuestAttributes(QuestSerializable quest)
    {
        title = quest.title;
        description = quest.description;
        goals = quest.goals;

        Init();
    }

    private void OnDestroy()
    {
        goals.ForEach(g => g.Uninit());
    }

}

[System.Serializable]
public class QuestSerializable
{
    public string title;
    public string description;

    public List<Goal> goals = new List<Goal>();
}
