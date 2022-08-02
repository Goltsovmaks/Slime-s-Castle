using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr_grate : MonoBehaviour
{
    [SerializeField]bool playerIsClose = false;

    private Transform exit;


    void Start()
    {
        //Зажимает нужную клавишу
        InputManager.instance.playerInput.actions["GrateInteraction"].performed += Interact;
        exit = transform.GetChild(0);
    }

    private void OnDestroy()
    {
        InputManager.instance.playerInput.actions["GrateInteraction"].performed -= Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (playerIsClose)
        {
            //проверка на слайма?
            scr_Player.instance.transform.position = exit.position;
            //move to exit
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
        }

    }
}

