using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

//namespace UnityEngine.Experimental.Rendering.Universal;

public class scr_Lamp : MonoBehaviour
{
    // Start is called before the first frame update
    Light2D light;

    public  float maxShineTime = 3f;
    private float shineTimeLeft;

    private bool isRegenerating = false;

    private void Start()
    {
        light = gameObject.GetComponent<Light2D>();
    }

    private void Update()
    {
        if (isRegenerating)
        {
            //Разный реген от разных форм
            if (shineTimeLeft >= maxShineTime)
            {
                shineTimeLeft = maxShineTime;
            }
            else
            {
                shineTimeLeft += Time.deltaTime * 3;
            }
        }
        else
        {
            if (shineTimeLeft <= 0)
            {
                shineTimeLeft = 0;
            }
            else
            {
                shineTimeLeft -= Time.deltaTime;
            }
        }
        light.intensity = shineTimeLeft / maxShineTime;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRegenerating = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isRegenerating = false;
        }
    }
}
