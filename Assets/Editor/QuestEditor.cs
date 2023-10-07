using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(QuestSO))]
[CanEditMultipleObjects]
public class QuestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        QuestSO questSO = (QuestSO)target;

        // Display the default Inspector fields
        EditorGUILayout.PropertyField(serializedObject.FindProperty("questName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("questDescription"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("rank"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("destination"));

        // Get the totalSkills value from the RankSO
        int totalSkills = 0;
        if (questSO.rank != null)
        {
            totalSkills = questSO.rank.totalSkills;
        }

        // Automatically adjust the skillsUsed List size based on totalSkills
        while (questSO.skillsUsed.Count < totalSkills)
        {
            questSO.skillsUsed.Add(null);
        }
        while (questSO.skillsUsed.Count > totalSkills)
        {
            questSO.skillsUsed.RemoveAt(questSO.skillsUsed.Count - 1);
        }

        // Display the skillsUsed List
        for (int i = 0; i < questSO.skillsUsed.Count; i++)
        {
            questSO.skillsUsed[i] = (SkillsSO)EditorGUILayout.ObjectField($"Skill {i + 1}", questSO.skillsUsed[i], typeof(SkillsSO), false);
        }

        // Display the calculated values
        EditorGUILayout.LabelField("Calculated Values:");
        EditorGUILayout.IntField("Experience Gained", questSO.GetXP());
        EditorGUILayout.IntField("Gold Given", questSO.GetGold());
        EditorGUILayout.IntField("Time To Complete", questSO.GetTime());

        serializedObject.ApplyModifiedProperties();
    }
}
