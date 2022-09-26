using System.Collections.Generic;
using UnityEngine;

public enum enum_forms
{
    Slime,
    Spider,
    Firefly
}


public class scr_cnpt_FormBehavior : MonoBehaviour
{
    public static scr_cnpt_FormBehavior instance = null;

    private Dictionary<enum_forms, scr_cnpt_Form_Abstract> enumToForm;

    public scr_cnpt_Form_Abstract _currentForm;

    public static bool canChangeForm = true;

    InputManager input;

    public delegate void PressEvent();
    public static event PressEvent FormIsChanged;

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

        input = InputManager.Instance;

        enumToForm = new Dictionary<enum_forms, scr_cnpt_Form_Abstract>()
        {
            {enum_forms.Slime, new scr_cnpt_Slime(this)},
            {enum_forms.Spider, new scr_cnpt_Spider(this)},
            {enum_forms.Firefly, new scr_cnpt_Firefly(this)}
        };

        _currentForm = enumToForm[enum_forms.Slime];

    }

    public void NextForm(enum_forms form)
    {
        if (canChangeForm)
        {
            if (enumToForm[form].GetType() != _currentForm.GetType())
            {
                _currentForm = enumToForm[form];
                FormIsChanged();
            }
        }
        
    }
}
