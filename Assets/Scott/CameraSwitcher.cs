using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; // An array of cameras to switch between.
    public Canvas[] canvases; //An array of canvases to change the order in layer.
    public Canvas loadingScreenCanvas; // Reference to the loading screen UI canvas.
    public RawImage fadeImage; // Reference to an image used for fading in/out.
    public float transitionDuration = 1.0f; // Duration of the camera transition.
    public float fadeDuration = 0.5f; // Duration of the fade-in/fade-out effect.

    private int currentCameraIndex = 0; // Index of the currently active camera.
    private int currentCanvasIndex = 0; //Index of the currently active canvas.
    private int lastCameraIndex = 0; //Index for changing when exiting menu

    public Audiomanager audiomanager;
    public int lastMusicIndex;
    public int menuMusicIndex;

    private void Start()
    {
        // Ensure only the first camera is initially enabled.
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        for (int i = 1; i < canvases.Length; i++)
        {
            canvases[i].sortingOrder = 0;
        }

        // Initialize the fade image to fully transparent.
        Color transparent = fadeImage.color;
        transparent.a = 0.0f;
        fadeImage.color = transparent;
        loadingScreenCanvas.gameObject.SetActive(false);
    }

    public void SwitchToCamera(int cameraIndex)
    {
        if (cameraIndex >= 0 && cameraIndex < cameras.Length && cameraIndex != currentCameraIndex)
        {
            StartCoroutine(TransitionWithLoading(cameraIndex));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentCameraIndex != 0)
            {
                SwitchToPrevious();
            }
        }
    }

    public void SwitchToPrevious()
    {
        if (currentCameraIndex != 5)
        {
            lastCameraIndex = currentCameraIndex;
            lastMusicIndex = audiomanager.currentMusicIndex;
            audiomanager.CrossfadeMusic(menuMusicIndex);
            canvases[currentCanvasIndex].sortingOrder = 0;
            canvases[5].sortingOrder = 10;
            currentCanvasIndex = 5;
            StartCoroutine(TransitionWithLoading(5));
        }
        if (currentCameraIndex == 5)
        {
            canvases[currentCanvasIndex].sortingOrder = 0;
            canvases[lastCameraIndex].sortingOrder = 10;
            audiomanager.CrossfadeMusic(lastMusicIndex);
            StartCoroutine(TransitionWithLoading(lastCameraIndex));
        }
    }

    public void SwitchCanvasOrder(int canvasIndex)
    {
        if (canvasIndex >= 0 && canvasIndex < cameras.Length && canvasIndex != currentCanvasIndex)
        {
            canvases[currentCanvasIndex].sortingOrder = 0;
            canvases[canvasIndex].sortingOrder = 10;
            currentCanvasIndex = canvasIndex;
        }
    }

    private IEnumerator TransitionWithLoading(int cameraIndex)
    {
        // Show the loading screen.
        loadingScreenCanvas.gameObject.SetActive(true);

        // Start fading in.
        StartCoroutine(FadeIn());

        // Wait for the fade-in effect to complete.
        yield return new WaitForSeconds(fadeDuration);

        // Enable the target camera.
        cameras[cameraIndex].gameObject.SetActive(true);

        // Disable the current camera.
        cameras[currentCameraIndex].gameObject.SetActive(false);

        // Wait for a short duration to display the loading screen.
        yield return new WaitForSeconds(transitionDuration);

        

        // Start fading out.
        StartCoroutine(FadeOut());

        // Wait for the fade-out effect to complete.
        yield return new WaitForSeconds(fadeDuration);

        // Hide the loading screen.
        loadingScreenCanvas.gameObject.SetActive(false);

        currentCameraIndex = cameraIndex;
    }

    private IEnumerator FadeIn()
    {
        Color color = fadeImage.color;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / fadeDuration;
            color.a = Mathf.Lerp(0, 1, t);
            fadeImage.color = color;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        Color color = fadeImage.color;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / fadeDuration;
            color.a = Mathf.Lerp(1, 0, t);
            fadeImage.color = color;
            yield return null;
        }
    }
}

