using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSwitcher : MonoBehaviour
{
    public VideoClip videoClip4G;
    public VideoClip videoClip5G;
    private VideoPlayer videoPlayer;
    private bool videoClipIs4G;
    public static VideoSwitcher Instance;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>(); 

        videoClipIs4G = true;
        videoPlayer.clip = videoClip4G;
    }

    public void SwitchVideo()
    {
        if (videoClipIs4G){
            videoPlayer.clip = videoClip5G;
            videoClipIs4G = false;
            return;
        }

        videoPlayer.clip = videoClip4G;
        videoClipIs4G = true;
    }
}
