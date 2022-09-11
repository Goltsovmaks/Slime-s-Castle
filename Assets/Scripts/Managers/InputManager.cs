using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using System;
using System.Text;
using System.IO;

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
            Debug.Log("Удаляю " + gameObject.name);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Slime").Enable();
        //playerInput.actions.FindActionMap("UI").Enable();
        playerInput.actions.FindActionMap("UI1").Enable();

        //проверка нажатия клавиши
        //var myAction = new InputAction(binding: "/*/<button>");
        //myAction.performed += contex2 => {
        //    Debug.Log($"Button {contex2.control.name /*control.name*/} pressed!");
        //    File.AppendAllText(@"c:\temp\MyTest.txt", $"Button {contex2.control.name /*control.name*/} pressed!" + "\n", Encoding.UTF8);
        //};
        //myAction.Enable();
    }

    

}
