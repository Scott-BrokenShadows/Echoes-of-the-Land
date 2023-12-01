using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayLoadingVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    public bool videoPlaying;
    public bool loadingScreenOn;
    public Canvas loadingScreen;

    private void Start()
    {
        StartCoroutine(PlayLoadingScreen());
    }

    IEnumerator PlayLoadingScreen()
    {
        if (videoPlayer == null || rawImage == null)
            yield break;

        
        videoPlayer.renderMode = VideoRenderMode.APIOnly;
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
            yield return new WaitForSeconds(1);

        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        videoPlaying = true;
    }
}
