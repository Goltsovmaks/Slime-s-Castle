using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trap : MonoBehaviour
{
    private float timeToNextDamage = 10;
    private static float timeLeft = 0;

    public static float damageRate = 1f;
    public static float nextDamage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("entering");
        if (col.CompareTag("Player"))
        {
            if (Time.time > nextDamage)
            {
                col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
                nextDamage = Time.time + damageRate;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Time was " + Time.time + "\nnextDamage was "+nextDamage);
            if (Time.time > nextDamage)
            {
                Debug.Log("staying");
                col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
                nextDamage = Time.time + damageRate;
            }
        }

        //if (col.CompareTag("Player"))
        //{
        //    if (timeLeft <= 0)
        //    {
        //        col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
        //        timeLeft = timeToNextDamage;
        //    }
        //}

    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
        
    //}
}
