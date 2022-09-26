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

    private void Start()
    {
        missions.Add("q_MushroomCollector", missionStatus.notAssigned);
        missions.Add("q_FirstKillLesson", missionStatus.notAssigned);
        missions.Add("p_StoneDoor", missionStatus.notAssigned);
        missions.Add("m_pit", missionStatus.notAssigned);

        scr_EventSystem.instance.playerEnteredMissionTrigger.AddListener(ChangeMissionStatus);
    }


    private void ChangeMissionStatus(string missionName, missionStatus status)
    {
        missions[missionName] = status;
    }


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

    private void OnDestroy()
    {
        scr_EventSystem.instance.playerEnteredMissionTrigger.RemoveListener(ChangeMissionStatus);
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
