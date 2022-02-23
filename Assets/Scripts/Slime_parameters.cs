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

    public float humidity;

    public Slider humiditySlider;
    public Slider staminaSlider;

    //public TextMeshProUGUI numberOfMushroomsText;

    private void Start()
    {
        humiditySlider = GameObject.Find("HumiditySlider").GetComponent<Slider>();
        staminaSlider = GameObject.Find("StaminaSlider").GetComponent<Slider>();
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
        humiditySlider.value = humidity;
        staminaSlider.value = stamina;

        //numberOfMushroomsText.text = "x" + numberOfMushrooms;
    }
   

}
