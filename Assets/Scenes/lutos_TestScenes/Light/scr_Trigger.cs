using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trigger : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scr_EventSystem.instance.playerTriggerEnter.Invoke(id);
        }
    }
}
