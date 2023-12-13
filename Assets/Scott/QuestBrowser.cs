using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBrowser : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject buttonParentEvergreen;
    public GameObject buttonParentMain;
    public QuestDetails questDetails;
    public DropDownAvailableChars dropDown;

    public List<CharBase> characters = new List<CharBase>();
    
    public QuestList questList;

    
    private void OnEnable()
    {
        questDetails.QuestDetailsChanged += OnQuestDetailsChanged;

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

        dropDown.PopulateDropdown();
    }

    private void OnDisable()
    {
        characters.Clear();
    }

    void SetCurrentQuest(QuestSO quest)
    {
        questDetails.selectedQuest = quest;
        
    }

    void OnQuestDetailsChanged()
    {
        characters.Clear();

        CharBase[] charBases = FindObjectsOfType<CharBase>();

        foreach (CharBase charBase in charBases)
        {
            if (charBase.advenStates == AdvenStates.IsAvailable)
            {
                if (questDetails.currentQuest.requiredClass == CharClass.None)
                {
                    characters.Add(charBase);
                }
                else if (charBase.charClass == questDetails.currentQuest.requiredClass)
                {
                    characters.Add(charBase);
                }
                    
            }
        }

        dropDown.PopulateDropdown();
    }
}
