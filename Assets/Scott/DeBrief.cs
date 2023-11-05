using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeBrief : MonoBehaviour
{
    public Button charDBButton;
    public GameObject[] charPanel;
    public CharBase thisChar;
    public TextMeshProUGUI goldText;
    public CameraSwitcher cameraSwitch;
    public int targetPanel;

    // Start is called before the first frame update
    void Start()
    {
        charDBButton.gameObject.SetActive(false);
        charPanel[targetPanel].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (thisChar.debrief == true)
        {
            charDBButton.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        goldText.text = thisChar.questGold.ToString() + " gold.";
    }

    public void DebriefPlayer()
    {
        StartCoroutine(SetPanels());
    }

    public IEnumerator SetPanels()
    {
        

        if (cameraSwitch.currentCameraIndex != 1)
        {
            cameraSwitch.SwitchToCamera(1);
            
        }

        yield return new WaitForEndOfFrame();

        foreach (GameObject panel in charPanel)
        {
            panel.SetActive(false);
        }

        yield return new WaitForSeconds(0.1f);

        if (charPanel[targetPanel].active == false)
        {
            charPanel[targetPanel].SetActive(true);
        }

    }
}
