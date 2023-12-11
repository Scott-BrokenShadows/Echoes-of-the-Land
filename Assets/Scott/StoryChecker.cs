using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChecker : MonoBehaviour
{
    [Header("Main Story")]
    public bool tutorial;

    [Space]
    [Header("Daniel Story")]
    public bool dStroy1;

    [Space]
    [Header("Ludwig Story")]
    public bool lStory1;

    [Space]
    [Header("Sidney Story")]
    public bool sStory1;

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
        
    }

    public void AddQuest(string questName)
    {
        foreach (QuestSO quest in storyQuests)
        {
            if (quest.name == questName)
            {
                questList.mainQuests.Add(quest);
            }
        }
    }

    void DanQuestFinished(string questName)
    {
        totalQuests++;
        danQuests++;
    }

    void LudQuestFinished(string questName)
    {
        totalQuests++;
        ludQuests++;
    }

    void SidQuestFinished(string questName)
    {
        totalQuests++;
        sidQuests++;
    }
}
