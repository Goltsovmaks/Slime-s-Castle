using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HUDController : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Pause;
    public GameObject Dead;
    public GameObject PlayerControl;
    public Slider sliderObj;

    PlayerInput _input;

    
    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        // _input.actions["HoldSkill"].performed += context => scr_cnpt_Form_Abstract.holdSkillisActive = true;
        // _input.actions["HoldSkill"].canceled += context => scr_cnpt_Form_Abstract.holdSkillisActive = false;

        // _input.actions["Skill_1"].performed += context => formBehavior._currentForm.Skill_1();
        // _input.actions["Skill_2"].performed += context => formBehavior._currentForm.Skill_2();

    }
    
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
