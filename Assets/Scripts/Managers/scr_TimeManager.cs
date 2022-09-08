using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TimeManager : MonoBehaviour
{
    public static scr_TimeManager instance = null;

    [SerializeField]private float timeStartLevel;

    [SerializeField]private float timeSinceStartLevel;

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
        SetTimeeStartLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GetSinceStartLevel());
        

    }

    public void SetTimeeStartLevel(){
        timeStartLevel = Time.time;
    }

    public float GetSinceStartLevel(){
        timeSinceStartLevel = Time.time - timeStartLevel;
        return timeSinceStartLevel;
    }


}
