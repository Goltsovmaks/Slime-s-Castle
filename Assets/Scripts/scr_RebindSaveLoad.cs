using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class scr_RebindSaveLoad : MonoBehaviour
{
    public PlayerInput playerInput;

    public void OnEnable()
    {
        playerInput = InputManager.Instance.playerInput;
        //actions.Disable();
        string path = Application.streamingAssetsPath + "/rebinds" + ".json";

        string rebinds;

        using (var s = new StreamReader(path))
        {
            rebinds = s.ReadToEnd();
            Debug.Log("testStreamer");
        }

        //string rebinds = File.ReadAllText(path);
        if (!string.IsNullOrEmpty(rebinds))
        {
            //playerInput.actions.LoadFromJson(rebinds);
            //actions = InputActionAsset.FromJson(rebinds);
            //actions.LoadFromJson(rebinds);
        }

        //actions.Enable();


        Debug.Log("done");

        //var rebinds = PlayerPrefs.GetString("rebinds");
        //if (!string.IsNullOrEmpty(rebinds))
        //    actions.LoadFromJson(rebinds);

    }

    public void OnDisable()
    {
        playerInput = InputManager.Instance.playerInput;
        string path = Application.streamingAssetsPath + "/rebinds" + ".json";
        //string rebinds;

        //using (var s = new StreamWriter(path))
        //{
        //    Debug.Log("testStreamer2");
        //    rebinds = actions.ToJson();
        //    s.Write(rebinds);
        //}

        //foreach (var action in actions)
        //{
        //    action.
        //}

        string rebinds = playerInput.actions.ToJson(); ; //JsonUtility.ToJson(actions)
        System.IO.File.WriteAllText(path, rebinds);

        //var rebinds = actions.ToJson();
        //PlayerPrefs.SetString("rebinds", rebinds);



    }
}
