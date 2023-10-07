using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Skill", menuName = "Quests/Skill", order = 3)]
public class SkillsSO : ScriptableObject
{
    public string skillName;
    public float expMultiplier;
    public float goldMultiplier;
    public float timeMultiplier;
}
