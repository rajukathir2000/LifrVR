using UnityEngine;
using UnityEngine.Video;

public class ButtonController : MonoBehaviour
{
    public GameObject gallery;
    public GameObject[] videoTiles;
    public GameObject backButton;
    public GameObject videoPlayerGameObject;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips;
    public GameObject[] addButtons;
    private bool videoPlaying = false;

    void Start()
    {
        HideVideoButtons();
        videoPlayerGameObject.SetActive(false);
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    public void VideoButtons()
    {
        if (gallery.activeSelf)
        {
            foreach (GameObject button in videoTiles)
            {
                button.SetActive(true);
            }
            backButton.SetActive(true);
            gallery.SetActive(false);
        }
        else
        {
            HideVideoButtons();
            gallery.SetActive(true);
        }
    }

    public void PlayVideo(int index)
    {
        videoPlayer.clip = videoClips[index];
        videoPlayer.Play();
        videoPlayerGameObject.SetActive(true);
        foreach (GameObject addButton in addButtons)
        {
            addButton.SetActive(true);
        }
        foreach (GameObject button in videoTiles)
        {
            button.SetActive(false);
        }
        videoPlaying = true;
    }

    public void GoBack()
    {
        if (videoPlaying)
        {
            foreach (GameObject button in videoTiles)
            {
                button.SetActive(true);
            }
            foreach (GameObject addButton in addButtons)
            {
                addButton.SetActive(false);
            }
            backButton.SetActive(true);
            gallery.SetActive(false);
            videoPlayer.Stop();
            videoPlayerGameObject.SetActive(false);
            videoPlaying = false;
        }
        else
        {
            HideVideoButtons();
            gallery.SetActive(true);
        }
    }

    private void HideVideoButtons()
    {
        foreach (GameObject button in videoTiles)
        {
            button.SetActive(false);
        }
        foreach (GameObject addButton in addButtons)
        {
            addButton.SetActive(false);
        }
        backButton.SetActive(false);
    }
    public void PausePlay()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

    public void SeekF(float sec)
    {
        if (videoPlaying)
        {
            videoPlayer.time += sec;
        }
    }

    public void SeekB(float sec)
    {
        if (videoPlaying)
        {
            videoPlayer.time -= sec;
        }
    }
    private void OnVideoEnd(VideoPlayer vplayer)
    {
        videoPlayerGameObject.SetActive(false);
        videoPlaying = false;
        GoBack();
    }
}
