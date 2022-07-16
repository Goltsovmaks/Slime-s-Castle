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
        //requiredState = "0";

        goals.Add(new GatheringGoal(this,false,"Collect 3 GREEN mushrooms",99, 0, 3));
        goals.Add(new GatheringGoal(this,false, "Collect 5 BLUE mushrooms", 55, 0, 5));

        Init();
    }
}
