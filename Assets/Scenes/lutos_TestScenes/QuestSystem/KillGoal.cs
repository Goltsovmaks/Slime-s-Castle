
[System.Serializable]
public class KillGoal : Goal
{
    public int mobID;

    public override void Init(Quest quest)
    {
        base.Init(quest);
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
