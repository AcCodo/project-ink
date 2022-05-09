using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Dialogue dialogueStructure;
    private Dialogue.Message topMessage;
    private string npcName;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        /*
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        npcName = dialogue.npcName;

        NextSentence();
        */
        dialogue.ParseJSONtoDialogueStructure();
        dialogueStructure = dialogue;
        RunSentence(0);
    }

    public void RunSentence(int id)
    {
        Dialogue.Message sentence = dialogueStructure.SearchMessage(id);
        topMessage = sentence;
        if (sentence.answers != null)
        {
            //this sentence have answers.
            //TODO: execute sentence with answers here
            //return;
        }
        
        FindObjectOfType<DialogueUI>().UpdateFields(sentence.text, sentence.NPC);
    }

    public void NextSentence()
    {
        /*
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string message = sentences.Dequeue();
        Debug.Log(npcName + ": " + message);

        FindObjectOfType<DialogueUI>().UpdateFields(message, npcName);
        */

        RunSentence(topMessage.NextId);

    }

    public void EndDialogue()
    {
        Debug.Log("Dialogue ended.");
        FindObjectOfType<DialogueUI>().UpdateFields("", "");
    }
}
