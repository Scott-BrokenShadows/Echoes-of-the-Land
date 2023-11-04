using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeBrief : MonoBehaviour
{
    public Button charDBButton;
    public GameObject charPanel;
    public CharBase thisChar;
    public TextMeshProUGUI goldText;
    public CameraSwitcher cameraSwitch;

    // Start is called before the first frame update
    void Start()
    {
        charDBButton.gameObject.SetActive(false);
        charPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        goldText.text = thisChar.questGold.ToString() + " gold.";
    }

    public void DebriefPlayer()
    {
        StartCoroutine(SetPanels());

        
    }

    

    public void ButtonOff()
    {
        charDBButton.gameObject.SetActive(false);
    }

    public IEnumerator SetPanels()
    {
        if (cameraSwitch.currentCameraIndex != 1)
        {
            cameraSwitch.SwitchToCamera(1);
            
        }

        yield return new WaitForEndOfFrame();

        if (charPanel.gameObject.active == false)
        {
            charPanel.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(0.1f);

        ButtonOff();
    }
}
