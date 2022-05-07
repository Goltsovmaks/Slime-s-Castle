using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarmLogic : MonoBehaviour
{

    [SerializeField]private AudioSource soundCoal;

    [SerializeField][Range(0, 0.02f)]private float humidityRegeneration;

    [SerializeField]private bool isHarm=false;
    [SerializeField]private bool isTreat=true;
    [SerializeField][Range(0, 1f)]private float humidity;

    public static event Slime_parameters.methodOneFloat setHumidityEvent;

    public static event DeadLogic.methodDead DeadEvent;

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setHumidityEvent(humidity);

        if(humidity>1){
            DeadEvent();
            humidity=1;
        }
        if(humidity<0){
            humidity=0;
        }
    }
    private void FixedUpdate() {
        if(isHarm){
            humidity+=humidityRegeneration;
            if(!soundCoal.isPlaying)soundCoal.Play();
        }
        if(isTreat){
            if(humidity>0.5f)humidity-=Mathf.Abs(humidityRegeneration*0.05f);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Harmful")){
            isHarm=true;
            humidity+=humidityRegeneration;
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.CompareTag("Harmful")){
            isHarm=true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.CompareTag("Harmful")){
            isHarm=false;

        }

    }

}
