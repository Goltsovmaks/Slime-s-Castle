using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_GLADOS : NPC
{
    private void Start()
    {
        base.Start();
        //�������� ������ � ����?
        // Подгрузка из JSON
        myMissions.Add("q_MushroomCollector");
        myMissions.Add("m_pit");
        myQuests.Add("q_MushroomCollector");
        myQuestsRequiredState.Add("02");
    }
}
