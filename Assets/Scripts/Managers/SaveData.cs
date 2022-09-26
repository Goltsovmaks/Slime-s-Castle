using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Phrase phrase;
    public Dialogue dialogue;
    Dialogues dialogues;


    public void SaveDataIntoJson()
    {

    }

    public void LoadDataFromJson()
    {

    }

    public void DO()
    {
        phrase = new Phrase();

        dialogues = new Dialogues();

        dialogues.allDialogues.Add(dialogue);
        dialogues.allDialogues.Add(new Dialogue());

        string Data = JsonUtility.ToJson(dialogues);
        System.IO.File.WriteAllText(Application.dataPath+"/Dialogues/allDialogues.json",Data);

    }

}



