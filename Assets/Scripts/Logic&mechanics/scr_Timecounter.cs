using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_TimeCounter : MonoBehaviour
{
    private scr_TimeManager TimeManager;

    private AudioSource soundCounterActive;

    private bool active;

    [SerializeField]private GameObject TopTimecounterWhite;
    [SerializeField]private GameObject TopTimecounterGreen;

    // Start is called before the first frame update
    void Start()
    {
        TimeManager = scr_TimeManager.instance;
        soundCounterActive = GetComponent<AudioSource>();
        active = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Player"))
        {
            if(!active){
                active = true;
                TopTimecounterWhite.SetActive(false);
                TopTimecounterGreen.SetActive(true);
                soundCounterActive.Play();
                TimeManager.SetTimeStartLevel();
            }
            
        }
        
    }
}
