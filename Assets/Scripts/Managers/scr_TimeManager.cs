using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TimeManager : MonoBehaviour
{
    public static scr_TimeManager instance = null;

    [SerializeField]private float timeStartLevel;

    [SerializeField]private float timeSinceStartLevel;

    [SerializeField]private float timeLastGetTime;

    [SerializeField]private float timeCompleteLevel;

    // private Dictionary<string,float>;


    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Удаляю " + gameObject.name);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetTimeStartLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GetSinceStartLevel());
        

    }

    public void SetTimeStartLevel(){
        timeStartLevel = Time.time;
    }

    public float GetTimeSinceStartLevel(){
        
        return Time.time - timeStartLevel;
    }

    public void SetTimeCompleteLevel(){
        timeSinceStartLevel = Time.time - timeStartLevel;
        timeCompleteLevel = timeSinceStartLevel;
    }

    public float GetTimeCompleteLevel(){
        return timeCompleteLevel;
    }

    public float GetTimeSinceGetLastTime(){
        float timeLastRequest = Time.time - timeLastGetTime;
        timeLastGetTime = Time.time;
        return timeLastRequest;
    }


}
