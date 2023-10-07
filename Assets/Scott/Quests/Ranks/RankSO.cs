using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Rank", menuName = "Quests/Rank", order = 2)]
public class RankSO : ScriptableObject
{
    public string rankLevel;
    public int totalSkills;
    public float baseExp;
    public float baseGold;
    public float baseTime;
}
