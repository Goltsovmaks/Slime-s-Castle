using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_cnpt_BaseInteraction : MonoBehaviour
{ 
    scr_cnpt_FormBehavior formBehavior;

    InputManager input;

    private void Awake()
    {
        input = InputManager.instance;

        formBehavior = GetComponent<scr_cnpt_FormBehavior>();

        input.playerInput.actions["HoldSkill"].performed += context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        input.playerInput.actions["HoldSkill"].canceled += context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        input.playerInput.actions["Skill_1"].performed += Skill_1;
        input.playerInput.actions["Skill_2"].performed += Skill_2;
    }

    private void Skill_1(InputAction.CallbackContext context)
    {
        formBehavior._currentForm.Skill_1();
    }

    private void Skill_2(InputAction.CallbackContext context)
    {
        formBehavior._currentForm.Skill_2();
    }

    private void OnDestroy()
    {
        input.playerInput.actions["HoldSkill"].performed -= context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        input.playerInput.actions["HoldSkill"].canceled -= context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        input.playerInput.actions["Skill_1"].performed -= Skill_1;
        input.playerInput.actions["Skill_2"].performed -= Skill_2;
    }
}


