using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_cnpt_BaseInteraction : MonoBehaviour
{ 
    PlayerInput _input;

    scr_cnpt_FormBehavior formBehavior;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();

        _input.actions["HoldSkill"].performed += context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        _input.actions["HoldSkill"].canceled += context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        _input.actions["Skill_1"].performed += context => formBehavior._currentForm.Skill_1();
        _input.actions["Skill_2"].performed += context => formBehavior._currentForm.Skill_2();

    }
}


