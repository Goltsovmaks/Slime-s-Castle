using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraManager : MonoBehaviour
{
    public static scr_CameraManager instance = null;

    private bool mainCameraIsActive = true;

    public Animator animator;

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

    }

    public void SwitchCameraState()
    {
        //переписать если больше камер
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

}
