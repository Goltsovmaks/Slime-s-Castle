using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class q_MushroomCollector : Quest
{
    private void Start()
    {
        //get info from textFile
        title = "Mushroom collector";
        description = "some description";

        goals.Add(new GatheringGoal(this,false,"Collect 3 GREEN mushrooms",0, 0, 3));
        goals.Add(new GatheringGoal(this,false, "Collect 5 BLUE mushrooms", 1, 0, 5));

        Init();
    }
}
