using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class QuestDetails : MonoBehaviour
{
    public QuestSO currentQuest;
    public QuestSO selectedQuest;
    public RawImage circle;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI detailsText;
    public TextMeshProUGUI expectedEXP;
    public TextMeshProUGUI expectedTime;
    public TextMeshProUGUI advenPay;
    public TextMeshProUGUI rank;
    public TextMeshProUGUI skillList;

    public GameObject confirmPanel;
    public TextMeshProUGUI confirmDays;

    public delegate void QuestChanged();
    public event QuestChanged QuestDetailsChanged;


    private void Start()
    {
        circle.enabled = false;
        confirmPanel.SetActive(false);
    }
    private void Update()
    {
        if (currentQuest == null)
        {
            confirmPanel.SetActive(false);
        }

        
        if (currentQuest != selectedQuest)
        {
            currentQuest = selectedQuest;
            if (currentQuest.evergreen != true)
            {
                circle.enabled = true;
            }
            else
            {
                circle.enabled = false;
            }
            nameText.text = currentQuest.questName;
            detailsText.text = currentQuest.questDescription;
            expectedEXP.text = currentQuest.expGained.ToString() + " XP";
            expectedTime.text = Mathf.Round(currentQuest.timeToComplete / 10f).ToString() + " days";
            confirmDays.text = Mathf.Round(currentQuest.timeToComplete / 10f).ToString() + " days";
            advenPay.text = currentQuest.goldGiven.ToString() + " G";
            rank.text = currentQuest.rank.rankLevel;
            string skillsText = FormatSkillsList(currentQuest.skillsUsed);
            skillList.text = "Skill rolls to make : " + skillsText;
            QuestDetailsChanged?.Invoke();
        }
    }

    private string FormatSkillsList(List<SkillsSO> skillsUsed)
    {
        if (skillsUsed == null || skillsUsed.Count == 0)
        {
            return "No skills used";
        }

        string formattedSkills = "";
        for (int i = 0; i < skillsUsed.Count; i++)
        {
            // Extract the SkillType from the SkillSO and add it to the formattedSkills string
            formattedSkills += skillsUsed[i].skillType.ToString();

            // If it's not the last skill in the list, add a comma and space
            if (i < skillsUsed.Count - 1)
            {
                formattedSkills += ", ";
            }
        }

        return formattedSkills;
    }

    private void OnEnable()
    {
        nameText.text = "";
        detailsText.text = "";
        expectedEXP.text = "" + " XP";
        expectedTime.text ="" + " days";
        advenPay.text = "" + " G";
        rank.text = "";
        skillList.text = "Skill rolls to make : " + "";
    }

    private void OnDisable()
    {
        currentQuest = null;
        selectedQuest = null;
        circle.enabled = false;
    }

    public void OpenPanelConfirm()
    {
        if (currentQuest != null)
        {
            confirmPanel.SetActive(true);
        }
        
    }

    public void ClosePanelConfirm()
    {
        confirmPanel.SetActive(false);
    }
}
