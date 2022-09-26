using UnityEngine;

public class scr_GameManager : MonoBehaviour
{
    public static scr_GameManager instance = null;

    public GameObject startPosition;
    public GameObject player;

    scr_SaveController SaveController;

    public SaveGame currentSaveGame;
    public SettingsData currentSettingsData;

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
        SaveController = scr_SaveController.instance;
    }

    public void SetStartPosition()
    {
        startPosition=GameObject.Find("StartPosition");
        if(currentSaveGame.newGame)
        {
            player.transform.position = startPosition.transform.position;
            currentSaveGame.position = startPosition.transform.position;
            SaveController.SetSaveGame(currentSaveGame.numberOfSave,currentSaveGame);
        }
        else
        {
            player.transform.position = currentSaveGame.position;
        }

    }
}
