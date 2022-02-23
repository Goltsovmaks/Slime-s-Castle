using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController: MonoBehaviour{

    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject Settings;
    [SerializeField] private string levelName = SlimeData.currentLevel;

    void Start()
    {

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

        if((Input.GetKeyDown(KeyCode.Escape)||Input.GetKeyDown(KeyCode.Backspace))&&!Main.activeSelf&&Settings.activeSelf){
            BackFromSettingsPressed();
        }

    }
    public void PlayPressed()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
    public void SettingsPressed()
    {
        Settings.SetActive(true);
        Main.SetActive(false);
    }
    public void BackFromSettingsPressed()
    {
        Settings.SetActive(false);
        Main.SetActive(true);
    }
}
