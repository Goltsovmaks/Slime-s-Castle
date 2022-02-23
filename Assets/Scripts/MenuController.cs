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

    void Start()
    {
        gameObjects=new GameObject[]{Main,Settings,PlayerControl};

        float volume;


        if (PlayerPrefs.HasKey("BG_MUSIC")){
            sliderObj.value=PlayerPrefs.GetFloat("BG_MUSIC");

       }



        


    }
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Escape) && !Pause.activeInHierarchy)
        // {
        //     Pause.SetActive(true);
        //     Time.timeScale = 0.01f;
        // }
        // else if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf && !Dead.activeInHierarchy)
        // {
        //     Pause.SetActive(false);
        //     Time.timeScale = 1f;
        // }

        if((Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Backspace))){
            if(Settings.activeSelf){
                BackFromSettingsPressed();
            }
            if(PlayerControl.activeSelf){
                BackFromPlayerControl();
            }
            
        }

    }
    public void PlayPressed()
    {   
        if(SlimeData.currentLevel!=null){
            SceneManager.LoadScene(SlimeData.currentLevel);
        }else{
            SceneManager.LoadScene("trainLevel");
        }
        

    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    public void SettingsPressed()
    {
        setActiveOnlyFrom(Settings,gameObjects);
    }
    public void ControlsPressed()
    {
        setActiveOnlyFrom(PlayerControl,gameObjects);
    }


    public void BackFromSettingsPressed()
    {
        setActiveOnlyFrom(Main,gameObjects);
    }

    public void BackFromPlayerControl()
    {
        setActiveOnlyFrom(Settings,gameObjects);
    }

    public void setActiveOnlyFrom(GameObject toSetObject, GameObject[] objects){
        foreach(GameObject objectFromObjects in objects){
            objectFromObjects.SetActive(false);
        }
        toSetObject.SetActive(true);
        
    }

}
