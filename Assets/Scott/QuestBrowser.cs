using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBrowser : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParentEvergreen;
    public GameObject buttonParentMain;
    public QuestDetails questDetails;
    
    public QuestList questList;

    private void OnEnable()
    {
        foreach (Transform child in buttonParentEvergreen.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in buttonParentMain.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (QuestSO quest in questList.evergreenQuestList)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParentEvergreen.transform);
            newButton.GetComponent<QuestButton>().text.text = quest.questName;
            newButton.GetComponent<Button>().onClick.AddListener(()=>SetCurrentQuest(quest));
            
        }

        foreach (QuestSO quest in questList.mainQuests)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParentMain.transform);
            newButton.GetComponent<QuestButton>().text.text = quest.questName;
            newButton.GetComponent<Button>().onClick.AddListener(() => SetCurrentQuest(quest));

        }
    }

    void SetCurrentQuest(QuestSO quest)
    {
        questDetails.selectedQuest = quest;
    }
}
