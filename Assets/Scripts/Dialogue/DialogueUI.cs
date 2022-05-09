using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI npcName;
    [SerializeField] TextMeshProUGUI sentence;
    //[SerializeField] TextMeshProUGUI[] answers;

    public void UpdateFields(string sentence, string npcName)
    {
        this.sentence.text = sentence;
        if (this.npcName.text == npcName) return;
        this.npcName.text = npcName;
    }
}
