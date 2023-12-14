using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChecker : MonoBehaviour
{
    [Header("Main Story")]
    public bool tutorial = false;
    public bool tutorialCompleted = false;
    public bool mQStarted = false;
    public bool mQ1SO = false;
    public bool mQ1SM = false;
    public bool mQ1SY = false;
    public bool mQ1C = false;
    public bool mQ2SO = false;
    public bool mQ2SM = false;
    public bool mQ2SY = false;
    public bool mQ2C = false;

    [Space]
    [Header("Daniel Story")]
    public bool dStory1 = false;
    public bool dStory1C = false;

    [Space]
    [Header("Ludwig Story")]
    public bool lStory1 = false;
    public bool lStory1C = false;

    [Space]
    [Header("Sidney Story")]
    public bool sStory1 = false;
    public bool sStory1C = false;

    [Space]
    [Header("Questing")]
    public int totalQuests;
    public int danQuests;
    public int ludQuests;
    public int sidQuests;
    public List<QuestSO> storyQuests = new List<QuestSO>();
    public QuestList questList;

    [Space]
    [Header("CharBases")]
    public CharBase danBase;
    public CharBase ludBase;
    public CharBase sidBase;
    public CombatAdven danTrust;
    public CombatAdven ludTrust;
    public CombatAdven sidTrust;

    [Space]
    public GameObject[] tutePanels;
    // Start is called before the first frame update
    void Start()
    {
        QuestSO[] mainQuests = Resources.LoadAll<QuestSO>("Quests");
        foreach (QuestSO quest in mainQuests)
        {
            if (quest.evergreen != true)
            {
                storyQuests.Add(quest);
            }
        }

        danBase.OnQuestFinished += DanQuestFinished;
        ludBase.OnQuestFinished += LudQuestFinished;
        sidBase.OnQuestFinished += SidQuestFinished;
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial && !tutorialCompleted)
        {
            DeletePanels();
            tutorialCompleted = true;
        }

        if (totalQuests >= 8 && mQStarted == false)
        {
            mQStarted = true;
            AddQuest("MQ1-Suspicious Activity");
        }

        if (ludQuests >= 10 && !lStory1)
        {
            lStory1 = true;
        }

        if (danTrust.trust >= 26 && !dStory1)
        {
            dStory1 = true;
        }

        if (sidBase.advenStates == AdvenStates.IsInjured && !sStory1)
        {
            sStory1 = true;
        }
    }

    public void AddQuest(string questName)
    {
        foreach (QuestSO quest in storyQuests)
        {
            if (quest.questName == questName)
            {
                questList.mainQuests.Add(quest);
                break;
            }
        }
    }

    void DanQuestFinished(string questName)
    {
        totalQuests++;
        danQuests++;

        switch (questName)
        {
            case "MQ1-Suspicious Activity":
                mQ1SO = true;
                break;

        }
    }

    void LudQuestFinished(string questName)
    {
        totalQuests++;
        ludQuests++;

        switch (questName)
        {
            case "MQ1-Suspicious Activity":
                mQ1SM = true;
                break;
        }
    }

    void SidQuestFinished(string questName)
    {
        totalQuests++;
        sidQuests++;

        switch (questName)
        {
            case "MQ1-Suspicious Activity":
                mQ1SY = true;
                break;
        }
    }

    void DeletePanels()
    {
        foreach (GameObject panel in tutePanels)
        {
            Destroy(panel);
        }
    }
}
