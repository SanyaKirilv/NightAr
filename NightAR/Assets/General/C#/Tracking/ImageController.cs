using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

[System.Serializable]
public class ImageTarget
{
    public VideoClip videoClip;
    public AudioClip audioClip;
    public GameObject videoBox;
    public Sprite audioSourcePicture;
    public GameObject text;
}
public class ImageController : MonoBehaviour
{
    public ImageTarget[] imageTarget;
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
    [Header("Video/Audio Settings")]
    public VideoPlayer videoPlayer;
    public AudioSource audioPlayer;
    public Image audioPicture;
    public Animation[] videoSlider;    

    [HideInInspector] private int currentTarget = -1;
    [HideInInspector] public bool isFullscreenVideo, isVideoSlider, isFullscreenAudio, isFullscreenText, isFounded;
    
    private void Start()
    {
        audioPlayer.GetComponent<AudioSource>();
        foreach (var item in _sliderController) item.GetComponent<SliderController>().Pause();
        _sliderControllerAudio.GetComponent<SliderController>().Pause();
        currentTarget = -1;
        foreach (var item in messageBox) item.Play("See_Message");
        for(var i = 0; i < 24; i++) imageTarget[i].videoBox.SetActive(false);
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
            case "ImageTarget_5":
                currentTarget = 4;
                break;
            case "ImageTarget_6":
                currentTarget = 5;
                break;
            case "ImageTarget_7":
                currentTarget = 6;
                break;
            case "ImageTarget_8":
                currentTarget = 7;
                break;
            case "ImageTarget_9":
                currentTarget = 8;
                break;
            case "ImageTarget_10":
                currentTarget = 9;
                break;
            case "ImageTarget_11":
                currentTarget = 10;
                break;
            case "ImageTarget_12":
                currentTarget = 11;
                break;
            case "ImageTarget_13":
                currentTarget = 12;
                break;
            case "ImageTarget_14":
                currentTarget = 13;
                break;
            case "ImageTarget_15":
                currentTarget = 14;
                break;
            case "ImageTarget_16":
                currentTarget = 15;
                break;
            case "ImageTarget_17":
                currentTarget = 16;
                break;
            case "ImageTarget_18":
                currentTarget = 17;
                break;
            case "ImageTarget_19":
                currentTarget = 18;
                break;
            case "ImageTarget_20":
                currentTarget = 19;
                break;
            case "ImageTarget_21":
                currentTarget = 20;
                break;
            case "ImageTarget_22":
                currentTarget = 21;
                break;
            case "ImageTarget_23":
                currentTarget = 22;
                break;
            case "ImageTarget_24":
                currentTarget = 23;
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
        for(var i = 0; i < 24; i++) imageTarget[i].videoBox.SetActive(false);
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
        videoPlayer.clip = imageTarget[currentTarget].videoClip;
        imageTarget[currentTarget].videoBox.SetActive(true);
        foreach (var item in videoSlider) item.Play("See_SliderPortrait");
    }

    public void Audio()
    {
        audioPlayer.clip = imageTarget[currentTarget].audioClip;
        audioPicture.sprite = imageTarget[currentTarget].audioSourcePicture;
        PauseVideo();
        FullscreenAudio();
    }
    public void Text()
    {
        imageTarget[currentTarget].text.SetActive(true);
        _orientationSetter.ScreenOrientation = 1;
        PauseVideo();
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
