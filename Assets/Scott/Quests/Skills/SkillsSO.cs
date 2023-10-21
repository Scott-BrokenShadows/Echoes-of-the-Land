using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Combat,
    Exploration,
    Gathering,
    Hunting,
    Negotiation
}

[CreateAssetMenu(fileName = "Skill", menuName = "Quests/Skill", order = 3)]
public class SkillsSO : ScriptableObject
{
    public SkillType skillType;
    public float expMultiplier;
    public float goldMultiplier;
    public float timeMultiplier;
}
