using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trap : MonoBehaviour
{
    public int damage;
    //public static float damageRate = 1f;
    //public static float nextDamage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("entering");
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(damage);
            //if (Time.time > nextDamage)
            //{
            //    col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
            //    nextDamage = Time.time + damageRate;
            //}
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(damage);
            ////Debug.Log("Time was " + Time.time + "\nnextDamage was "+nextDamage);
            //if (Time.time > nextDamage)
            //{
            //    //Debug.Log("staying");
            //    col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
            //    nextDamage = Time.time + damageRate;
            //}
        }

        

    }

   
}
