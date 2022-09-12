using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scr_WinPnl : MonoBehaviour
{
    InputManager input;
    PlayerInput playerInput;

    [SerializeField]private Text ComplitedTime;
    scr_TimeManager TimeManager;

    private void Awake()
    {
        input = InputManager.instance;

        playerInput = input.GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Slime").Disable();
        playerInput.actions.FindActionMap("UI1").Disable();
        playerInput.actions.FindActionMap("UI").Disable();
        playerInput.actions.FindActionMap("Win").Enable();

       
        input.playerInput.actions["QuitGame"].performed += context => ReturnToMainMenu();


    }

    private void Start() {
        TimeManager = scr_TimeManager.instance;
        ComplitedTime.text = "Level complited in "+TimeManager.GetTimeCompleteLevel()+" s";

    }

    

    void ReturnToMainMenu()
    {
        playerInput.actions.FindActionMap("Slime").Enable();
        playerInput.actions.FindActionMap("UI1").Enable();
        playerInput.actions.FindActionMap("UI").Enable();
        playerInput.actions.FindActionMap("Win").Disable();

        MenuController.instance.currentMenu = MenuController.instance.pnl_main;
        MenuController.instance.pnl_main.SetActive(true);
        Cursor.visible = true;


        SceneManager.LoadScene("scn_Menu");
        
    }

    private void OnDisable()
    {
        input.playerInput.actions["QuitGame"].performed -= context => ReturnToMainMenu();

    }
}
