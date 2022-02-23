using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverLogic : MonoBehaviour
{
    private Animator animlever;
    private AudioSource soundLeverActive;
    [SerializeField]public GameObject[] objectsConnected;

    
    private bool onPlaceLever=false;

    public int indexOfObject;

    void Start()
    {
        soundLeverActive=GetComponent<AudioSource>();
        animlever=GetComponent<Animator>();

        
        for(int i=0;i<objectsConnected.Length;i++){
            if(objectsConnected[i].TryGetComponent(out DoorLogic scriptDoor)){
                if(!scriptDoor.M){
                    scriptDoor.objectsConnected = new GameObject[]{gameObject};
                    scriptDoor.stateConnectedObjects = new bool[]{animlever.GetBool("Active")};
                }
            }else{
                print("На объекте "+objectsConnected[i].name+" нет скрипта DoorLogic");
            }   
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(onPlaceLever&&Input.GetKeyDown(GameObject.Find("ControllerManager").GetComponent<ControllerManager>().controlls["Interaction"]))
        { //; KeyCode.F
            pressAction();
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

    private void pressAction(){
        animlever.SetBool("Active",!animlever.GetBool("Active"));
        soundLeverActive.Play();

        turnObjectsConnected();
        
    }

    private void turnObjectsConnected(){
        if(objectsConnected!=null){
            for(int i=0;i<objectsConnected.Length;i++){
                objectsConnected[i].GetComponent<DoorLogic>().stateConnectedObjects[indexOfObject]=animlever.GetBool("Active");
                objectsConnected[i].GetComponent<DoorLogic>().CheckStateOnDoor();

            }
        }else{
            print(name + "Ни к чему не подключён");
        }

    }
}
