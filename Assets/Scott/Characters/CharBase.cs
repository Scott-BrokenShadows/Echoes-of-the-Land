using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharBase : MonoBehaviour
{
    public AdvenStates advenStates;
    public string charName;
    public CharClass charClass;
    [Space]
    [Range(1, 50)]
    public int charLevel;
    public int currentXP;
    public int nextLevelXP;
    [Range(1, 20)]
    public int healthStat;
    [Range(1, 100)]
    public int combatStat;
    [Range(1, 100)]
    public int exploreStat;
    [Range(1, 100)]
    public int huntStat;
    [Range(1, 100)]
    public int gatherStat;
    [Range(1, 100)]
    public int negoStat;
    [Range(1, 100)]
    public int trust;
    [Space]
    public QuestSO currentQuest;
    public int questTime;
    [SerializeField] private int questExp;
    [SerializeField] private int questGold;
    public bool questCalculation;
    [Space]
    public Image isAvailableImage;
    public Image isInjuredImage;
    [Space]
    [Range(0, 2)]
    public float baseCombatStat;
    [Range(0, 2)]
    public float baseExploreStat;
    [Range(0, 2)]
    public float baseHuntStat;
    [Range(0, 2)]
    public float baseGatherStat;
    [Range(0, 2)]
    public float baseNegoStat;


    // Start is called before the first frame update
    void Start()
    {
        MonoBehaviour charScript = null;

        switch (charClass)
        {
            case CharClass.Combat:
                charScript = GetComponent<CombatAdven>();
                break;
            case CharClass.Explorer:
                charScript = GetComponent<ExploreAdven>();
                break;
            case CharClass.Gatherer:
                charScript = GetComponent<GatherAdven>();
                break;
        }

        UpdateStats();
    }

    
    // Update is called once per frame
    void Update()
    {
        switch (advenStates)
        {
            case AdvenStates.IsAvailable:
                IsAvailable();
                break;
            case AdvenStates.IsBackFromQuest:
                IsBackFromQuest();
                break;
            case AdvenStates.IsInjured:
                IsInjured();
                break;
            case AdvenStates.IsOnQuest:
                IsOnQuest();
                break;
        }
    }

    private void LateUpdate()
    {
        if (currentXP >= nextLevelXP)
        {
            LevelUp();
        }
    }

    

    private void IsOnQuest()
    {
        if (questCalculation == false)
        {
            questTime = currentQuest.timeToComplete;
            questGold = currentQuest.goldGiven;
            questExp = currentQuest.expGained;
            SkillRolls();
        }
       
    }

    

    private void IsInjured()
    {

    }

    private void IsBackFromQuest()
    {

    }

    private void IsAvailable()
    {
        if (currentQuest != null)
        {
            questCalculation = false;
            advenStates = AdvenStates.IsOnQuest;
        }
    }

    private void UpdateStats()
    {
        combatStat = Mathf.RoundToInt(baseCombatStat * charLevel);
        huntStat = Mathf.RoundToInt(baseHuntStat * charLevel);
        gatherStat = Mathf.RoundToInt(baseGatherStat * charLevel);
        exploreStat = Mathf.RoundToInt(baseExploreStat * charLevel);
        negoStat = Mathf.RoundToInt(baseNegoStat * charLevel);
        nextLevelXP = Mathf.RoundToInt(392 * (2 * (charLevel + (charLevel / 50))));
    }

    private void LevelUp()
    {
        charLevel++;
        currentXP = currentXP - nextLevelXP;
        UpdateStats();
    }

    private void SkillRolls()
    {
        float totalTimeMultiplier = 0f;

        foreach (SkillsSO skill in currentQuest.skillsUsed)
        {
            if (currentQuest.rank != null && skill != null)
            {
                totalTimeMultiplier += skill.timeMultiplier;
            }
        }

        float rankValue = 3 / totalTimeMultiplier;


    }
}
