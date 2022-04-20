using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Debug.Log("”дал€ю " + gameObject.name);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }
}
