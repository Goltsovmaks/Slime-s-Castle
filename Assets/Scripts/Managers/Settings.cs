using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool isFullScreen = true;
   public void FullScreenToggle(){
       isFullScreen = !isFullScreen;
       Screen.fullScreen= isFullScreen;
   }
}
