using UnityEngine;
using UnityEngine.InputSystem;

public class Lock : MonoBehaviour
{
    public string lockColour;
    InputManager input;

    private bool playerCanInteract = false;

    private AudioSource audioSource;

    void Start()
    {
        input = InputManager.Instance;
        input.playerInput.actions["Interaction"].performed += Interact;

        audioSource = gameObject.GetComponent<AudioSource>();
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
        if (scr_Player.currentPickedObject != null && playerCanInteract)
        {
            if (scr_Player.currentPickedObject.GetComponent<Key>().keyColour == lockColour)
            {
                audioSource.Play();
                gameObject.SetActive(false);
                Destroy(scr_Player.currentPickedObject.gameObject);
            }
        }
        
    }

    private void OnDestroy()
    {
        input.playerInput.actions["Interaction"].performed -= Interact;
    }
}
