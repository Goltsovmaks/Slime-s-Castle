using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trap : MonoBehaviour
{
    private float timeToNextDamage = 10;
    private static float timeLeft = 0;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            timeLeft = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        timeLeft -= Time.deltaTime;

        if (col.CompareTag("Player"))
        {
            if (timeLeft <= 0)
            {
                col.gameObject.GetComponent<scr_IDamageable>().ApplyDamage(1);
                timeLeft = timeToNextDamage;
            }
        }
        
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
        
    //}
}
