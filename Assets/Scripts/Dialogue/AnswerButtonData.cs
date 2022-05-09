using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerButtonData : MonoBehaviour
{
    public int answerID;

    public void AnswerPressed()
    {
        FindObjectOfType<DialogueManager>().RunAnswer(answerID);
    }
}
