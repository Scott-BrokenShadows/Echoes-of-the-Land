using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerActions : MonoBehaviour
{
    public GameObject questPanel;
    public GameObject[] charPanels;

    // Start is called before the first frame update
    void Start()
    {
        questPanel.SetActive(false);

        foreach (GameObject panel in charPanels)
        {
            panel.gameObject.SetActive(false);
        }
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

    public void CharPanelOpen(int panelNum)
    {
        foreach (GameObject panel in charPanels)
        {
            panel.gameObject.SetActive(false);
        }

        charPanels[panelNum].SetActive(true);
    }

    public void CloseCharPanel(int panel)
    {
        charPanels[panel].SetActive(false);
    }
}
