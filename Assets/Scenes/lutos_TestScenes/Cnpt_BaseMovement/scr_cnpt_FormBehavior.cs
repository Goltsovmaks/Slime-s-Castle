using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr_cnpt_FormBehavior : MonoBehaviour
{

    private Dictionary<enum_forms, scr_cnpt_Form_Abstract> enumToForm;

    public scr_cnpt_Form_Abstract _currentForm;

    //Inpt_cnpt_Input _input;
    //PlayerInput _input;

    InputManager input;

    public delegate void PressEvent();
    public static event PressEvent FormIsChanged;

    public enum enum_forms
    {
        Slime,
        Spider,
        Firefly
    }

    //private void OnEnable()
    //{
    //    _input.Enable();
    //}

    //private void OnDisable()
    //{
    //    _input.Disable();
    //}

    private void Awake()
    {
        //_input = new Inpt_cnpt_Input();
        //_input = GetComponent<PlayerInput>();

        input = InputManager.instance;

        enumToForm = new Dictionary<enum_forms, scr_cnpt_Form_Abstract>()
        {
            {enum_forms.Slime, new scr_cnpt_Slime()},
            {enum_forms.Spider, new scr_cnpt_Spider()},
            {enum_forms.Firefly, new scr_cnpt_Firefly()}
        };

        _currentForm = enumToForm[enum_forms.Slime];

        //_input.Slime.NextForm_Slime.performed += context => NextForm(enum_forms.Slime);
        //_input.Slime.NextForm_Spider.performed += context => NextForm(enum_forms.Spider);
        //_input.Slime.NextForm_Firefly.performed += context => NextForm(enum_forms.Firefly);

        input.playerInput.actions["NextForm_Slime"].performed += context => NextForm(enum_forms.Slime);
        input.playerInput.actions["NextForm_Spider"].performed += context => NextForm(enum_forms.Spider);
        input.playerInput.actions["NextForm_Firefly"].performed += context => NextForm(enum_forms.Firefly);
    }

    public void NextForm(enum_forms form)
    {
        _currentForm = enumToForm[form];
        FormIsChanged();
    }
}
