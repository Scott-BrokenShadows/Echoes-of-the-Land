using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendOnQuestButton : MonoBehaviour
{
    public GameManagerActions gameManager;
    public QuestDetails questDetails;
    public CharBase selectedCharacter;
    public DropDownAvailableChars dropDownAvailableChars;
    public Timer timer;
    public QuestList questList;
    // Start is called before the first frame update


    
    public void SendOnQuest()
    {
        if (selectedCharacter != null)
        {
            if (questDetails.currentQuest != null)
            {
                if (questDetails.currentQuest.evergreen != true)
                {
                    questList.mainQuests.Remove(questDetails.currentQuest);
                }
                selectedCharacter.currentQuest = questDetails.currentQuest;
                gameManager.QuestBoard();
                timer.AdvanceTime();
            }
        }
    }
}
