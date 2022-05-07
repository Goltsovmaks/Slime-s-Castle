using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerManager : MonoBehaviour
{
    [SerializeField]
    private string currentAction = "ActionIsNotSet";

    [SerializeField]
    private bool keyIsPressed = false;

    [SerializeField]
    private Button selectedButton = null;

    [SerializeField]
    private KeyCode currentKeyPressed;

    public Dictionary<string, KeyCode> controlls = new Dictionary<string, KeyCode>();

    private void Start()
    {
        controlls.Add("Up", KeyCode.UpArrow);
        controlls.Add("Down", KeyCode.DownArrow);
        controlls.Add("Left", KeyCode.LeftArrow);
        controlls.Add("Right", KeyCode.RightArrow);
        controlls.Add("Stuck", KeyCode.LeftShift);
        controlls.Add("Jump", KeyCode.UpArrow);
        controlls.Add("Interaction", KeyCode.E);

        currentAction = "ActionIsNotSet";
    }

    private void Update()
    {
        if(currentAction != "ActionIsNotSet")
        {
            if (!keyIsPressed)
            {
                listenToKeyPressed();
            }
            else
            {
                setKeyToTheAction();
            }
        }
    }

    private void setKeyToTheAction()
    {
        print("previous pair:" + currentAction + "-" + controlls[currentAction]);
        controlls[currentAction] = currentKeyPressed;
        print("current pair:" + currentAction + "-" + controlls[currentAction]);

        setTextOnTheButton(selectedButton, currentKeyPressed);

        keyIsPressed = false;
        currentAction = "ActionIsNotSet";
    }

    private void listenToKeyPressed()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key) && key != KeyCode.Mouse0)
            {
                currentKeyPressed = key;
                keyIsPressed = true;
                break;
            }
        }
    }

    public void setCurrentAction(string action)
    {
        resetCurrentAction();
        currentAction = action;
    }

    public void setSelectedButton(Button button)
    {
        resetSelectedButton();
        selectedButton = button;
    }

    public void resetSelectedButton()
    {
        selectedButton = null;
    }

    public void resetCurrentAction()
    {
        currentAction = "ActionIsNotSet";
    }

    public void setTextOnTheButton(Button button, KeyCode key)
    {
        button.GetComponentInChildren<Text>().text = key.ToString();
    }
}
