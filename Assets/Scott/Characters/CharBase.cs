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
    public int currentHealth;
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
    public Timer timer;
    public QuestSO currentQuest;
    public int questTime;
    [SerializeField] public int questExp;
    [SerializeField] public int questGold;
    public bool questCalculation;
    public List<ItemDataSO> itemsCollected;
    public InventoryController inventory;
    public GuildFunds guildFunds;
    [Space]
    public Button deBriefButton;
    public bool debrief;
    public Button charButton;
    public Sprite isAvailableImage;
    public Sprite isInjuredImage;
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

        timer.OnTurnUpdate += HandleTurnUpdate;
        deBriefButton.gameObject.SetActive(false);
        itemsCollected = new List<ItemDataSO>();
        advenStates = AdvenStates.IsAvailable;
        debrief = false;
        UpdateStats();
        currentHealth = healthStat;
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
        if (charButton.gameObject.active == true)
        {
            charButton.gameObject.SetActive(false);
        }

        debrief = false;

        if (questCalculation == false)
        {
            questTime = currentQuest.timeToComplete;
            questGold = currentQuest.goldGiven;
            questExp = currentQuest.expGained;
            SkillRolls();
            questCalculation = true;
        }

        if (questCalculation == true && questTime <= 0)
        {
            advenStates = AdvenStates.IsBackFromQuest;
        }
    }



    private void IsInjured()
    {

        if (itemsCollected.Count > 0)
        {
            itemsCollected.Clear();
        }

        if (currentHealth > 0)
        {
            charButton.GetComponent<Image>().sprite = isAvailableImage;
            advenStates = AdvenStates.IsAvailable;
        }
    }

    private void IsBackFromQuest()
    {
        if (deBriefButton.gameObject.active == false && debrief == false)
        {
            deBriefButton.gameObject.SetActive(true);

            
        }

        if (currentQuest != null)
        {
            currentQuest = null;
        }
    }

    private void IsAvailable()
    {
        if (charButton.gameObject.active == false)
        {
            charButton.gameObject.SetActive(true);
        }

        if (itemsCollected.Count > 0)
        {
            itemsCollected.Clear();
        }

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
        if (currentQuest.rank != null)
        {
            foreach (SkillsSO skill in currentQuest.skillsUsed)
            {
                if (skill.skillType == SkillType.Combat)
                {
                    CombatRoll();
                }
                if (skill.skillType == SkillType.Gathering)
                {
                    GatherRoll();
                }
                if (skill.skillType == SkillType.Hunting)
                {
                    HuntRoll();
                }
                if (skill.skillType == SkillType.Exploration)
                {
                    ExploreRoll();
                }
                if (skill.skillType == SkillType.Negotiation)
                {
                    NegoRoll();
                }
            }
        }
    }

    private void NegoRoll()
    {
        int diceRoll = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 50f));
        int totalRoll = Mathf.RoundToInt(diceRoll * currentQuest.rank.diffcultyModifier) + negoStat;
        if (totalRoll <= 15)
        {
            questExp = Mathf.RoundToInt(questExp * 0.85f);
        }
        if (totalRoll >= 16 && totalRoll <= 30)
        {
            questExp = Mathf.RoundToInt(questExp * 0.90f);
        }
        if (totalRoll >= 31 && totalRoll <= 45)
        {
            questExp = Mathf.RoundToInt(questExp * 0.95f);
        }
        if (totalRoll >= 61 && totalRoll <= 75)
        {
            questExp = Mathf.RoundToInt(questExp * 1.05f);
        }
        if (totalRoll >= 76 && totalRoll <= 85)
        {
            questExp = Mathf.RoundToInt(questExp * 1.10f);
        }
        if (totalRoll >= 86)
        {
            questExp = Mathf.RoundToInt(questExp * 1.15f);
        }
    }

    private void ExploreRoll()
    {
        int diceRoll = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 50f));
        int totalRoll = Mathf.RoundToInt(diceRoll * currentQuest.rank.diffcultyModifier) + exploreStat;
        if (totalRoll <= 15)
        {
            questTime = Mathf.RoundToInt(questTime * 1.35f);
        }
        if (totalRoll >= 16 && totalRoll <= 30)
        {
            questTime = Mathf.RoundToInt(questTime * 1.25f);
        }
        if (totalRoll >= 31 && totalRoll <= 45)
        {
            questTime = Mathf.RoundToInt(questTime * 1.15f);
        }
        if (totalRoll >= 61 && totalRoll <= 75)
        {
            questTime = Mathf.RoundToInt(questTime * 0.85f);
        }
        if (totalRoll >= 76 && totalRoll <= 85)
        {
            questTime = Mathf.RoundToInt(questTime * 0.75f);
        }
        if (totalRoll >= 86)
        {
            questTime = Mathf.RoundToInt(questTime * 0.65f);
            //give item x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[2];
                itemsCollected.Add(item);
            }
        }
    }

    private void HuntRoll()
    {
        int diceRoll = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 50f));
        int totalRoll = Mathf.RoundToInt(diceRoll * currentQuest.rank.diffcultyModifier) + huntStat;
        if (totalRoll <= 15)
        {
            questTime = Mathf.RoundToInt(questTime * 1.22f);
            currentHealth -= 5;
        }
        if (totalRoll >= 16 && totalRoll <= 30)
        {
            questTime = Mathf.RoundToInt(questTime * 1.13f);
            currentHealth -= 3;
        }
        if (totalRoll >= 31 && totalRoll <= 45)
        {
            questTime = Mathf.RoundToInt(questTime * 1.08f);
            currentHealth -= 1;
        }
        if (totalRoll >= 46 && totalRoll <= 75)
        {
            questTime = Mathf.RoundToInt(questTime * 0.92f);
            //give item 1 x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[0];
                itemsCollected.Add(item);
            }
        }
        if (totalRoll >= 76 && totalRoll <= 85)
        {
            questTime = Mathf.RoundToInt(questTime * 0.87f);
            //give item 2 x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[0];
                itemsCollected.Add(item);
            }
        }
        if (totalRoll >= 86)
        {
            questTime = Mathf.RoundToInt(questTime * 0.78f);
            //give item 3 x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[0];
                itemsCollected.Add(item);
            }
        }
    }

    private void GatherRoll()
    {
        int diceRoll = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 50f));
        int totalRoll = Mathf.RoundToInt(diceRoll * currentQuest.rank.diffcultyModifier) + gatherStat;
        if (totalRoll <= 15)
        {
            questTime = Mathf.RoundToInt(questTime * 1.25f);
        }
        if (totalRoll >= 16 && totalRoll <= 30)
        {
            questTime = Mathf.RoundToInt(questTime * 1.15f);
        }
        if (totalRoll >= 31 && totalRoll <= 45)
        {
            questTime = Mathf.RoundToInt(questTime * 1.10f);
        }
        if (totalRoll >= 46 && totalRoll <= 75)
        {
            //give item 1 x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[1];
                itemsCollected.Add(item);
            }
        }
        if (totalRoll >= 76 && totalRoll <= 85)
        {
            //give item 2 x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[1];
                itemsCollected.Add(item);
            }
        }
        if (totalRoll >= 86)
        {
            //give item 3 x distance;
            int itemCount = (int)currentQuest.destination;
            for (int i = 0; i < itemCount; i++)
            {
                ItemDataSO item = inventory.items[1];
                itemsCollected.Add(item);
            }
        }
    }

    private void CombatRoll()
    {
        int diceRoll = Mathf.RoundToInt(UnityEngine.Random.Range(1f, 50f));
        int totalRoll = Mathf.RoundToInt(diceRoll * currentQuest.rank.diffcultyModifier) + combatStat;
        if (totalRoll <= 15)
        {
            currentHealth -= 9;
        }
        if (totalRoll >= 16 && totalRoll <= 30)
        {
            currentHealth -= 5;
        }
        if (totalRoll >= 31 && totalRoll <= 45)
        {
            currentHealth -= 2;
        }
        if (totalRoll >= 61 && totalRoll <= 75)
        {
            questExp = Mathf.RoundToInt(questExp * 1.01f);
        }
        if (totalRoll >= 76 && totalRoll <= 85)
        {
            questExp = Mathf.RoundToInt(questExp * 1.05f);
        }
        if (totalRoll >= 86)
        {
            questExp = Mathf.RoundToInt(questExp * 1.15f);
        }
    }

    private void HandleTurnUpdate()
    {
        if (advenStates == AdvenStates.IsOnQuest)
        {
            questTime--;
        }

        if (advenStates == AdvenStates.IsInjured)
        {
            if (currentHealth < healthStat)
            {
                currentHealth++;
            }
        }

        if (advenStates == AdvenStates.IsAvailable)
        {
            if (currentHealth < healthStat)
            {
                currentHealth++;
            }
        }
    }

    public void FinishQuest()
    {
        guildFunds.SpendGold(questGold);
        currentXP = currentXP + questExp;
        debrief = true;
        FillInventory();


        if (currentHealth <= 0)
        {
            advenStates = AdvenStates.IsInjured;
            charButton.GetComponent<Image>().sprite = isInjuredImage;
        }

        if (currentHealth > 0)
        {
            advenStates = AdvenStates.IsAvailable;
            charButton.GetComponent<Image>().sprite = isAvailableImage;
        }

        
        
    }

    void FillInventory()
    {
        foreach (ItemDataSO item in itemsCollected)
        {
            inventory.InsertAdventurerItem(item);
        }
    }

    

}
