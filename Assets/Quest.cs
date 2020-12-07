using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    static int id;

    public int questReward;
    public string questName,questDescription,questFinishText;
    public bool inProgress, completed;


    
    public void OnStart()
    {
        Debug.Log("Quest: " + questName + " started!");
    }

    public void OnFinished()
    {
        Debug.Log("Quest: " + questName + " finished!");

    }


    public void OnUpdate()
    {

    }


}
