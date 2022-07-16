using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBoxSystem : MonoBehaviour
{
    public Dictionary<string, missionStatus> missions = new Dictionary<string, missionStatus>();

    public static CheckBoxSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
    //test!!!==========================================
    private void Start()
    {
        //test!!!
        missions.Add("q_MushroomCollector", missionStatus.notAssigned);
        missions.Add("p_StoneDoor", missionStatus.notAssigned);
    }
    public void SeeTheStoneDoor()
    {
        missions["p_StoneDoor"] = missionStatus.achieved;
    }
    public void CheckMissionState()
    {
        Debug.Log("Mission is " + missions["q_MushroomCollector"]);
    }
    //test!!!==========================================
    public string CheckMissionStatus(List<string> missionList)
    {
        string missionStatus = "";
        foreach (var mission in missionList)
        {
            missionStatus += (int)missions[mission];
        }
        //выдает статус миссий
        return missionStatus;
    }
}

public enum missionStatus
{
    notAssigned,
    inProgress,
    achieved,
    completed,
    failed
}
