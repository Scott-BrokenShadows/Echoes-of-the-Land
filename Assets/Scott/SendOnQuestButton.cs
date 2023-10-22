using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendOnQuestButton : MonoBehaviour
{
    public QuestDetails questDetails;
    public CharBase selectedCharacter;
    // Start is called before the first frame update
    

    public void SendOnQuest()
    {
        if (selectedCharacter != null)
        {
            if (questDetails.currentQuest != null)
            {
                selectedCharacter.currentQuest = questDetails.currentQuest;
            }
        }
    }
}
