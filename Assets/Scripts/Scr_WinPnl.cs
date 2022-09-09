using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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
        playerInput.actions.FindActionMap("Win").Enable();

        input.playerInput.actions["QuitGame"].performed += context => CloseGame();


    }

    private void Start() {
        TimeManager = scr_TimeManager.instance;
        ComplitedTime.text += "Level complited in "+TimeManager.GetTimeCompleteLevel()+" s";

    }

    void CloseGame()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        input.playerInput.actions["QuitGame"].performed -= context => CloseGame();
    }
}
