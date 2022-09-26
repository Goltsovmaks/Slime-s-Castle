using System.Collections;
using UnityEngine;

public class pockPlateLogic : MonoBehaviour
{
    
    private Animator animPockPlate;
    private AudioSource soundPockplateActive;
    [SerializeField]private int sumObjectsOnPockplate=0; 
    [Header("1:M")]
    [SerializeField]private bool M=false;
    [SerializeField]public GameObject[] objectsConnected;
    [SerializeField][Range(0, 60f)]public float[] timesActive;


    [SerializeField] private float rotationDirection;

    public int indexOfObject;

    private Coroutine[] closeThroughCoroutines;

    IEnumerator closeThrough(float time, int index)
    {
        yield return new WaitForSeconds(time);

        if (objectsConnected[index].TryGetComponent(out scr_RotateModule rotateModule))
        {
            rotateModule.isRotating = animPockPlate.GetBool("Active");
        }
        else
        {
            objectsConnected[index].GetComponent<DoorLogic>().stateConnectedObjects[indexOfObject] = 
                animPockPlate.GetBool("Active");
            objectsConnected[index].GetComponent<DoorLogic>().CheckStateOnDoor();
        }
        closeThroughCoroutines[index] = null;
    }

    void Start()
    {
        soundPockplateActive=GetComponent<AudioSource>();
        animPockPlate=GetComponent<Animator>();

        if(M)
        {
            closeThroughCoroutines = new Coroutine[objectsConnected.Length];
            if(timesActive.Length<objectsConnected.Length)
            {
                Debug.Log("Количество объектов не совпадает, массив timesActive " +
                    "будет равным размеру массива objectsConnected с нулевыми значениями");
                timesActive = new float[objectsConnected.Length];
            }
            for(int i=0;i<objectsConnected.Length;i++)
            {
                if(objectsConnected[i].TryGetComponent(out DoorLogic scriptDoor))
                {
                    if(!scriptDoor.M)
                    {
                        scriptDoor.objectsConnected = new GameObject[]{gameObject};
                        scriptDoor.stateConnectedObjects = new bool[]{animPockPlate.GetBool("Active")};
                    }
                    else
                    {
                        Debug.Log("Ошибка! И на текущем и на привязанном объекте установлено " +
                            "соотношения 1:М!");
                    }
                }
                else
                {
                    print("На объекте "+objectsConnected[i].name+" нет скрипта DoorLogic");

                }   
            }

        }
        else
        {
            closeThroughCoroutines=new Coroutine[1];
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")||collider.CompareTag("MovableCube"))
        {
            sumObjectsOnPockplate += 1;
            pressAction();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")||collider.CompareTag("MovableCube"))
        {
            sumObjectsOnPockplate -= 1;
            if(sumObjectsOnPockplate == 0){
                afterPressAction();
            }
        }
    }


    private void pressAction()
    {
        animPockPlate.SetBool("Active",true);
        soundPockplateActive.Play();

        turnObjectsConnectedPressAction();

    }

    private void afterPressAction()
    {
        animPockPlate.SetBool("Active",false);

        turnObjectsConnectedAfterPressAction();
        
    }

    private void turnObjectsConnectedPressAction()
    {
        if(objectsConnected!=null)
        {
            for(int i=0;i<objectsConnected.Length;i++)
            {
                if(closeThroughCoroutines[i]!=null)
                {
                    StopCoroutine(closeThroughCoroutines[i]);
                }
                if (objectsConnected[i].TryGetComponent(out scr_RotateModule rotateModule))
                {
                    rotateModule.isRotating = animPockPlate.GetBool("Active");
                    rotateModule.rotationDirection = rotationDirection;
                }
                else
                {
                    objectsConnected[i].GetComponent<DoorLogic>().stateConnectedObjects[indexOfObject] = animPockPlate.GetBool("Active");
                    objectsConnected[i].GetComponent<DoorLogic>().CheckStateOnDoor();
                }
            }
        }
        else
        {
            print(name + "Ни к чему не подключён");
        }
    }

    private void turnObjectsConnectedAfterPressAction()
    {
        if(objectsConnected!=null)
        {
            for(int i=0;i<objectsConnected.Length;i++)
            {
                if(closeThroughCoroutines[i]!=null)
                {
                    StopCoroutine(closeThroughCoroutines[i]);
                }
                closeThroughCoroutines[i]=StartCoroutine(closeThrough(timesActive[i],i));

            }
        }
        else
        {
            print(name + "Ни к чему не подключён");
        }
        
    }

}
