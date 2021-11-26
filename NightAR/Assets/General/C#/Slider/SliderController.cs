using UnityEngine;

public class SliderController : MonoBehaviour
{
    public GameObject buttonPlay, buttonPause;

    public void Play()
    {
        buttonPlay.SetActive(false);
        buttonPause.SetActive(true);
    }
    public void Pause()
    {
        buttonPlay.SetActive(true);
        buttonPause.SetActive(false);
    }
}
