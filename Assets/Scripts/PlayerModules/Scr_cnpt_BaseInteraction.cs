using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_cnpt_BaseInteraction : MonoBehaviour
{ 
    //PlayerInput _input;

    scr_cnpt_FormBehavior formBehavior;

    InputManager input;

    private void Awake()
    {
        input = InputManager.instance;

        //_input = GetComponent<PlayerInput>();
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();

        input.playerInput.actions["HoldSkill"].performed += context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        input.playerInput.actions["HoldSkill"].canceled += context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        input.playerInput.actions["Skill_1"].performed += context => formBehavior._currentForm.Skill_1();
        input.playerInput.actions["Skill_2"].performed += context => formBehavior._currentForm.Skill_2();

    }
}


