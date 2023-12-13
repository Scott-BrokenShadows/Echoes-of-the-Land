using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAdven : MonoBehaviour
{
    public float trust;
    public CharBase charBase;
    public Timer timer;
    private bool skillsChecked;

    void Start()
    {
        InitializeTrust();
        InitializeTimer();
    }

    void InitializeTrust()
    {
        switch (charBase.charClass)
        {
            case CharClass.Combat:
                trust = 5f;
                break;
            case CharClass.Explorer:
                trust = 20f;
                break;
            case CharClass.Gatherer:
                trust = 80f;
                break;
        }
    }

    void InitializeTimer()
    {
        timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            timer.OnTurnUpdate += HandleTurn;
        }
        else
        {
            Debug.LogError("Timer not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HandleTurn()
    {
        switch (charBase.charClass)
        {
            case CharClass.Combat:
                CombatCalc();
                break;
            case CharClass.Explorer:
                ExplorerCalc();
                break;
            case CharClass.Gatherer:
                GatherCalc();
                break;
        }
    }

    void CombatCalc()
    {
        if (charBase.advenStates != AdvenStates.IsOnQuest)
        {
            skillsChecked = false;
        }
        

        if (!skillsChecked && charBase.advenStates == AdvenStates.IsOnQuest)
        {
            skillsChecked = true;
            if (charBase.currentQuest.rank != null)
            {
                foreach (SkillsSO skill in charBase.currentQuest.skillsUsed)
                {
                    if (skill.skillType == SkillType.Combat)
                    {
                        trust += 3f;
                    }
                    else
                    {
                        trust -= 0.3f;
                    }
                }
            }
        }
    }

    void ExplorerCalc()
    {
        if (charBase.advenStates == AdvenStates.IsOnQuest)
        {
            trust += 0.1f;
        }
        else
        {
            trust -= 0.5f;
        }
    }

    void GatherCalc()
    {
        if (charBase.advenStates == AdvenStates.IsAvailable)
        {
            trust += 0.1f;
        }
        else if (charBase.advenStates == AdvenStates.IsInjured)
        {
            trust -= 5f;
        }
    }
}
