using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject audioPanel;
    public CameraSwitcher cameras;
    // Start is called before the first frame update
    void Start()
    {
        audioPanel.SetActive(false);
        optionsPanel.SetActive(false);

        cameras = FindObjectOfType<CameraSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cameras.newCameraIndex != 0 && cameras.newCameraIndex != 5 && optionsPanel.active == true)
        {
            CloseAudio();
            CloseOptions();
        }
    }

    public void OpenAudio()
    {
        audioPanel.SetActive(true);
    }

    public void CloseAudio()
    {
        audioPanel.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsPanel.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
    }
}
