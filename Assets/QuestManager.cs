using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public List<Quest> quests;
    private GUIStyle guiStyle = new GUIStyle();
    private GUIStyle guiStyleGreen = new GUIStyle();
    public Player player;

    private void Awake()
    {
        guiStyle.fontSize = 100;
        guiStyleGreen.normal.textColor = Color.green;
        guiStyleGreen.fontSize = 100;

    }

    public void OnGUI()
    {

        GUI.Label(new Rect(0, 0, 100, 100), "Questy: ",guiStyle);

        for (int i = 0; i < quests.Count; i++)
        {
            GUI.Label(new Rect(0, 100*(i+1), 1000, 1000), quests[i].questName, quests[i].completed?guiStyleGreen: guiStyle);
        }

        GUI.Label(new Rect(3000, 0, 100, 100), "Gold: ", guiStyle);
        GUI.Label(new Rect(3000, 100, 100, 100), player.gold.ToString(), guiStyle);

    }

    public void GiveReward(int goldAmount)
    {
        player.gold += goldAmount;
    }
}
