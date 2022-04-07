using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_cnpt_BaseInteraction : MonoBehaviour
{
    Inpt_cnpt_Input _input;
    Rigidbody2D _rb;
    scr_cnpt_FormBehavior formBehavior;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new Inpt_cnpt_Input();
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();


        _input.Slime.HoldSkill.performed += context => formBehavior._currentForm.holdSkillisActive = true;
        _input.Slime.HoldSkill.canceled += context => formBehavior._currentForm.holdSkillisActive = false;

        _input.Slime.Skill_1.performed += context => formBehavior._currentForm.Skill_1();
        _input.Slime.Skill_2.performed += context => formBehavior._currentForm.Skill_2();

    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

}


