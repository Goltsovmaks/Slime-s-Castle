using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;

public class MenuController: MonoBehaviour{

    public static MenuController instance = null;

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

    [SerializeField] private SavedData settingsData = new SavedData();

    [SerializeField] private SaveGame[] savesGame = new SaveGame[4]{null, new SaveGame(1), new SaveGame(2), new SaveGame(3)};

    [SerializeField] private SaveGame saveGame1 = new SaveGame(1);
    [SerializeField] private SaveGame saveGame2 = new SaveGame(2);
    [SerializeField] private SaveGame saveGame3 = new SaveGame(3);

    public string nameCurrentSave;



    //PlayerInput _input;

    [SerializeField] private GameObject currentMenu;
    [SerializeField] private GameObject previuosMenu;

    public bool onPause = false; //Взять у основного GameManager

    public delegate void SomeAction();
    public delegate void SetSpawnPosition(Vector3 position);
    public delegate Vector3 GetSpawnPosition();
    public SomeAction NextAction;

    public static event SetSpawnPosition SetSpawnPositionEvent;
    public static event GetSpawnPosition GetSpawnPositionEvent;

    InputManager input;


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


        string Data= System.IO.File.ReadAllText(Application.persistentDataPath + "/_SavedData.json"); /// ПРОВЕРИТЬ НАЛИЧИЕ
        settingsData = JsonUtility.FromJson<SavedData>(Data);
        Debug.Log(settingsData.volume);

        //назначить current menu
    }

    void Start()
    {
        input = InputManager.instance;

        //_input = GetComponent<PlayerInput>();
        input.playerInput.actions["ReturnToPreviousMenu"].performed += context => ReturnButtonPressed();

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

    public void PlayNewGame(int numberOfSave)
    {


        string Data;
        savesGame[numberOfSave].UpdateTimeSave();
        nameCurrentSave=savesGame[numberOfSave].nameOfSave;
        // savesGame[numberOfSave].position=null;
        Debug.Log(savesGame[numberOfSave].position);

        Data = JsonUtility.ToJson(savesGame[numberOfSave]);

        
        System.IO.File.WriteAllText(Application.persistentDataPath + "/saveGame"+numberOfSave+".json",Data);

        //SceneManager.LoadScene("scn_trainLevel");
        currentMenu.gameObject.SetActive(false);
        Debug.Log("Загружаю сцену " + numberOfSave);


        currentMenu=pnl_pause;
        Time.timeScale = 1f; //Костыль
        onPause=false;//Костыль

        SceneManager.LoadScene(1);
        

    }

    public void ContinueGame(int numberOfSave)
    {
        // Загружает игру и применяет к ней данные из сохранения
        string path=Application.persistentDataPath+"/saveGame"+numberOfSave+".json";
        SaveGame objectSave=JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));

        string Data;
        SaveGame save=new SaveGame(numberOfSave);
        

        
        
        


        // Добавить в current menu окно паузы - сделано
        //SceneManager.LoadScene("scn_trainLevel");
        currentMenu.gameObject.SetActive(false);
        currentMenu=pnl_pause;
        Time.timeScale = 1f; //Костыль
        onPause=false;
        Debug.Log("Загружаю сцену " + numberOfSave);
        SceneManager.LoadScene(1);


        if(objectSave.position==null){
            Data = JsonUtility.ToJson(save);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/saveGame"+numberOfSave+".json",Data);
        }else{
            save.position=objectSave.position;
            SetSpawnPositionEvent(objectSave.position);
            Data = JsonUtility.ToJson(save);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/saveGame"+numberOfSave+".json",Data);

        }
 


                
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
        for(int i=0;i<3;i++){
            // Нахожу панель одного сохранения
            Transform transform_pnl_save=pnl_chooseSave.transform.Find("pnl_save"+(i+1)).transform;
            transform_pnl_save.Find("pnl_SaveGame").gameObject.SetActive(true);
            transform_pnl_save.Find("pnl_continueGame").gameObject.SetActive(false);

            // Debug.Log(pnl_chooseSave.transform.Find("pnl_save"+(i+1)).gameObject.name);
            string path=Application.persistentDataPath+"/saveGame"+(i+1)+".json";
            // Если существует сохранение по конкретному пути - включаю необходимые панели, заполняю текстовые поля
            if(File.Exists(path)){
                SaveGame objectSave=JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
                // Debug.Log(path);
                transform_pnl_save.Find("txt_totalTimeResult").GetComponent<Text>().text=objectSave.totalTime;
                transform_pnl_save.Find("txt_lastSaveResult").GetComponent<Text>().text=objectSave.dataOfLastSave;
                
            }
        }

        goToNextMenu(pnl_chooseSave);


        

    }

    public void LoadPressed()
    {
        // Включаю нужные панели в choose save
        for(int i=0;i<3;i++){
            // Нахожу панель одного сохранения
            Transform transform_pnl_save=pnl_chooseSave.transform.Find("pnl_save"+(i+1)).transform;
            transform_pnl_save.Find("pnl_SaveGame").gameObject.SetActive(false);
            

            // Debug.Log(pnl_chooseSave.transform.Find("pnl_save"+(i+1)).gameObject.name);
            string path=Application.persistentDataPath+"/saveGame"+(i+1)+".json";
            // Если существует сохранение по конкретному пути - включаю необходимые панели, заполняю текстовые поля
            if(File.Exists(path)){
                // Панель активна, только если присутствует сохранение
                transform_pnl_save.Find("pnl_continueGame").gameObject.SetActive(true);
                SaveGame objectSave=JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
                // Debug.Log(path);
                transform_pnl_save.Find("txt_totalTimeResult").GetComponent<Text>().text=objectSave.totalTime;
                transform_pnl_save.Find("txt_lastSaveResult").GetComponent<Text>().text=objectSave.dataOfLastSave;
            }
        }
        
        goToNextMenu(pnl_chooseSave);


    }
    public void deleteSavePressed(int numberOfSave)
    {
        string path=Application.persistentDataPath+"/saveGame"+numberOfSave+".json";
        File.Delete(path);

    }


    public void gameSavePressed(int numberOfSave)
    {  
        nameCurrentSave=savesGame[numberOfSave].nameOfSave;
        savesGame[numberOfSave].UpdateTimeSave();
        savesGame[numberOfSave].position=GetSpawnPositionEvent();

        // Добавляю в сейв данные игрока
        // save.dataOfLastSave=System.DateTime.Now.ToString("dd/MM/yyyy")+" "+System.DateTime.Now.ToString("HH:mm:ss");
        string Data = JsonUtility.ToJson(savesGame[numberOfSave]);
        File.WriteAllText(Application.persistentDataPath + "/saveGame"+numberOfSave+".json",Data);
        // SetSpawnPositionEvent(save.position);
        
        goToNextMenu(pnl_pause);


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



    //private void OnEnable()
    //{
    //    _input.Enable();
    //}

    //private void OnDisable()
    //{
    //    _input.Disable();
    //}

}
