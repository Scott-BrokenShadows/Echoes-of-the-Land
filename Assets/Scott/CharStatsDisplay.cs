using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharStatsDisplay : MonoBehaviour
{
    public CharBase charBase;
    public CombatAdven trustBase;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI currentXPText;
    public TextMeshProUGUI nextXPText;
    public TextMeshProUGUI trustText;
    public TextMeshProUGUI combatText;
    public TextMeshProUGUI huntText;
    public TextMeshProUGUI gatherText;
    public TextMeshProUGUI exploreText;
    public TextMeshProUGUI negoText;
    public TextMeshProUGUI statusText;

    public Image thisImage;
    public Sprite[] sprites;

    private void OnEnable()
    {
        thisImage.sprite = sprites[Random.Range(0, sprites.Length)];
        levelText.text = charBase.charLevel.ToString();
        currentXPText.text = charBase.currentXP.ToString();
        nextXPText.text = charBase.nextLevelXP.ToString();
        SetValueFloat(trustBase.trust, trustText);
        SetValue(charBase.combatStat, combatText);
        SetValue(charBase.huntStat, huntText);
        SetValue(charBase.gatherStat, gatherText);
        SetValue(charBase.exploreStat, exploreText);
        SetValue(charBase.negoStat, negoText);

        if (charBase.advenStates == AdvenStates.IsInjured)
        {
            statusText.text = "Injured";
        }
        else if (charBase.currentHealth <= (charBase.healthStat * 0.33f))
        {
            statusText.text = "Hurting";
        }
        else if (charBase.currentHealth <= (charBase.healthStat * 0.66f))
        {
            statusText.text = "Poorly";
        }
        else
        {
            statusText.text = "Healthy";
        }

    }

    private void SetValue(int statVal, TextMeshProUGUI thisText)
    {
        if (statVal <= 8)
        {
            thisText.text = "E-";
        }
        else if (statVal <= 17)
        {
            thisText.text = "E";
        }
        else if (statVal <= 25)
        {
            thisText.text = "E+";
        }
        else if (statVal <= 32)
        {
            thisText.text = "D-";
        }
        else if (statVal <= 40)
        {
            thisText.text = "D";
        }
        else if (statVal <= 47)
        {
            thisText.text = "D+";
        }
        else if (statVal <= 53)
        {
            thisText.text = "C-";
        }
        else if (statVal <= 59)
        {
            thisText.text = "C";
        }
        else if (statVal <= 65)
        {
            thisText.text = "C+";
        }
        else if (statVal <= 69)
        {
            thisText.text = "B-";
        }
        else if (statVal <= 75)
        {
            thisText.text = "B";
        }
        else if (statVal <= 79)
        {
            thisText.text = "B+";
        }
        else if (statVal <= 83)
        {
            thisText.text = "A-";
        }
        else if (statVal <= 87)
        {
            thisText.text = "A";
        }
        else if (statVal <= 91)
        {
            thisText.text = "A+";
        }
        else if (statVal <= 94)
        {
            thisText.text = "S-";
        }
        else if (statVal <= 97)
        {
            thisText.text = "S";
        }
        else if (statVal <= 100)
        {
            thisText.text = "S+";
        }
        else
        {
            thisText.text = "SS";
        }
    }

    private void SetValueFloat(float statVal, TextMeshProUGUI thisText)
    {
        if (statVal <= 8)
        {
            thisText.text = "E-";
        }
        else if (statVal <= 17)
        {
            thisText.text = "E";
        }
        else if (statVal <= 25)
        {
            thisText.text = "E+";
        }
        else if (statVal <= 32)
        {
            thisText.text = "D-";
        }
        else if (statVal <= 40)
        {
            thisText.text = "D";
        }
        else if (statVal <= 47)
        {
            thisText.text = "D+";
        }
        else if (statVal <= 53)
        {
            thisText.text = "C-";
        }
        else if (statVal <= 59)
        {
            thisText.text = "C";
        }
        else if (statVal <= 65)
        {
            thisText.text = "C+";
        }
        else if (statVal <= 69)
        {
            thisText.text = "B-";
        }
        else if (statVal <= 75)
        {
            thisText.text = "B";
        }
        else if (statVal <= 79)
        {
            thisText.text = "B+";
        }
        else if (statVal <= 83)
        {
            thisText.text = "A-";
        }
        else if (statVal <= 87)
        {
            thisText.text = "A";
        }
        else if (statVal <= 91)
        {
            thisText.text = "A+";
        }
        else if (statVal <= 94)
        {
            thisText.text = "S-";
        }
        else if (statVal <= 97)
        {
            thisText.text = "S";
        }
        else if (statVal <= 100)
        {
            thisText.text = "S+";
        }
        else
        {
            thisText.text = "SS";
        }
    }
}
