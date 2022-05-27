using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Old version
    public string npcName;
    [TextArea(3,10)]
    public string[] sentences;


    //New version
    private List<Message> dialogueStructure;
    public TextAsset conversationJSON;

    public void ParseJSONtoDialogueStructure()
    {
        Root root = JsonConvert.DeserializeObject<Root>(conversationJSON.text);
        if (root == null || root.messages == null) Debug.LogError("Deserialize Error.");
        //Debug.Log(root.messages.Count);
        dialogueStructure = root.messages;
    }

    public Message SearchMessage(int id)
    {
        foreach (Message message in dialogueStructure)
        {
            if (message.id == id)
            {
                return message;
            }
        }
        return null;
    }

    private class Root
    {
        public List<Message> messages { get; set; }
    }

    public class Message
    {
        public int id { get; set; }

        public int NPC { get; set; }

        public string text { get; set; }

        [JsonProperty("next-id")]
        public int NextId { get; set; }

        public List<Answer> answers { get; set; }

        public class Answer
        {
            public string text { get; set; }

            [JsonProperty("opinion-mod")]
            public int OpinionMod { get; set; }

            [JsonProperty("next-id")]
            public int NextId { get; set; }
            
            [JsonProperty("ans-id")]
            public int id { get; set; }

            public string[] callbacks { get; set; }

            public Answer(string text, int opinion_mod, int next_id, string[] callbacks)
            {
                this.text = text;
                this.OpinionMod = opinion_mod;
                this.NextId = next_id;
                this.callbacks = callbacks;
            }
        }

        public Message(int id, int npc, string text, int next_id, List<Answer> answers)
        {
            this.id = id;
            this.NPC = npc;
            this.text = text;
            this.NextId = next_id; 
            this.answers = answers;
        }

        public Answer SearchAnswer(int answerId)
        {
            foreach (Answer answer in answers)
            {
                if (answer.id == answerId)
                {
                    return answer;
                }
            }
            return null;
        }
    }
}
