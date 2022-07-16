using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_GLADOS : NPC
{
    private void Start()
    {
        //вставить квесты в цели?
        myMissions.Add("q_MushroomCollector");
        myMissions.Add("p_StoneDoor");
        myQuests.Add("q_MushroomCollector");
        myQuestsRequiredState.Add("02");
    }
}
