using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Pause;
    public GameObject Dead;


    // // Start is called before the first frame update
    // void Start()
    // {

    // }
    // [SerializeField]
    // // Update is called once per frame  &&!Dead.activeInHierarchy
    void Update()
    {   

        if(Input.GetKeyDown(KeyCode.Escape)&&!Pause.activeInHierarchy){
            Pause.SetActive(true);
            Time.timeScale = 0.01f;
        } else if(Input.GetKeyDown(KeyCode.Escape) && Pause.activeSelf&& !Dead.activeInHierarchy){
            Pause.SetActive(false);
            Time.timeScale = 1f;
        }
 
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
}
