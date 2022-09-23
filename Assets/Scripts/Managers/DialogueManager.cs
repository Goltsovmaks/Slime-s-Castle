using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.IO;


public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    [SerializeField] private GameObject pnl_communication;
    [SerializeField] private GameObject pnl_dialogue;

    [SerializeField] private Text txt_nameSpeaker;
    [SerializeField] private Text txt_phrase;

    [SerializeField][Range(0, 1f)] private float timeFreezeContinue;

    private Dialogues dialogues = new Dialogues();
    [SerializeField]private Dialogue currentDialogue = new Dialogue();
    private int phraseCounter = 0;
    private bool canButtonContinuePressed=true;

    scr_SaveController SaveController;
    InputManager input;

    IEnumerator freezeContinue(float time){
        canButtonContinuePressed = false;
        yield return new WaitForSeconds(time);
        canButtonContinuePressed = true;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;

        input.playerInput.actions["ContinueDialogue"].performed += ContinuePresseed;

        SaveController = scr_SaveController.instance;
        scr_EventSystem.instance.playerEnteredDialogTrigger.AddListener(StartTriggerDialog);

    }


    private void StartTriggerDialog(string dialogName)
    {
        StartDialogue(dialogName);
    }


    public void ContinueDialogue(){
        
        if(currentDialogue.phraseList.Count-1>phraseCounter){
            phraseCounter++;
            txt_phrase.text = currentDialogue.phraseList[phraseCounter].phrase;
            txt_nameSpeaker.text = currentDialogue.phraseList[phraseCounter].nameSpeaker;
            
        }else{
            FinishDialogue();
        }
        
    }

    public void ContinuePresseed(InputAction.CallbackContext context){
        if(!canButtonContinuePressed){
            return;
        }else{
            StartCoroutine(freezeContinue(timeFreezeContinue));
            ContinueDialogue();
        }
            

    }

    public void StartDialogue(string nameDialogue){
        currentDialogue = GetDialogue(nameDialogue);
        phraseCounter=0;
        // активация окна
        pnl_dialogue.gameObject.SetActive(true);

        InputManager.instance.playerInput.actions.FindActionMap("Slime").Disable();


        // цвет текста менять??(игрок - зелёный, гриб - синий)
        txt_phrase.text = currentDialogue.phraseList[phraseCounter].phrase;
        txt_nameSpeaker.text = currentDialogue.phraseList[phraseCounter].nameSpeaker;


    }

    public void FinishDialogue(){
        currentDialogue = new Dialogue();
        // дизактивация окна
        pnl_dialogue.gameObject.SetActive(false);
        InputManager.instance.playerInput.actions.FindActionMap("Slime").Enable();

        txt_phrase.text = "";
        txt_nameSpeaker.text = "";

        // Должны рассказать о том, что диалог закончился

    }

    public bool ExistsDialogue(string dialogue){
        string path = Application.streamingAssetsPath + "/Dialogues/"+dialogue+".json";
        return File.Exists(path);
    }

    public Dialogues GetDialogues(){
        if(ExistsDialogue("allDialogues")){
            string path = Application.streamingAssetsPath + "/Dialogues/allDialogues.json";
            Dialogues dialogues = JsonUtility.FromJson<Dialogues>(File.ReadAllText(path));
            return dialogues;
        }else{
            return new Dialogues();
        }
 
    }

    public Dialogue GetDialogue(string nameDialogue){
        if(ExistsDialogue(nameDialogue)){
            string path = Application.streamingAssetsPath + "/Dialogues/"+nameDialogue+".json";
            Dialogue dialogue = JsonUtility.FromJson<Dialogue>(File.ReadAllText(path));
            return dialogue;
        }else{
            Debug.Log("Файла диалога с таким именем не существует");
            return new Dialogue();
        }
 
    }

    private void OnDestroy() 
    {
        InputManager.instance.playerInput.actions["ContinueDialogue"].performed -= ContinuePresseed;
        
        scr_EventSystem.instance.playerEnteredDialogTrigger.RemoveListener(StartTriggerDialog);
    }

    public void SetupDialogueFile(string nameDialogue){
        if(ExistsDialogue(nameDialogue)){
            Debug.Log(nameDialogue+" Файл диалога с таким именем уже существует");            
        }else{
            string data = JsonUtility.ToJson(new Dialogue());
            string path = Application.streamingAssetsPath + "/Dialogues/"+nameDialogue+".json";
            System.IO.File.WriteAllText(path, data);
            Debug.Log(nameDialogue+" Файл диалога создан");            
        }

    }


// На будущее - собирать все диалоги
    // public void SetupDialogueInDialoguesFile(){
    //     if(ExistsDialogue("allDialogues")){
    //         Debug.Log("allDialogues Файл диалога с таким именем уже существует");            
    //     }else{
            // Dialogues dialogues = new Dialogues();
            // // dialogues.allDialogues.Add();
            // string data = JsonUtility.ToJson(new Dialogues());
            // string path = Application.dataPath+"/Dialogues/"+nameDialogue+".json";
            // System.IO.File.WriteAllText(path, data);
            // Debug.Log("Файл диалога создан");            
    //     }

    // }


}

[System.Serializable]
public class Phrase{

    public string nameSpeaker;
    [TextArea(3, 10)]
    public string phrase;

    public Phrase(){
        nameSpeaker="";
        phrase="";
    }

}

[System.Serializable]
public class Dialogue{

    public string language;
    public string nameDialogue;
    public List<Phrase> phraseList;


    public Dialogue(){
        phraseList = new List<Phrase>(){new Phrase()};
    }

}

[System.Serializable]
public class Dialogues{

    public List<Dialogue> allDialogues;

    public Dialogues(){
        allDialogues = new List<Dialogue>();
    }

}
