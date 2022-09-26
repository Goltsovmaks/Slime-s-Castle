using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance = null;

    public PlayerInput playerInput;

    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Slime").Enable();
        playerInput.actions.FindActionMap("UI").Enable();
        playerInput.actions.FindActionMap("UI1").Enable();
    }

    

}
