using UnityEngine;
using UnityEngine.InputSystem;

public class leverLogic : MonoBehaviour
{
    InputManager input;

    private Animator animlever;
    private AudioSource soundLeverActive;
    [SerializeField]public GameObject[] objectsConnected;

    
    private bool onPlaceLever=false;

    public int indexOfObject;


    void Start()
    {
        input = InputManager.Instance;
        input.playerInput.actions["Interaction"].performed += pressAction;
        soundLeverActive =GetComponent<AudioSource>();
        animlever=GetComponent<Animator>();

        
        for(int i=0;i<objectsConnected.Length;i++)
        {
            if(objectsConnected[i].TryGetComponent(out DoorLogic scriptDoor))
            {
                if(!scriptDoor.M)
                {
                    scriptDoor.objectsConnected = new GameObject[]{gameObject};
                    scriptDoor.stateConnectedObjects = new bool[]{animlever.GetBool("Active")};
                }
            }
            else
            {
                print("На объекте "+objectsConnected[i].name+" нет скрипта DoorLogic");
            }   
        }
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            onPlaceLever=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
            onPlaceLever=false;
        }
    }

    private void pressAction(InputAction.CallbackContext context)
    {
        if (onPlaceLever)
        {
            animlever.SetBool("Active", !animlever.GetBool("Active"));
            soundLeverActive.Play();

            turnObjectsConnected();
        }
    }

    private void turnObjectsConnected()
    {
        if(objectsConnected!=null)
        {
            for(int i=0;i<objectsConnected.Length;i++)
            {
                objectsConnected[i].GetComponent<DoorLogic>().stateConnectedObjects[indexOfObject] = 
                    animlever.GetBool("Active");
                objectsConnected[i].GetComponent<DoorLogic>().CheckStateOnDoor();

            }
        }
        else
        {
            print(name + "Ни к чему не подключён");
        }

    }

    private void OnDestroy()
    {
        input.playerInput.actions["Interaction"].performed -= pressAction;
    }
}
