using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Trigger : MonoBehaviour
{
    public TriggerType type;
    public bool destroyAfterCollision;
    public bool destroyAfterLeaving;

    public bool destroyAfterTime;
    public float time;

    [Header("if dialogType")]
    public string dialogName;
    [Header("if objectType")]
    public string objectName;
    [Header("if missionType")]
    public string missionName;
    public missionStatus missionStatus;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case TriggerType.dialogTrigger:
                    scr_EventSystem.instance.playerEnteredDialogTrigger.Invoke(dialogName);
                    break;
                case TriggerType.objectTrigger:
                    scr_EventSystem.instance.playerEnteredObjectTrigger.Invoke(objectName);
                    break;
                case TriggerType.missionTrigger:
                    scr_EventSystem.instance.playerEnteredMissionTrigger.Invoke(missionName,missionStatus);
                    break;
            }

            if (destroyAfterTime)
            {
                StartCoroutine(DestroyAfterTime());
            }
            
            if (destroyAfterCollision)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case TriggerType.dialogTrigger:
                    scr_EventSystem.instance.playerLeftDialogTrigger.Invoke(dialogName);
                    break;
                case TriggerType.objectTrigger:
                    scr_EventSystem.instance.playerLeftObjectTrigger.Invoke(objectName);
                    break;
                case TriggerType.missionTrigger:
                    scr_EventSystem.instance.playerLeftMissionTrigger.Invoke(missionName, missionStatus);
                    break;
            }

            if (destroyAfterLeaving)
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
