using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver:MonoBehaviour
{

    public QuestManager subscribedPlayer;
    
    public Quest[] questsToGive;
    public Text questName,questDescription,questReward;
    public GameObject uiHolder;

    public int currentQuest=0;

    public virtual void StartQuest()
    {

        if (!subscribedPlayer.quests.Contains(questsToGive[currentQuest])) 
            subscribedPlayer.quests.Add(questsToGive[currentQuest]);

        HideUI();

    }



    public virtual void UpdateQuest()
    {


    }

    public virtual void FinishQuest()
    {
        if (!subscribedPlayer.quests[currentQuest].completed)
        {
            subscribedPlayer.GiveReward(questsToGive[currentQuest].questReward);
            subscribedPlayer.quests[currentQuest].completed = true;
            questsToGive[currentQuest].OnFinished();
            ShowUI();


        }



    }
    protected void OnInteraction()
    {
       Quest quest = subscribedPlayer.quests.Find((x) => x.questName == questsToGive[currentQuest].questName);

        if (quest==null)
        {
            ShowUI();
        }
        else if (quest.inProgress)
        {
            UpdateQuest();
        }
        else if (quest.completed)
        {
            FinishQuest();
        }

            
    }

    void ShowUI()
    {
        uiHolder.SetActive(true);
        if (!questsToGive[currentQuest].completed)
        {
            
            questName.text = questsToGive[currentQuest].questName;
            questDescription.text = questsToGive[currentQuest].questDescription;
            questReward.text = questsToGive[currentQuest].questReward.ToString();
            
        }
        else
        {
            questName.text = " ";
            questDescription.text = questsToGive[currentQuest].questFinishText;
            questReward.text = " ";
        }


            Time.timeScale = 0;

    }

    public void HideUI()
    {
        Time.timeScale = 1;
        uiHolder.SetActive(false);

    }

    public void SubscribePlayer(GameObject gameObject)
    {
        subscribedPlayer = gameObject.GetComponent<QuestManager>();
        
    }
    public void UnSubscribePlayer()
    {
        subscribedPlayer = null;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SubscribePlayer(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            UnSubscribePlayer();
        }
    }
}
