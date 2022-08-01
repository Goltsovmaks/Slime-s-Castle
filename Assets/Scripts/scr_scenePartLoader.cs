using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CheckMethod
{   
    Trigger,
    Distance
}

public class scr_scenePartLoader : MonoBehaviour
{


    [SerializeField]private Transform player;
    [SerializeField]private CheckMethod checkMethod;
    [SerializeField]private float loadRange;

    //Scene state
    [SerializeField]private bool isLoaded;
    [SerializeField]private bool shouldLoad;
    void Start()
    {

        player = GameObject.Find("Slime").transform;
        //verify if the scene is already open to avoid opening a scene twice

        if (SceneManager.sceneCount > 0)
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == gameObject.name)
                {
                    isLoaded = true;
                }
            }
        }
    }

    void Update()
    {
        //Checking which method to use
        if (checkMethod == CheckMethod.Distance)
        {
            DistanceCheck();
        }
        else if (checkMethod == CheckMethod.Trigger)
        {
            TriggerCheck();
        }
    }

    void DistanceCheck()
    {
        //Checking if the player is within the range
        if (Vector3.Distance(player.position, transform.position) < loadRange)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }

    void LoadScene()
    {
        if (!isLoaded)
        {
            //Loading the scene, using the gameobject name as it's the same as the name of the scene to load
            // добавить как префаб с текстовым полем
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            //We set it to true to avoid loading the scene twice
            isLoaded = true;
            Debug.Log("загрузка"+gameObject.name);
        }
    }

    void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
            Debug.Log("выгрузка"+gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.CompareTag("Player"))
        {
            shouldLoad = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D colider)
    {
        if (colider.CompareTag("Player"))
        {
            shouldLoad = false;
        }
        Debug.Log("вышел"+gameObject.name);
    }

    void TriggerCheck()
    {
        //shouldLoad is set from the Trigger methods
        if (shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }



}
