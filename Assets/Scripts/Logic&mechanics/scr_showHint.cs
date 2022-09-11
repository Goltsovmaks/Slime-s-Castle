using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeInteraction
{
    Interaction,
    Skill1,
    Skill2
    
}

public class scr_showHint : MonoBehaviour
{
    scr_showHintController showHintController;

    [SerializeField] private string nameHintButton;

    // [SerializeField] private TypeInteraction typeInteraction;

    // Start is called before the first frame update
    void Start()
    {
        showHintController = scr_showHintController.instance;
        showHintController.txt_nameButton.text = nameHintButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D colider) {
        if (colider.CompareTag("Player"))
        {
            showHintController.SetPositionObject(gameObject.transform.position);
            showHintController.UpdateHint();
            showHintController.ShowHint();
            // Указание типа взаимодействия и в зависимости от этого высталвение название клавиши
        }
        
    }

    private void OnTriggerStay2D(Collider2D colider) {
        if (colider.CompareTag("Player"))
        {
            showHintController.UpdateHint();


        }
        
    }

    private void OnTriggerExit2D(Collider2D colider) {
        if (colider.CompareTag("Player"))
        {
            showHintController.hideHint();

        }
        
    }

}
