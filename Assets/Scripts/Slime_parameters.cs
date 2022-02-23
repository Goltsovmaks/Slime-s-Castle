using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slime_parameters : MonoBehaviour
{
    public int numberOfMushrooms;

    public float stamina;
    public float staminaJumpUsage;
    public float staminaStuckUsage;
    public float staminaRegeneration;

    private Slider humiditySlider;
    private Slider staminaSlider;

    public delegate void methodOneFloat(float arg);

    //public TextMeshProUGUI numberOfMushroomsText;
    void Awake() {
        
    }


    void Start()
    {
        humiditySlider = GameObject.Find("HumiditySlider").GetComponent<Slider>();
        staminaSlider = GameObject.Find("StaminaSlider").GetComponent<Slider>();
        
        HarmLogic.setHumidityEvent+=updateHumidity;

    }

    private void FixedUpdate()
    {
        
        stamina += staminaRegeneration;
    }

    private void Update()
    {
        if (stamina > 1)
        {
            stamina = 1f;
        }
        if (stamina < 0)
        {
            stamina = 0f;
        }
        
        staminaSlider.value = stamina;

        //numberOfMushroomsText.text = "x" + numberOfMushrooms;
    }
    void OnDestroy() {
        HarmLogic.setHumidityEvent-=updateHumidity;
    }

    public void updateHumidity(float humidity){
        humiditySlider.value = humidity;
    }
   

}
