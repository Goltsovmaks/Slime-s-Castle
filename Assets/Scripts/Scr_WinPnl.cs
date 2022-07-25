using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_WinPnl : MonoBehaviour
{
    InputManager input;
    PlayerInput playerInput;

    private void Awake()
    {
        input = InputManager.instance;

        playerInput = input.GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Slime").Disable();
        playerInput.actions.FindActionMap("UI1").Disable();
        playerInput.actions.FindActionMap("Win").Enable();

        input.playerInput.actions["QuitGame"].performed += context => CloseGame();
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
