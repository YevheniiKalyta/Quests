using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEnder : MonoBehaviour
{


    public NPC npc;
    public string[] questNames;


    private void OnTriggerEnter(Collider other)
    {
        npc.SubscribePlayer(other.gameObject);
        if (other.gameObject.tag == "Player")
        {

            for (int i = 0; i < questNames.Length; i++)
            {
                for (int j = 0; j < npc.subscribedPlayer.quests.Count; j++)
                {
                    if (npc.subscribedPlayer.quests[j].questName == questNames[i]&& !npc.subscribedPlayer.quests[j].completed)
                    {
                        npc.FinishQuest();
                    }
                }
            }
            
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        npc.UnSubscribePlayer();
    }

}
