using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_Chest : MonoBehaviour
{
    public string chestColour;
    public int numberOfCoins = 5;

    public Sprite openedStateSprite;
    public GameObject coinPrefab;

    public float yForceMin;
    public float yForceMax;
    public float xForceMin;
    public float xForceMax;

    private bool opened = false;

    InputManager input;
    private bool playerCanInteract = false;

    void Start()
    {
        input = InputManager.instance;
        input.playerInput.actions["Interaction"].performed += Interact;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerCanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playerCanInteract = false;
        }
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //if (scr_Player.currentPickedObject != null && playerCanInteract)
        //{
        //    if (scr_Player.currentPickedObject.GetComponent<Key>().keyColour == chestColour)
        //    {
        //        Destroy(scr_Player.currentPickedObject.gameObject);
        //        Open();
        //    }
        //}

        if (playerCanInteract)
        {
            //if (scr_Player.currentPickedObject.GetComponent<Key>().keyColour == chestColour)
            //{
            //    Destroy(scr_Player.currentPickedObject.gameObject);
            //    Open();
            //}
            if (!opened)
            {
                Open();
                opened = true;
            }

        }

    }

    private void OnDestroy()
    {
        input.playerInput.actions["Interaction"].performed -= Interact;
    }

    private void Open()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openedStateSprite;
        //spawn coins

        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform.position, transform.rotation);
            coin.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(xForceMin, xForceMax),
                                                                    Random.Range(yForceMin, yForceMax));
        }
        
    }

}
