using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    public List<QuestSO> evergreenQuestList = new List<QuestSO>();
    public List<QuestSO> mainQuests = new List<QuestSO>();

    // Start is called before the first frame update
    void Start()
    {
        QuestSO[] allEvergreenQuests = Resources.LoadAll<QuestSO>("Quests");
        foreach (QuestSO quest in allEvergreenQuests)
        {
            if (quest.evergreen == true)
            {
                evergreenQuestList.Add(quest);
            }
            //remove this bit later, don't forget
            //else
            //{
            //    mainQuests.Add(quest);
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
