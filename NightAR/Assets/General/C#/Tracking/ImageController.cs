using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class ImageController : MonoBehaviour
{
    [Header("Scripts Settings")]
    public OrientationSetter _orientationSetter;
    public GameObject _sliderControllerAudio;
    public GameObject[] _sliderController;
    [Space(25)]
    [Header("Screen Settings")]
    public GameObject videoScreen;
    public GameObject audioScreen;
    public GameObject textScreen;
    public Button[] controlButton;
    public Animation[] messageBox;
    [Space(25)]
    [Header("Video Settings")]
    public VideoPlayer videoPlayer;
    public Animation[] videoSlider;
    public VideoClip[] videoClip;
    public GameObject[] videoBox;
    [Space(25)]
    [Header("Audio Settings")]
    public AudioSource audioPlayer;
    public Image audioPicture;
    public Sprite[] audioSourcePicture;
    public AudioClip[] audioClip;
    [Space(25)]
    [Header("Text Settings")]
    public GameObject[] text;
    [HideInInspector] private int currentTarget = -1;
    [HideInInspector] public bool isFullscreenVideo, isVideoSlider, isFullscreenAudio, isFullscreenText, isFounded;
    
    private void Start()
    {
        audioPlayer.GetComponent<AudioSource>();
        foreach (var item in _sliderController) item.GetComponent<SliderController>().Pause();
        _sliderControllerAudio.GetComponent<SliderController>().Pause();
        currentTarget = -1;
        foreach (var item in messageBox) item.Play("See_Message");
        foreach (var item in videoBox) item.SetActive(false);
    }
    public void OnFound(string targetName)
    {
        switch(targetName)
        {
            case "ImageTarget_1":
                currentTarget = 0;
                break;
            case "ImageTarget_2":
                currentTarget = 1;
                break;
            case "ImageTarget_3":
                currentTarget = 2;
                break;
            case "ImageTarget_4":
                currentTarget = 3;
                break;
        }
        foreach (var item in messageBox) item.Play("Hide_Message");
        isFounded = true;
        SwitchButton();
    }
    public void OnLost()
    {
        currentTarget = -1;
        isFounded = false;
        foreach (var item in messageBox) item.Play("See_Message");
        foreach (var item in videoBox) item.SetActive(false);
        if(isVideoSlider)
        {
            foreach (var item in videoSlider) item.Play("Hide_SliderPortrait");
            isVideoSlider = false;
        }
        if(!isFullscreenVideo) PauseVideo();
        SwitchButton();
    }

    public void PlayVideo()
    {
        foreach (var item in _sliderController) item.GetComponent<SliderController>().Play();
        videoPlayer.Play();
    }
    public void PlayAudio()
    {
        _sliderControllerAudio.GetComponent<SliderController>().Play();
        audioPlayer.Play();
    }
    public void PauseVideo()
    {
        foreach (var item in _sliderController) item.GetComponent<SliderController>().Pause();
        videoPlayer.Pause();
    }
    public void PauseAudio()
    {
        _sliderControllerAudio.GetComponent<SliderController>().Pause();
        audioPlayer.Pause();
    }

    public void Video()
    {
        isVideoSlider = true;
        videoPlayer.clip = videoClip[currentTarget];
        videoBox[currentTarget].SetActive(true);
        foreach (var item in videoSlider) item.Play("See_SliderPortrait");
    }

    public void Audio()
    {
        audioPlayer.clip = audioClip[currentTarget];
        audioPicture.sprite = audioSourcePicture[currentTarget];
        FullscreenAudio();
    }
    public void Text()
    {
        text[currentTarget].SetActive(true);
        FullscreenText();
    }

    public void FullscreenVideo()
    {
        isFullscreenVideo = !isFullscreenVideo;
        videoScreen.SetActive(isFullscreenVideo);
        if(isFullscreenVideo) _orientationSetter.ScreenOrientation = 2;
        else
        {
            _orientationSetter.ScreenOrientation = 0;
            PauseVideo();
        }
    }
    public void FullscreenAudio()
    {
        isFullscreenAudio = !isFullscreenAudio;
        audioScreen.SetActive(isFullscreenAudio);
        if(isFullscreenAudio) _orientationSetter.ScreenOrientation = 2;
        else
        {
            _orientationSetter.ScreenOrientation = 0;
            PauseAudio();
        }
    }
    public void FullscreenText()
    {
        isFullscreenAudio = !isFullscreenAudio;
        textScreen.SetActive(isFullscreenAudio);
        if(isFullscreenText) _orientationSetter.ScreenOrientation = 1;
        else _orientationSetter.ScreenOrientation = 0;
    }

    public void SwitchButton()
    {
        if(!isFounded) foreach (var item in controlButton) item.interactable = false;
        else foreach (var item in controlButton) item.interactable = true;
    }
}
