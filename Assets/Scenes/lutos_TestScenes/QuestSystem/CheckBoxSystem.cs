using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxSystem : MonoBehaviour
{
    public Dictionary<string, goalStatus> missions = new Dictionary<string, goalStatus>();

    public static CheckBoxSystem instance;

    public string CheckMissionStatus(List<string> missionArray)
    {
        //выдает статус миссий
        return "0000";
    }
}

public enum goalStatus
{
    notAssigned,
    inProgress,
    achieved,
    completed,
    failed
}
