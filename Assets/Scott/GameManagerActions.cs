using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerActions : MonoBehaviour
{
    public GameObject questPanel;

    // Start is called before the first frame update
    void Start()
    {
        questPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestBoard()
    {
        if (!questPanel.activeSelf)
        {
            questPanel.SetActive(true);
        }
        else
        {
            questPanel.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }
}
