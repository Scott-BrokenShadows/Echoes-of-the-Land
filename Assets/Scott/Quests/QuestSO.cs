using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Destination
{
    Close = 1,
    Medium = 2,
    Far = 3,
    VeryFar = 4
}


[CreateAssetMenu(fileName = "Quest", menuName = "Quests/Quest", order = 1)]
public class QuestSO :ScriptableObject
{
    public string questName;
    [TextArea]
    public string questDescription;
    public RankSO rank;
    public Destination destination;
    public List<SkillsSO> skillsUsed = new List<SkillsSO>();
    [SerializeField] private int expGained;
    [SerializeField] private int goldGiven;
    [SerializeField] private int timeToComplete;

    private void CalculateEXP()
    {
        float totalExpMultiplier = 0f;

        foreach (SkillsSO skill in skillsUsed)
        {
            if (rank != null && skill != null)
            {
                totalExpMultiplier += skill.expMultiplier;
            }
        }

        if (rank != null)
        {
            expGained = Mathf.RoundToInt(rank.baseExp * totalExpMultiplier);
        }
        else
        {
            expGained = 0;
        }
        
    }

    private void CalculateGold()
    {
        float totalGoldMultiplier = 0f;

        foreach (SkillsSO skill in skillsUsed)
        {
            if (rank != null && skill != null)
            {
                totalGoldMultiplier += skill.goldMultiplier;
            }
        }

        if (rank != null)
        {
            goldGiven = Mathf.RoundToInt(rank.baseGold * totalGoldMultiplier);
        }
        else
        {
            goldGiven = 0;
        }
        
    }

    private void CalculateTime()
    {
        float totalTimeMultiplier = 0f;

        foreach (SkillsSO skill in skillsUsed)
        {
            if (rank != null && skill != null)
            {
                totalTimeMultiplier += skill.timeMultiplier;
            }
        }

        int destinationValue = (int)destination;


        if (rank != null)
        {
            timeToComplete = Mathf.RoundToInt(rank.baseTime * totalTimeMultiplier * destinationValue);
        }
        else
        {
            timeToComplete = 0;
        }
        
    }

    public int GetXP()
    {
        CalculateEXP();
        return expGained;
    }

    public int GetGold()
    {
        CalculateGold();
        return goldGiven;
    }

    public int GetTime()
    {
        CalculateTime();
        return timeToComplete;
    }
}
