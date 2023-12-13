using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FungusCanvas : MonoBehaviour
{
    public Canvas canvasObjectDialogue;
    public Canvas canvasObjectStage;
    public Canvas canvasObjectMenu;
    public Canvas canvasObjectBlur;
    public BoolChecker boolChecker;

    public CameraSwitcher cameraSwitcher;

    private void Start()
    {
        cameraSwitcher = FindObjectOfType<CameraSwitcher>();
    }

    private void Update()
    {
        if (cameraSwitcher.newCameraIndex == 0)
        {
            boolChecker.swapper.LoadUnloadScene(boolChecker.currentScene);
        }

        if (cameraSwitcher.newCameraIndex == 5)
        {
            StartCoroutine(ScreenToWorld());
            //canvasObject.renderMode = RenderMode.WorldSpace;
        }
        else if (cameraSwitcher.newCameraIndex == 1)
        {
            StartCoroutine(WorldToScreen());
            //canvasObject.renderMode = RenderMode.ScreenSpaceOverlay;
        }
    }

    IEnumerator ScreenToWorld()
    {
        yield return new WaitForSeconds(1f);

        canvasObjectDialogue.renderMode = RenderMode.WorldSpace;
        canvasObjectStage.renderMode = RenderMode.WorldSpace;
        canvasObjectMenu.renderMode = RenderMode.WorldSpace;
        canvasObjectBlur.renderMode = RenderMode.WorldSpace;
    }

    IEnumerator WorldToScreen()
    {
        yield return new WaitForSeconds(1f);

        canvasObjectDialogue.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObjectStage.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObjectMenu.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObjectBlur.renderMode = RenderMode.ScreenSpaceOverlay;
    }


}
