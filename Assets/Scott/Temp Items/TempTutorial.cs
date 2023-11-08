using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTutorial : MonoBehaviour
{
    public GameObject tutorialPages;
    public CameraSwitcher cameraSwitcher;
    // Start is called before the first frame update
    void Start()
    {
        tutorialPages.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraSwitcher.currentCameraIndex != 2)
        {
            tutorialPages.SetActive(false);
        }
    }

    public void OpenTute()
    {
        if (cameraSwitcher.currentCameraIndex == 2)
        {
            tutorialPages.SetActive(true);
        }
    }

    public void CloseTute()
    {
        
            tutorialPages.SetActive(false);
        
    }
}
