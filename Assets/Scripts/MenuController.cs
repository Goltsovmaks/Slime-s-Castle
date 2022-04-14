using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController: MonoBehaviour{

    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject PlayerControl;
    [SerializeField] private Slider sliderObj;
    private GameObject[] gameObjects;
    [SerializeField] private string levelName = SlimeData.currentLevel;

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

        //назначить current menu
    }

    void Start()
    {
        gameObjects=new GameObject[]{Main,Settings,PlayerControl};

        float volume;


        if (PlayerPrefs.HasKey("BG_MUSIC")){
            sliderObj.value=PlayerPrefs.GetFloat("BG_MUSIC");

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

    public void PlayGame()
    {
        //SceneManager.LoadScene("scn_trainLevel");
        currentMenu.gameObject.SetActive(false);
        Debug.Log("Загружаю новую сцену");
        
    }

    public void Pause()
    {
        //ставим/выключаем паузу в игре
        onPause = !onPause;
        currentMenu.gameObject.SetActive(!currentMenu.gameObject.activeInHierarchy);
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
