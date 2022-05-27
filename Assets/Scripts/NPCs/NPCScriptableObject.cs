using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName ="npc", menuName = "ScriptableObjects/NPC")]
public class NPCScriptableObject : ScriptableObject
{
    [Header("Main Information")]
    [SerializeField] int id;
    public string npcName;
    public string nickname;
    [Header("Info")]
    public int age;
    public bool isReliable;

    [Header("Art")]
    public Sprite npcArt;

    
    

    public int GetId()
    {
        return id;
    }
}
