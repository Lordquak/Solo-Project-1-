using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayback : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Assign VideoPlayer in Inspector
    public string sceneToLoad = "MainGameScene";  // Name of your main scene

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;  // Event when video ends
        videoPlayer.Play();
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video finished! Loading main scene...");
        SceneManager.LoadScene(sceneToLoad);
    }
}
