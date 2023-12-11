using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadePanel : MonoBehaviour
{
    public Image image;
    public AnimationCurve fadeCurve;
    public float fadeDuration = 1f;
    

    private void Start()
    {
        // Start the custom fade animation
        StartCoroutine(FadeCanvasGroup(1.0f, 0.0f, fadeDuration));
    }

    // Coroutine to perform the custom fading animation
    private IEnumerator FadeCanvasGroup(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        // Stage 1: Fade from startAlpha to middleAlpha
        while (elapsedTime < duration)
        {
            float t = fadeCurve.Evaluate(elapsedTime / duration);
            Color color = image.color;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        

        // Ensure the final alpha value is set
        Color endColor = image.color;
        endColor.a = endAlpha;
        image.color = endColor;
        image.gameObject.SetActive(false);
    }
}
