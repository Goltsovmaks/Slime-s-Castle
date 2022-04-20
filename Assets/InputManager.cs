using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    public PlayerInput playerInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("������ " + gameObject.name);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Slime").Enable();
        playerInput.actions.FindActionMap("UI").Enable();
        playerInput.actions.FindActionMap("UI1").Enable();
    }

}
