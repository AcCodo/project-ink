using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogueStructure;
    private Dialogue.Message topMessage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogue.ParseJSONtoDialogueStructure();
        dialogueStructure = dialogue;
        RunSentence(0);
    }

    public void RunSentence(int id)
    {
        Dialogue.Message sentence = dialogueStructure.SearchMessage(id);
        topMessage = sentence;
        string[] buttonsText = new string[0];
        if (sentence.answers != null)
        {
            //this sentence have answers.
            //TODO: execute sentence with answers here
            //return;
            buttonsText = new string[sentence.answers.Count];
            for (int i = 0; i < buttonsText.Length; i++) {
                buttonsText[i] = sentence.answers[i].text;
            }
            
        }
        FindObjectOfType<DialogueUI>().UpdateButtons(buttonsText);
        FindObjectOfType<DialogueUI>().UpdateFields(sentence.text, sentence.NPC);
    }

    public void NextSentence()
    {
        if (topMessage.NextId == 0 && topMessage.answers == null)
        {
            EndDialogue();
        }
        RunSentence(topMessage.NextId);
    }

    public void EndDialogue()
    {
        Debug.Log("Dialogue ended.");
        FindObjectOfType<DialogueUI>().UpdateFields("", "");
    }

    public void RunAnswer(int answerId)
    {
        Debug.Log(answerId);
        Dialogue.Message.Answer answer = topMessage.SearchAnswer(answerId);
        RunSentence(answer.NextId);
    }
}
