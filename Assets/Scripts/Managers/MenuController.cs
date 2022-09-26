using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class MenuController: MonoBehaviour
{

    public static MenuController instance = null;


    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Toggle toggleFullScreen;
    [SerializeField] private Toggle toggleVSync;

    [SerializeField] GameObject pnl_pause;
    [SerializeField] GameObject pnl_chooseSave;

    [SerializeField] GameObject pnl_dead;

    [SerializeField] public GameObject pnl_main;

    [SerializeField] public GameObject currentMenu;
    [SerializeField] private GameObject previuosMenu;

    public bool onPause = false;

    public delegate void SomeAction();
    public SomeAction NextAction;

    public delegate void SetSpawnPosition(Vector3 position);
    public delegate Vector3 GetSpawnPosition();

    public static event SetSpawnPosition SetSpawnPositionEvent;
    public static event GetSpawnPosition GetSpawnPositionEvent;

    InputManager input;
    scr_SaveController SaveController;
    scr_GameManager GameManager;
    scr_TimeManager TimeManager;

    [SerializeField]private AudioMixer audioMixer;
    
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
        input = InputManager.Instance;
        SaveController = scr_SaveController.instance;
        GameManager = scr_GameManager.instance;
        TimeManager = scr_TimeManager.instance;

        input.playerInput.actions["ReturnToPreviousMenu"].performed += 
            context => ReturnButtonPressed();

        SettingsData settingsData = SaveController.GetSettingsData();
        GameManager.currentSettingsData=settingsData;

        sliderVolume.value = settingsData.volume;
        toggleFullScreen.isOn = settingsData.fullScreen;

        UpdateVolume();
 
    }

    public void UpdateVolume()
    {
        audioMixer.SetFloat("MasterVolume", (float)Math.Log10(sliderVolume.value) * 20);
    }

    public void ReturnButtonPressed()
    { 
        switch (currentMenu.name)
        {
            case "pnl_main":
                QuitGame();
                break;
            case "pnl_pause":
                PausePressed();
                break;
            default:
                goToNextMenu(previuosMenu);
                break;
        }
    }

    public void goToNextMenu(GameObject nextMenu)
    {
        currentMenu.gameObject.SetActive(false);

        previuosMenu = currentMenu;
        currentMenu = nextMenu;

        nextMenu.gameObject.SetActive(true);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public void PlayNewGame(int numberOfSave)
    {
        SaveGame save = new SaveGame(numberOfSave);
        save.newGame=true;
        GameManager.currentSaveGame=save;
        SaveController.SetSaveGame(numberOfSave,save);
        
        currentMenu.gameObject.SetActive(false);

        currentMenu=pnl_pause;
        Time.timeScale = 1f;
        onPause=false;

        SceneManager.LoadScene(1);
        
    }

    public void ContinueGame(int numberOfSave)
    {
        Cursor.visible = false;

        SaveGame save = SaveController.GetSaveGame(numberOfSave);
        save.UpdateTimeSave();
        GameManager.currentSaveGame=save;
        SaveController.SetSaveGame(numberOfSave,save);

        currentMenu.gameObject.SetActive(false);
        currentMenu=pnl_pause;
        Time.timeScale = 1f;
        onPause=false;
        SceneManager.LoadScene(1);   
    }

    public void RevertCursor()
    {
        Cursor.visible = onPause;
    }

    public void PausePressed()
    {
        onPause = !onPause;
        Cursor.visible = onPause;

        if (Time.timeScale==1f){
            Time.timeScale = 0f;
        } else{
            Time.timeScale = 1f;
        }
        pnl_pause.SetActive(!pnl_pause.activeInHierarchy);
    }

    public void SavePressed()
    {
        for(int i=1;i<=3;i++)
        {
            Transform transform_pnl_save=pnl_chooseSave.transform.Find("pnl_save"+i).transform;
            transform_pnl_save.Find("pnl_SaveGame").gameObject.SetActive(true);
            transform_pnl_save.Find("pnl_continueGame").gameObject.SetActive(false);

            if(SaveController.ExistsSaveGame(i))
            {
                SaveGame save = SaveController.GetSaveGame(i);
                transform_pnl_save.Find("txt_totalTimeResult").GetComponent<Text>().text = 
                    save.GetTotalTime();
                transform_pnl_save.Find("txt_lastSaveResult").GetComponent<Text>().text = 
                    save.dataOfLastSave;
            }

        }

        goToNextMenu(pnl_chooseSave);
    }

    public void LoadPressed()
    {
        for(int i=1;i<=3;i++)
        {
            Transform transform_pnl_save=pnl_chooseSave.transform.Find("pnl_save"+i).transform;
            transform_pnl_save.Find("pnl_SaveGame").gameObject.SetActive(false);
            
            if(SaveController.ExistsSaveGame(i))
            {
                transform_pnl_save.Find("pnl_continueGame").gameObject.SetActive(true);
                SaveGame save = SaveController.GetSaveGame(i);

                transform_pnl_save.Find("txt_totalTimeResult").GetComponent<Text>().text = 
                    save.GetTotalTime();
                transform_pnl_save.Find("txt_lastSaveResult").GetComponent<Text>().text = 
                    save.dataOfLastSave;
            }

        }
        
        goToNextMenu(pnl_chooseSave);

    }
    public void deleteSavePressed(int numberOfSave)
    {
        SaveController.DeleteSaveGame(numberOfSave);
    }


    public void gameSavePressed(int numberOfSave)
    {  
        SaveGame save = SaveController.GetSaveGame(numberOfSave);
        save.UpdateTimeSave();
        save.newGame = false;
        save.position = GetSpawnPositionEvent();
        save.playerCoins = scr_Player.instance.currentNumberOfCoins;
        save.totalTime = GameManager.currentSaveGame.totalTime;
        save.totalTime += TimeManager.GetTimeSinceGetLastTime();

        GameManager.currentSaveGame=save;
        SaveController.SetSaveGame(numberOfSave,save);

        goToNextMenu(pnl_pause);
    }

    public void BackFromSettingsPressed()
    {  
        SettingsData settingsData = new SettingsData();
        settingsData.volume = sliderVolume.value;
        settingsData.fullScreen = toggleFullScreen.isOn;
        SaveController.SetSettingsData(settingsData);

    }



    public void SetNextAction(string action)
    {
        switch (action)
        {
            case "QuitGame":
                NextAction = QuitGame;
                break;
            default:
                break;
        }

    }

    public void Confirm()
    {
        NextAction();
    }

    public void ShowOrHideDiePanel()
    {
        pnl_dead.SetActive(!pnl_dead.activeInHierarchy);
    }

}
