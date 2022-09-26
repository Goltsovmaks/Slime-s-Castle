using UnityEngine;

public class scr_TimeManager : MonoBehaviour
{
    public static scr_TimeManager instance = null;

    [SerializeField]private float timeStartLevel;

    [SerializeField]private float timeSinceStartLevel;

    [SerializeField]private float timeLastGetTime;

    [SerializeField]private float timeCompleteLevel;

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

    void Start()
    {
        SetTimeStartLevel();
        
    }

    public void SetTimeStartLevel()
    {
        timeStartLevel = Time.time;
    }

    public float GetTimeSinceStartLevel()
    {
        return Time.time - timeStartLevel;
    }

    public void SetTimeCompleteLevel()
    {
        timeSinceStartLevel = Time.time - timeStartLevel;
        timeCompleteLevel = timeSinceStartLevel;
    }

    public float GetTimeCompleteLevel()
    {
        return timeCompleteLevel;
    }

    public float GetTimeSinceGetLastTime()
    {
        float timeLastRequest = Time.time - timeLastGetTime;
        timeLastGetTime = Time.time;
        return timeLastRequest;
    }


}
