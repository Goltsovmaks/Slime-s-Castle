using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;

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

    [SerializeField] GameObject pnl_pause;
    [SerializeField] GameObject pnl_chooseSave;

    [SerializeField] GameObject pnl_continueGame1;
    [SerializeField] GameObject pnl_SaveGame1;
    [SerializeField] Text txt_totalTimeResult;
    [SerializeField] Text txt_lastSaveResult;

    [SerializeField] GameObject pnl_continueGame2;
    [SerializeField] GameObject pnl_SaveGame2;

    [SerializeField] GameObject pnl_continueGame3;
    [SerializeField] GameObject pnl_SaveGame3;




    [SerializeField] private SavedData settingsData = new SavedData();

    [SerializeField] private SaveGame saveGame1 = new SaveGame(1);
    [SerializeField] private SaveGame saveGame2 = new SaveGame(2);
    [SerializeField] private SaveGame saveGame3 = new SaveGame(3);



    PlayerInput _input;

    [SerializeField] private GameObject currentMenu;
    private GameObject previuosMenu;

    public bool onPause = false; //Взять у основного GameManager

    public delegate void SomeAction();
    public SomeAction NextAction;


    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _input.actions["ReturnToPreviousMenu"].performed += context => ReturnButtonPressed();
        // _input.actions["Pause"].performed += context => PausePressed();


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
    { //Сделать поиск активного  1 окна!!!
        switch (currentMenu.name)
        {
            case "pnl_main":
                PausePressed(); //Для теста - после настройки - удалить

                // QuitGame();//confirm
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

    public void PlayGame(int numberOfSave)
    {
        // Добавить в current menu окно паузы
        string Data;
        Data = JsonUtility.ToJson(new SaveGame(numberOfSave));
        System.IO.File.WriteAllText(Application.persistentDataPath + "/saveGame"+numberOfSave+".json",Data);

        //SceneManager.LoadScene("scn_trainLevel");
        currentMenu.gameObject.SetActive(false);
        Debug.Log("Загружаю сцену " + numberOfSave);
        
        // switch (numberOfSave)
        // {
        //     case 1:
                
        //         break;
        //     case 2:
        //         Data = JsonUtility.ToJson(saveGame2);
        //         break;
        //     case 3:
        //         Data = JsonUtility.ToJson(saveGame3);
        //         break;
        //     default:
        //         Data = JsonUtility.ToJson(saveGame1);
        //         break;

        // }

        
        
    }

    public void PausePressed()
    {
        onPause = !onPause;
        // currentMenu.gameObject.SetActive(!currentMenu.gameObject.activeInHierarchy);
        // goToNextMenu(pnl_pause);

        if(Time.timeScale==1f){
            Time.timeScale = 0f;
        } else{
            Time.timeScale = 1f;
        }
        pnl_pause.SetActive(!pnl_pause.activeInHierarchy);

    }

    public void SavePressed()
    {
        // pnl_SaveGame1.SetActive(true);
        // pnl_SaveGame2.SetActive(true);
        // pnl_SaveGame3.SetActive(true);
        // if(File.Exists(Application.persistentDataPath+"/saveGame1.json")){
        //     saveGame1 = JsonUtility.FromJson<SaveGame>(File.ReadAllText(Application.persistentDataPath + "/saveGame1.json"));
            
        //     // txt_totalTimeResult.text=saveGame1.totalTime;
        //     txt_lastSaveResult.text=saveGame1.dataOfLastSave;


        // }

        // if(File.Exists(Application.persistentDataPath+"/saveGame2.json")){
        //     saveGame2 = JsonUtility.FromJson<SaveGame>(File.ReadAllText(Application.persistentDataPath + "/saveGame2.json"));
            
        // }
        // if(File.Exists(Application.persistentDataPath+"/saveGame3.json")){
        //     saveGame3 = JsonUtility.FromJson<SaveGame>(File.ReadAllText(Application.persistentDataPath + "/saveGame3.json"));
        // }

        // string Data= System.IO.File.ReadAllText(Application.persistentDataPath + "/_SavedData.json");
        // SavedData 
        // Включаю нужные панели в choose save
        // pnl_chooseSave.SetActive(true);
        goToNextMenu(pnl_chooseSave);

        // pnl_chooseSave.transform.Find("pnl_save"+1).transform.Find("txt_lastSaveResult").GetComponent<Text>().text="+++";
        // Debug.Log(pnl_chooseSave.transform.Find("pnl_save"+1).transform.Find("txt_lastSaveResult"));

        for(int i=0;i<3;i++){
            pnl_chooseSave.transform.Find("pnl_save"+i+1).GetComponent<GameObject>().SetActive(true);
            string path=Application.persistentDataPath+"/saveGame"+(i+1)+".json";

            if(File.Exists(path)){
                
                SaveGame objectSave=JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
                Debug.Log(path);
                pnl_chooseSave.transform.Find("pnl_save"+(i+1)).transform.Find("txt_lastSaveResult").GetComponent<Text>().text=objectSave.dataOfLastSave;
                
            }
        }

    }

    public void LoadPressed()
    {
        // Включаю нужные панели в choose save
        // pnl_chooseSave.SetActive(true);
        goToNextMenu(pnl_chooseSave);


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

    //private void OnEnable()
    //{
    //    _input.Enable();
    //}

    //private void OnDisable()
    //{
    //    _input.Disable();
    //}

}
