using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.UI;

public class scr_chooseFormController : MonoBehaviour
{

    public static scr_chooseFormController instance = null;

    [SerializeField]private GameObject pnl_chooseForm;

    [SerializeField]private GameObject pnl_circleFormPainted;

    [SerializeField]private GameObject pnl_circleNoneFormPainted;


    private enum_forms currentForm;
    public scr_cnpt_FormBehavior FormBehavior;

    private Vector2 startMousePosition;

    private Vector2 refVector = new Vector2(0,1);

    InputManager input;

    private void Awake() {

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
        input = InputManager.instance;
        FormBehavior = scr_cnpt_FormBehavior.instance;

        input.playerInput.actions["ChooseForm"].performed += ChooseForm;
        input.playerInput.actions["ChooseForm"].canceled += ChooseForm;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        // Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // Debug.Log("Позиция мыши:\t"+screenPosition.x+" \t"+screenPosition.y);

        // pnl_chooseForm.transform.position = new Vector2(Mouse.current.position.ReadValue().x,Mouse.current.position.ReadValue().y);
        // Debug.Log("Позиция мыши:\t"+worldPosition.x+" \t"+worldPosition.y);

        Vector2 moveDirection = input.playerInput.actions["Movement"].ReadValue<Vector2>();


        // Debug.Log("angle: " +Vector3.Angle(refVector,screenPosition-startMousePosition));
        
        float angleMouse = Vector3.Angle(refVector,screenPosition-startMousePosition);


        if(angleMouse<=60){
            currentForm = enum_forms.Slime;
            pnl_circleFormPainted.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0, 60);
        }


        if(startMousePosition.x>screenPosition.x &&angleMouse>60){
            currentForm = enum_forms.Spider;
            pnl_circleFormPainted.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0, 180);
        }


        if(startMousePosition.x<screenPosition.x &&angleMouse>60){
            currentForm = enum_forms.Firefly;
            pnl_circleFormPainted.GetComponent<RectTransform>().rotation = Quaternion.Euler(0,0, 300);
        }


        if(Vector2.Distance(startMousePosition,screenPosition)>250f){
            startMousePosition+=(screenPosition-startMousePosition)*0.5f;
        }

        if(Vector2.Distance(startMousePosition,screenPosition)<125f){
            pnl_circleNoneFormPainted.SetActive(true);
            pnl_circleFormPainted.SetActive(false);

        }else{
            pnl_circleNoneFormPainted.SetActive(false);
            pnl_circleFormPainted.SetActive(true);
        }


        // Cursor.visible = false;

    }

    private void ChooseForm(InputAction.CallbackContext context){
        if(pnl_circleNoneFormPainted.activeSelf){
            
        }else{
            FormBehavior.NextForm(currentForm);
        }

       

        pnl_chooseForm.SetActive(!pnl_chooseForm.activeSelf);

        if(pnl_chooseForm.activeSelf){
            Time.timeScale = 0.01f;
        }else{
            Time.timeScale = 1;
        }
    }

    private void OnDestroy()
    {
        InputManager.instance.playerInput.actions["ChooseForm"].performed -= ChooseForm;
        InputManager.instance.playerInput.actions["ChooseForm"].canceled -= ChooseForm;
    }

}
