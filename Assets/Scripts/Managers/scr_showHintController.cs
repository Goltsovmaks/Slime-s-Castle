using UnityEngine;

using UnityEngine.UI;

public class scr_showHintController : MonoBehaviour
{
    public static scr_showHintController instance = null;

    [SerializeField] private GameObject pnl_hintButton;
    public Text txt_nameButton;

    private scr_CameraManager CameraManager;

    private Camera camera;

    private Vector3 positionObject;

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

    void Start()
    {
        CameraManager = scr_CameraManager.instance;
        camera = CameraManager.mainCamera;
    }

    public void SetTextHint(string textHint)
    {
        txt_nameButton.text = textHint;
    }

    public void SetPositionObject(Vector3 positionObject)
    {
        this.positionObject = positionObject;
    }

    public void ShowHint()
    {
        pnl_hintButton.SetActive(true);
    }

    public void UpdateHint()
    {
        pnl_hintButton.transform.position = camera.WorldToScreenPoint(positionObject);
        pnl_hintButton.transform.position = new Vector3(pnl_hintButton.transform.position.x,pnl_hintButton.transform.position.y+50,0);
    }

    public void hideHint()
    {
        pnl_hintButton.SetActive(false);
    }
}
