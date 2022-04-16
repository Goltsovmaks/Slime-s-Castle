using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_cnpt_BaseInteraction : MonoBehaviour
{
    //Inpt_cnpt_Input _input;
    PlayerInput _input;


    Rigidbody2D _rb;
    scr_cnpt_FormBehavior formBehavior;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_input = new Inpt_cnpt_Input();
        _input = GetComponent<PlayerInput>();
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();


        //_input.Slime.HoldSkill.performed += context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        //_input.Slime.HoldSkill.canceled += context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        //_input.Slime.Skill_1.performed += context => formBehavior._currentForm.Skill_1();
        //_input.Slime.Skill_2.performed += context => formBehavior._currentForm.Skill_2();

        _input.actions["HoldSkill"].performed += context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        _input.actions["HoldSkill"].canceled += context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        _input.actions["Skill_1"].performed += context => formBehavior._currentForm.Skill_1();
        _input.actions["Skill_2"].performed += context => formBehavior._currentForm.Skill_2();

    }

    //private void OnEnable()
    //{
    //    _input.Enable();
    //}

    //private void OnDisable()
    //{
    //    _input.Disable();
    //}

}


