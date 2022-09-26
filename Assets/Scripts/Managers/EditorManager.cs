using UnityEngine;

public class EditorManager : MonoBehaviour
{
    public bool noMenuLevelStart;

    public static EditorManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
