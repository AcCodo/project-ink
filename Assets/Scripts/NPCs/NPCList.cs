using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCList : MonoBehaviour
{
    [SerializeField] NPCScriptableObject[] allNPCsSO;
    public bool orderCorrect;

    public NPCScriptableObject SearchNPC(int npcid)
    {
        if (orderCorrect)
        {
            return allNPCsSO[npcid];
        } else
        {
            foreach (NPCScriptableObject npc in allNPCsSO)
            {
                if (npc.GetId() == npcid)
                {
                    return npc;
                }
            }
        } 

        return null;
    }
}
