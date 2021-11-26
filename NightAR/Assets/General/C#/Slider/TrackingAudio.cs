using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class TrackingAudio : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource audioPlayer;
    public Slider audioSlider;
    [HideInInspector] private bool slide = false;
    private void Start()
    {
        audioPlayer.GetComponent<AudioSource>();
        audioSlider = GetComponent<Slider>();
    }
    public void OnPointerDown(PointerEventData a)
    {
        slide = true;
    }
    public void OnPointerUp(PointerEventData a)
    {
        float time = (float)audioSlider.value * (float)audioPlayer.clip.length;
        audioPlayer.time = (long)time;
        slide = false;
    }
    private void Update()
    {
        if(!slide &&  audioPlayer.isPlaying) audioSlider.value = (float)audioPlayer.time / (float)audioPlayer.clip.length;
    }
}
