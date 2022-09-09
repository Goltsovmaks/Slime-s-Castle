using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;
using UnityEngine.Audio;



using System;
using System.Text;

public class MenuController: MonoBehaviour{

    public static MenuController instance = null;


    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Toggle toggleFullScreen;
    [SerializeField] private Toggle toggleVSync;

    [SerializeField] GameObject pnl_pause;
    [SerializeField] GameObject pnl_chooseSave;

    [SerializeField] GameObject pnl_dead;


    // public string nameCurrentSave;

    //PlayerInput _input;

    [SerializeField] private GameObject currentMenu;
    [SerializeField] private GameObject previuosMenu;

    public bool onPause = false; //Взять у основного GameManager

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
            Debug.Log("Удаляю " + gameObject.name);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

      
        //_input.actions.FindActionMap("Slime").Enable();
        //_input.actions.FindActionMap("UI").Enable();

        // _input.actions["Pause"].performed += context => PausePressed();


        //назначить current menu
    }

    void Start()
    {
        input = InputManager.instance;
        SaveController = scr_SaveController.instance;
        GameManager = scr_GameManager.instance;
        TimeManager = scr_TimeManager.instance;

        //_input = GetComponent<PlayerInput>();
        input.playerInput.actions["ReturnToPreviousMenu"].performed += context => ReturnButtonPressed();

        SettingsData settingsData = SaveController.GetSettingsData();
        GameManager.currentSettingsData=settingsData;

        sliderVolume.value = settingsData.volume;
        toggleFullScreen.isOn = settingsData.fullScreen;

        UpdateVolume();
        //if (PlayerPrefs.HasKey("BG_MUSIC")){
        //    // sliderObj.value=PlayerPrefs.GetFloat("BG_MUSIC");

        //}
    }

    public void UpdateVolume()
    {
        audioMixer.SetFloat("MasterVolume", (float)Math.Log10(sliderVolume.value) * 20);
    }

    public void ReturnButtonPressed()
    { //Сделать поиск активного  1 окна!!!
        switch (currentMenu.name)
        {
            case "pnl_main":
                // PausePressed(); //Для теста - после настройки - удалить

                QuitGame();//confirm
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
        Debug.Log("Closing the game...");
    }

    public void PlayNewGame(int numberOfSave)
    {
        //Cursor.visible = false;
        SaveGame save = new SaveGame(numberOfSave);
        save.newGame=true;
        GameManager.currentSaveGame=save;
        SaveController.SetSaveGame(numberOfSave,save);
        // nameCurrentSave = "saveGame"+ numberOfSave;
        
        currentMenu.gameObject.SetActive(false);
        Debug.Log("Загружаю сцену " + numberOfSave);


        currentMenu=pnl_pause;
        Time.timeScale = 1f; //Костыль
        onPause=false;//Костыль

        SceneManager.LoadScene(1);
        
    }

    public void ContinueGame(int numberOfSave)
    {
        Cursor.visible = false;
        //GameObject.Find("pnl_attention").SetActive(false);

        SaveGame save = SaveController.GetSaveGame(numberOfSave);
        save.UpdateTimeSave();
        GameManager.currentSaveGame=save;
        SaveController.SetSaveGame(numberOfSave,save);

        //scr_Player.instance.AddCoin(save.playerCoins);

        // SetSpawnPositionEvent(save.position);
        
  
        // Добавить в current menu окно паузы - сделано
        //SceneManager.LoadScene("scn_trainLevel");
        currentMenu.gameObject.SetActive(false);
        currentMenu=pnl_pause;
        Time.timeScale = 1f; //Костыль
        onPause=false;
        Debug.Log("Загружаю сцену " + numberOfSave);
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
        // currentMenu.gameObject.SetActive(!currentMenu.gameObject.activeInHierarchy);
        // goToNextMenu(pnl_pause);


        if (Time.timeScale==1f){
            Time.timeScale = 0f;
        } else{
            Time.timeScale = 1f;
        }
        pnl_pause.SetActive(!pnl_pause.activeInHierarchy);
        //File.AppendAllText(@"c:\temp\MyTest.txt", $"void PausePressed, pnl status: {pnl_pause.activeInHierarchy }" + "\n", Encoding.UTF8);
    }

    public void SavePressed()
    {
        for(int i=1;i<=3;i++){
            // Нахожу панель одного сохранения
            Transform transform_pnl_save=pnl_chooseSave.transform.Find("pnl_save"+i).transform;
            transform_pnl_save.Find("pnl_SaveGame").gameObject.SetActive(true);
            transform_pnl_save.Find("pnl_continueGame").gameObject.SetActive(false);

            // Если существует сохранение по конкретному пути - включаю необходимые панели, заполняю текстовые поля
            if(SaveController.ExistsSaveGame(i)){
                SaveGame save = SaveController.GetSaveGame(i);
                transform_pnl_save.Find("txt_totalTimeResult").GetComponent<Text>().text = save.totalTime + " s";
                transform_pnl_save.Find("txt_lastSaveResult").GetComponent<Text>().text = save.dataOfLastSave;
            }

        }

        goToNextMenu(pnl_chooseSave);


    }

    public void LoadPressed()
    {
        // Включаю нужные панели в choose save
        for(int i=1;i<=3;i++){
            // Нахожу панель одного сохранения
            Transform transform_pnl_save=pnl_chooseSave.transform.Find("pnl_save"+i).transform;
            transform_pnl_save.Find("pnl_SaveGame").gameObject.SetActive(false);
            
            // Если существует сохранение по конкретному пути - включаю необходимые панели, заполняю текстовые поля
            if(SaveController.ExistsSaveGame(i)){
                transform_pnl_save.Find("pnl_continueGame").gameObject.SetActive(true);
                SaveGame save = SaveController.GetSaveGame(i);

                transform_pnl_save.Find("txt_totalTimeResult").GetComponent<Text>().text = save.totalTime + " s";
                transform_pnl_save.Find("txt_lastSaveResult").GetComponent<Text>().text = save.dataOfLastSave;
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
        save.totalTime += TimeManager.GetTimeCompleteLevel();

        GameManager.currentSaveGame=save;
        SaveController.SetSaveGame(numberOfSave,save);

        goToNextMenu(pnl_pause);


    }

    // Функция сохранения данных, которые мы указали в настройках
    public void BackFromSettingsPressed()
    {  
        SettingsData settingsData = new SettingsData();
        settingsData.volume = sliderVolume.value;
        settingsData.fullScreen = toggleFullScreen.isOn;
        SaveController.SetSettingsData(settingsData);

    }



    public void SetNextAction(string action)//enum_actions action
    {
        switch (action)
        {
            case "QuitGame"://enum_actions.QuitGame
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

    


    //private void OnEnable()
    //{
    //    _input.Enable();
    //}

    //private void OnDisable()
    //{
    //    _input.Disable();
    //}

}
