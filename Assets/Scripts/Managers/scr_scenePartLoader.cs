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

    [SerializeField]private bool isLoaded;
    [SerializeField]private bool shouldLoad;
    void Start()
    {
        player = GameObject.Find("Slime").transform;

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
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }
    }

    void UnLoadScene()
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
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
    }

    void TriggerCheck()
    {
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
