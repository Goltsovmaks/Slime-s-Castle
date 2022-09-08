using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class scr_CameraManager : MonoBehaviour
{
    public static scr_CameraManager instance = null;

    private bool mainCameraIsActive = true;

    public Animator animator;

    public GameObject mainVcam;
    public GameObject pipeCrawlingVcam;
    public Camera mainCamera;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        scr_EventSystem.instance.playerAwake.AddListener(SetFollowAtPlayer);

    }

    public void SwitchCameraState()
    {
        //���������� ���� ������ �����
        if (mainCameraIsActive)
        {
            animator.Play("PipeCrawling");
        }
        else
        {
            animator.Play("Main");
        }
        mainCameraIsActive = !mainCameraIsActive;
    }

    public void SetFollowAtPlayer(GameObject player)
    {
        mainVcam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        pipeCrawlingVcam.GetComponent<CinemachineVirtualCamera>().Follow = player.transform;
        
    }

}
