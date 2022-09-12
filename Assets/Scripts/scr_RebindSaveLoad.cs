using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class scr_RebindSaveLoad : MonoBehaviour
{
    public InputActionAsset actions;
    public PlayerInput playerInput;

    public void OnEnable()
    {
        string path = Application.streamingAssetsPath + "/rebinds" + ".json";

        string rebinds = File.ReadAllText(path);
        if (!string.IsNullOrEmpty(rebinds) && rebinds != "")
        {
            playerInput.actions.LoadFromJson(rebinds);
            //actions = InputActionAsset.FromJson(rebinds);
            //actions.LoadFromJson(rebinds);
        }


        //var rebinds = PlayerPrefs.GetString("rebinds");
        //if (!string.IsNullOrEmpty(rebinds))
        //    actions.LoadFromJson(rebinds);

    }

    public void OnDisable()
    {
        Debug.Log("disabled");
        string path = Application.streamingAssetsPath + "/rebinds" + ".json";
        
        string rebinds = playerInput.actions.ToJson(); ; //JsonUtility.ToJson(actions)
        System.IO.File.WriteAllText(path, rebinds);

        //var rebinds = actions.ToJson();
        //PlayerPrefs.SetString("rebinds", rebinds);

        

    }
}
