using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownAvailableChars : MonoBehaviour
{
    public QuestBrowser questBrowser;
    public TMP_Dropdown dropDown;
    public SendOnQuestButton sendOnQuestButton;

    private void OnEnable()
    {
        List<string> characterNames = new List<string>();

        foreach (CharBase character in questBrowser.characters)
        {
            characterNames.Add(character.charName);
        }

        dropDown.ClearOptions();
        dropDown.AddOptions(characterNames);


        string characterName = dropDown.options[0].text;
        CharBase selectedCharacter = GetCharacterByName(characterName);
        sendOnQuestButton.selectedCharacter = selectedCharacter;

    }

    public void OnValueChange(int index)
    {
        if (index >= 0 && index < dropDown.options.Count)
        {
            // Get the selected character's name from the dropdown options.
            string characterName = dropDown.options[index].text;

            // Find the character from your list based on the name.
            CharBase selectedCharacter = GetCharacterByName(characterName); // Replace with your actual method.

            // Send the selected character to your button script.
            sendOnQuestButton.selectedCharacter = selectedCharacter;
        }
    }

    public CharBase GetCharacterByName(string characterName)
    {
        CharBase[] characters = FindObjectsOfType<CharBase>();

        foreach (CharBase character in characters)
        {
            if (character.charName == characterName)
            {
                return character;
            }
        }

        return null; // Return null if the character with the specified name is not found.
    }
}
