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

    void Start()
    {
        showHintController = scr_showHintController.instance;
        showHintController.txt_nameButton.text = nameHintButton;
    }

    private void OnTriggerEnter2D(Collider2D colider) 
    {
        if (colider.CompareTag("Player"))
        {
            showHintController.SetPositionObject(gameObject.transform.position);
            showHintController.UpdateHint();
            showHintController.ShowHint();
        }
        
    }

    private void OnTriggerStay2D(Collider2D colider) 
    {
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
