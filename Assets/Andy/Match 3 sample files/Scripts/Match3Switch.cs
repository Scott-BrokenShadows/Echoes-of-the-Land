using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Match3Switch : MonoBehaviour
{
    public Canvas canvasObject;
    public CameraSwitcher cameraSwitcher;

    private void Start()
    {
        cameraSwitcher = FindObjectOfType < CameraSwitcher >();
    }

    private void Update()
    {
        
            if (cameraSwitcher.newCameraIndex == 5)
            {
            StartCoroutine(ScreenToWorld());
            //canvasObject.renderMode = RenderMode.WorldSpace;
        }
            else if (cameraSwitcher.newCameraIndex == 4)
            {
            StartCoroutine(WorldToScreen());
            //canvasObject.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }

    IEnumerator ScreenToWorld()
    {
        yield return new WaitForSeconds(1f);

        canvasObject.renderMode = RenderMode.WorldSpace;
    }

    IEnumerator WorldToScreen()
    {
        yield return new WaitForSeconds(1f);

        canvasObject.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}
