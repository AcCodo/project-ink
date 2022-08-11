using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI npcName;
    [SerializeField] TextMeshProUGUI sentence;

    [SerializeField] TextMeshProUGUI[] buttons;

    public void UpdateFields(string sentence, string npcName)
    {
        this.sentence.text = sentence;
        if (this.npcName.text == npcName) return;
        this.npcName.text = npcName;
    }

    public void UpdateButtons(string[] buttonTexts)
    {

        for(int i = 0; i < buttons.Length; i++)
        {
            if (i >= buttonTexts.Length)
            {
                buttons[i].text = "";

                buttons[i].GetComponentInParent<Button>(true).gameObject.SetActive(false);
                continue;
            }
            buttons[i].GetComponentInParent<Button>(true).gameObject.SetActive(true);
            buttons[i].text = buttonTexts[i];
        }
    }
}
