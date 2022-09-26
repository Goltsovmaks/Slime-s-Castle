using UnityEngine;
using UnityEngine.InputSystem;

public class scr_chooseFormController : MonoBehaviour
{

    public static scr_chooseFormController instance = null;

    [SerializeField]private GameObject pnl_chooseForm;

    [SerializeField]private GameObject pnl_circleFormPainted;

    [SerializeField]private GameObject pnl_circleNoneFormPainted;

    [SerializeField][Range(0,  500f)]private float radiusOutForms;

    [SerializeField][Range(0, 500f)]private float radiusNoneForm;


    private enum_forms currentForm;

    private Vector2 startMousePosition;

    private Vector2 refVector = new Vector2(0,1);

    InputManager input;

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
    }
    
    void Start()
    {
        input = InputManager.Instance;

        input.playerInput.actions["ChooseForm"].performed += ChooseForm;
        input.playerInput.actions["ChooseForm"].canceled += ChooseForm;
    }

    void Update()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();

        Vector2 moveDirection = input.playerInput.actions["Movement"].ReadValue<Vector2>();
        
        float angleMouse = Vector3.Angle(refVector,screenPosition-startMousePosition);


        if(angleMouse<=60)
        {
            currentForm = enum_forms.Slime;
            pnl_circleFormPainted.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0, 60);
        }

        if(startMousePosition.x>screenPosition.x &&angleMouse>60)
        {
            currentForm = enum_forms.Spider;
            pnl_circleFormPainted.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0, 180);
        }

        if(startMousePosition.x<screenPosition.x &&angleMouse>60)
        {
            currentForm = enum_forms.Firefly;
            pnl_circleFormPainted.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0, 300);
        }

        if(Vector2.Distance(startMousePosition,screenPosition)>radiusOutForms)
        {
            startMousePosition+=(screenPosition-startMousePosition)*0.5f;
        }

        if(Vector2.Distance(startMousePosition,screenPosition)<radiusNoneForm)
        {
            pnl_circleNoneFormPainted.SetActive(true);
            pnl_circleFormPainted.SetActive(false);

        }
        else
        {
            pnl_circleNoneFormPainted.SetActive(false);
            pnl_circleFormPainted.SetActive(true);
        }

    }

    private void ChooseForm(InputAction.CallbackContext context)
    {
        if(pnl_circleNoneFormPainted.activeSelf)
        {
            
        }
        else
        {
            scr_cnpt_FormBehavior.instance.NextForm(currentForm);
        }

        pnl_chooseForm.SetActive(!pnl_chooseForm.activeSelf);

        if(pnl_chooseForm.activeSelf)
        {
            Time.timeScale = 0.01f;
            Cursor.visible = false;
        }
        else
        {
            Time.timeScale = 1;
            
        }
    }

    private void OnDestroy()
    {
        InputManager.Instance.playerInput.actions["ChooseForm"].performed -= ChooseForm;
        InputManager.Instance.playerInput.actions["ChooseForm"].canceled -= ChooseForm;
    }

}
