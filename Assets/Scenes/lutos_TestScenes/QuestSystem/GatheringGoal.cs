
[System.Serializable]
public class GatheringGoal : Goal
{
    public int itemID;

    public override void Init(Quest quest)
    {
        base.Init(quest);
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
