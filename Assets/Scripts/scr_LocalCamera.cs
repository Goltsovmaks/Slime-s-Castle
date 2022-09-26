using UnityEngine;
using Cinemachine;

public class scr_LocalCamera : MonoBehaviour
{
    public string requiredTriggerID;

    private CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        scr_EventSystem.instance.playerEnteredObjectTrigger.AddListener(TurnOnLocalCamera);
        scr_EventSystem.instance.playerLeftObjectTrigger.AddListener(TurnOffLocalCamera);

        virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    private void TurnOnLocalCamera(string id)
    {
        if (id == requiredTriggerID)
        {
            virtualCamera.enabled = true;
        }
    }

    private void TurnOffLocalCamera(string id)
    {
        if (id == requiredTriggerID)
        {
            virtualCamera.enabled = false;
        }
    }

    private void OnDestroy()
    {
        scr_EventSystem.instance.playerEnteredObjectTrigger.RemoveListener(TurnOnLocalCamera);
        scr_EventSystem.instance.playerLeftObjectTrigger.RemoveListener(TurnOffLocalCamera);
    }
}
