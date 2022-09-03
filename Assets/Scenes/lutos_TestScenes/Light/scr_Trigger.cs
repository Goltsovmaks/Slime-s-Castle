using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trigger : MonoBehaviour
{
    public TriggerType type;
    public string id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scr_EventSystem.instance.playerTriggerEnter.Invoke(type,id);
        }
    }
}
public enum TriggerType
{
    dialogTrigger,
    objectTrigger,
    missionTrigger
}
