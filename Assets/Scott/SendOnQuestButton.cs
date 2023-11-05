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
    // Start is called before the first frame update


    
    public void SendOnQuest()
    {
        if (selectedCharacter != null)
        {
            if (questDetails.currentQuest != null)
            {
                selectedCharacter.currentQuest = questDetails.currentQuest;
                gameManager.QuestBoard();
                timer.AdvanceTime();
            }
        }
    }
}
