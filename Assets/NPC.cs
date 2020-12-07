using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : QuestGiver
{

    public override void StartQuest()
    {
        base.StartQuest();
        questsToGive[currentQuest].OnStart();
    }

    public override void UpdateQuest()
    {
        base.UpdateQuest();
        
    }

    public override void FinishQuest()
    {
        
        base.FinishQuest();

    }


    public void Proceed()
    {
        if (!questsToGive[currentQuest].completed && !questsToGive[currentQuest].inProgress)
        {
            StartQuest();
        }
        else 
        {
            if (currentQuest < questsToGive.Length - 1)
            {
                currentQuest++;
            }

            HideUI(); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        OnInteraction();
    }
    

}
