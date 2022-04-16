using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController: MonoBehaviour{

    // [SerializeField] private GameObject Main;
    // [SerializeField] private GameObject Settings;
    // [SerializeField] private GameObject PlayerControl;

    // [SerializeField] private Slider sliderObj;
    // private GameObject[] gameObjects;
    // [SerializeField] private string levelName = SlimeData.currentLevel;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Toggle toggleFullScreen;
    [SerializeField] private Toggle toggleVSync;

    [SerializeField] private SavedData settingsData = new SavedData();

    [SerializeField] private SaveGame saveGame1 = new SaveGame();
    [SerializeField] private SaveGame saveGame2 = new SaveGame();
    [SerializeField] private SaveGame saveGame3 = new SaveGame();



    Inpt_cnpt_Input _input;

    [SerializeField] private GameObject currentMenu;
    private GameObject previuosMenu;

    public bool onPause = false; //Взять у основного GameManager

    public delegate void SomeAction();
    public SomeAction NextAction;


    private void Awake()
    {
        _input = new Inpt_cnpt_Input();
        _input.UI.ReturnToPreviousMenu.performed += context => ReturnButtonPressed();

        string Data= System.IO.File.ReadAllText(Application.persistentDataPath + "/_SavedData.json");
        settingsData = JsonUtility.FromJson<SavedData>(Data);
        Debug.Log(settingsData.volume);

        //назначить current menu
    }

    void Start()
    {
        sliderVolume.value = settingsData.volume;
        toggleFullScreen.isOn = settingsData.fullScreen;

        // gameObjects=new GameObject[]{Main,Settings,PlayerControl};




        if (PlayerPrefs.HasKey("BG_MUSIC")){
            // sliderObj.value=PlayerPrefs.GetFloat("BG_MUSIC");

       }
    }

    public void ReturnButtonPressed()
    {
        switch (currentMenu.name)
        {
            case "MainPanel":
                QuitGame();//confirm
                break;
            case "PauseMenu":
                Pause();
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

    public void PlayGame(int numberOfSave)
    {
        string Data;
        

        switch (numberOfSave)
        {
            case 1:
                Data = JsonUtility.ToJson(saveGame1);
                break;
            case 2:
                Data = JsonUtility.ToJson(saveGame2);
                break;
            case 3:
                Data = JsonUtility.ToJson(saveGame3);
                break;
            default:
                Data = JsonUtility.ToJson(saveGame1);
                break;

        }

        System.IO.File.WriteAllText(Application.persistentDataPath + "/saveGame"+numberOfSave+".json",Data);

        //SceneManager.LoadScene("scn_trainLevel");
        currentMenu.gameObject.SetActive(false);
        Debug.Log("Загружаю сцену " + numberOfSave);
        
    }

    public void Pause()
    {
        //ставим/выключаем паузу в игре
        onPause = !onPause;
        currentMenu.gameObject.SetActive(!currentMenu.gameObject.activeInHierarchy);

         
        if(Time.timeScale==1f){
            Time.timeScale = 0f;
        } else{
            Time.timeScale = 1f;
        }

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

    //public void PlayPressed()
    //{   
    //    if(SlimeData.currentLevel!=null){
    //        SceneManager.LoadScene(SlimeData.currentLevel);
    //    }else{
    //        SceneManager.LoadScene("scn_trainLevel");
    //    }
        

    //}

    //public void ExitPressed()
    //{
    //    Application.Quit();
    //}
    //public void SettingsPressed()
    //{
    //    setActiveOnlyFrom(Settings,gameObjects);
    //}
    //public void ControlsPressed()
    //{
    //    setActiveOnlyFrom(PlayerControl,gameObjects);
    //}


    //public void BackFromSettingsPressed()
    //{
    //    setActiveOnlyFrom(Main,gameObjects);
    //}

    //public void BackFromPlayerControl()
    //{
    //    setActiveOnlyFrom(Settings,gameObjects);
    //}

    //public void setActiveOnlyFrom(GameObject toSetObject, GameObject[] objects){
    //    foreach(GameObject objectFromObjects in objects){
    //        objectFromObjects.SetActive(false);
    //    }
    //    toSetObject.SetActive(true);
        
    //}

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

}
