using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_laserReceiver : MonoBehaviour
{
    private float laserReceivementTime = -1f;
    [SerializeField] private float timeRate = 0.1f;
    [SerializeField] private bool isOn;

    [SerializeField] private Material requiredLaserMaterial;

    [SerializeField] public GameObject[] objectsConnected;



    //what is that?
    public int indexOfObject;

    //SpriteRenderer spriteRenderer;
    Animator animator;

    private void Start()
    {
        for (int i = 0; i < objectsConnected.Length; i++)
        {
            if (objectsConnected[i].TryGetComponent(out DoorLogic scriptDoor))
            {
                if (!scriptDoor.M)
                {
                    scriptDoor.objectsConnected = new GameObject[] { gameObject };
                    scriptDoor.stateConnectedObjects = new bool[] { isOn };
                }
            }
            else
            {
                print("На объекте " + objectsConnected[i].name + " нет скрипта DoorLogic");
            }
        }
        //spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //timeLeftSinceLastLaserReceivement -= Time.deltaTime;
        if (laserReceivementTime + timeRate <= Time.time)
        {
            //off
            if (isOn)
            {
                ChangeState();
            }
        }
        else
        {
            //on
            if (!isOn)
            {
                ChangeState();
            }
        }
    }

    public void Enable(Material laserMaterial)
    {
        if (laserMaterial == requiredLaserMaterial)
        {
            laserReceivementTime = Time.time;
        }
    }

    public void ChangeState()
    {
        isOn = !isOn;
        turnObjectsConnected();
        if (isOn)
        {
            animator.SetBool("isOn",true);
        }
        else
        {
            animator.SetBool("isOn", false);
        }
        
    }

    private void turnObjectsConnected()
    {
        if (objectsConnected != null)
        {
            for (int i = 0; i < objectsConnected.Length; i++)
            {
                objectsConnected[i].GetComponent<DoorLogic>().stateConnectedObjects[indexOfObject] = isOn;
                objectsConnected[i].GetComponent<DoorLogic>().CheckStateOnDoor();

            }
        }
        else
        {
            print(name + "Ни к чему не подключён");
        }

    }
}
