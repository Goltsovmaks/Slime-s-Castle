
public class npc_GLADOS : NPC
{
    private void Start()
    {
        base.Start();
        myMissions.Add("q_MushroomCollector");
        myMissions.Add("m_pit");
        myQuests.Add("q_MushroomCollector");
        myQuestsRequiredState.Add("02");
    }
}
