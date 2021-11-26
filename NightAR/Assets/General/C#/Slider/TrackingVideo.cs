using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;


public class TrackingVideo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public VideoPlayer videoPlayer;
    public Slider videoSlider;
    [HideInInspector] private bool slide = false;
    private void Start()
    {
        videoSlider = GetComponent<Slider>();
    }
    public void OnPointerDown(PointerEventData a)
    {
        slide = true;
    }
    public void OnPointerUp(PointerEventData a)
    {
        float frame = (float)videoSlider.value * (float)videoPlayer.frameCount;
        videoPlayer.frame = (long)frame;
        slide = false;
    }
    private void Update()
    {
        if(!slide && videoPlayer.isPlaying) videoSlider.value = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
    }
}
