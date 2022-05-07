using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Slime : scr_cnpt_Form_Abstract
{

    public scr_cnpt_Slime()
    {
        sprite = Resources.Load<Sprite>("Slime");
    }

    //public override void Jump(Rigidbody2D rb)
    //{

    //    Debug.Log("Я прыгающий слизень");
    //}

}
