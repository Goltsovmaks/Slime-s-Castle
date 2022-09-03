using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr_pipeGrate : scr_grate_abstract
{
    private scr_pipeGrate()
    {
        slimeSlipAnimationName = "pipeGrateSlipAnimation";
    }

    protected override void Interact(InputAction.CallbackContext context)
    {
        if (playerIsClose && scr_Player.instance.GetComponent<scr_cnpt_FormBehavior>()._currentForm.GetType().ToString() == "scr_cnpt_Slime")
        {
            InputManager.instance.playerInput.actions.FindActionMap("Slime").Disable();
            scr_Player.instance.GetComponent<Animator>().Play(slimeSlipAnimationName);

            scr_CameraManager.instance.SwitchCameraState();
            scr_cnpt_Slime.isPipeCrawling = !scr_cnpt_Slime.isPipeCrawling;
            scr_cnpt_FormBehavior.canChangeForm = !scr_cnpt_FormBehavior.canChangeForm;
            //scr_Player.instance.GetComponent<scr_cnpt_Slime>().isPipeCrawling = !scr_Player.instance.GetComponent<scr_cnpt_Slime>().isPipeCrawling;
            //scr_Player.instance.GetComponent<scr_cnpt_FormBehavior>().canChangeForm = !scr_Player.instance.GetComponent<scr_cnpt_FormBehavior>().canChangeForm;


            StartCoroutine(Teleport());
        }
    }

}
