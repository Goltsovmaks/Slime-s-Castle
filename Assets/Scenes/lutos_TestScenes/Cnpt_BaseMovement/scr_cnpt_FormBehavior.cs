using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_FormBehavior : MonoBehaviour
{
    private List<scr_cnpt_Form_Abstract> _forms;

    public scr_cnpt_Form_Abstract _currentForm;

    Inpt_cnpt_Input _input;

    public enum enum_forms
    {
        Slime,
        Spider,
        Firefly
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Awake()
    {
        _input = new Inpt_cnpt_Input();

        _forms = new List<scr_cnpt_Form_Abstract>()
        {
            //new scr_cnpt_Slime(7f, 0.45f),
            //new scr_cnpt_Spider(6f, 0.45f),
            //new scr_cnpt_Firefly(5f, 0.45f)
            new scr_cnpt_Slime(),
            new scr_cnpt_Spider(),
            new scr_cnpt_Firefly()
        };
        _currentForm = _forms[0];

        _input.Slime.NextForm_Slime.performed += context => NextForm(enum_forms.Slime);
        _input.Slime.NextForm_Spider.performed += context => NextForm(enum_forms.Spider);
        _input.Slime.NextForm_Firefly.performed += context => NextForm(enum_forms.Firefly);
    }

    public void NextForm(enum_forms form)
    {
        switch (form)
        {
            case enum_forms.Slime:
                _currentForm = _forms[0];
                break;
            case enum_forms.Spider:
                _currentForm = _forms[1];
                break;
            case enum_forms.Firefly:
                _currentForm = _forms[2];
                break;
        }
    }
}
