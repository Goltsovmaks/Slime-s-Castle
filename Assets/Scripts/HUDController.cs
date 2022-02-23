using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Pause;
    public GameObject Dead;
    public GameObject PlayerControl;
    public Slider sliderObj;


    // // Start is called before the first frame update
    void Start()
    {
        sliderObj.value=PlayerPrefs.GetFloat("BG_MUSIC");
        // Slider sliderObj = GameObject.FindWithTag("BG_MUSIC_VOLUME_SLIDER").GetComponent<Slider>();
        // Text textObj = GameObject.FindWithTag("BG_MUSIC_VOLUME_TEXT").GetComponent<Text>();
        // sliderObj
        // textObj.text = Mathf.Round(f: sliderObj.value * 100) + "%";

    }
    // [SerializeField]
    // // Update is called once per frame  &&!Dead.activeInHierarchy
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape)){

            // PlayerPrefs
            if(!Pause.activeInHierarchy){
                Pause.SetActive(true);
                PlayerControl.SetActive(false);
                Time.timeScale = 0.01f;
            }else{
                Pause.SetActive(false);
                PlayerControl.SetActive(false);
                Time.timeScale = 1f;
            }

            
            if(PlayerControl.activeInHierarchy){
                Pause.SetActive(true);
                PlayerControl.SetActive(false);
            }

        }

        // if(Input.GetKeyDown(KeyCode.Escape)&&!Pause.activeInHierarchy){
        //     Pause.SetActive(true);
        //         PlayerControl.SetActive(false);
        //         Time.timeScale = 0f;
        // } else if(Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf&& !Dead.activeInHierarchy){
        //     Pause.SetActive(false);
        //     Time.timeScale = 1f;
        // }
 
    }
    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void ContinuePressed()
    {
        Pause.SetActive(false);
        Time.timeScale = 1f;
        // SceneManager.LoadScene("menu");
    }

    public void ControlsPressed()
    {
        PlayerControl.SetActive(true);
        Pause.SetActive(false);
    }

}
