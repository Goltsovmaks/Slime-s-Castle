using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trigger : MonoBehaviour
{
    public TriggerType type;
    public string id;

    public bool destroyAfterCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scr_EventSystem.instance.playerTriggerEnter.Invoke(type,id);
            if (destroyAfterCollision)
            {
                Destroy(gameObject);
            }
        }
    }
}
public enum TriggerType
{
    dialogTrigger,
    objectTrigger,
    missionTrigger
}
