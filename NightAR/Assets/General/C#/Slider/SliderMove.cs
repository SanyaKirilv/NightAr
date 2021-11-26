using UnityEngine;

public class SliderMove : MonoBehaviour
{
    private float time = 5;
    public Animation slider, player;
    private int state = 2;
    private bool seeAnimation, hideAnimation;

    private void Start()
    {
        seeAnimation = true;
        hideAnimation = false;
        slider.GetComponent<Animation>();
        player.GetComponent<Animation>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    state = 1;
                    break;

                case TouchPhase.Ended:
                    state = 2;
                    break;
            }
        }

        switch (state)
            {
                case 1:
                time = 10;
                    if(!seeAnimation)
                    {
                        slider.Play("See_SliderLandScape");
                        player.Play("See_LandScapeImage");
                    }
                    break;
               
                case 2:
                    time -= Time.deltaTime;
                    if(time <= 0)
                    {
                        time = 0;
                        if(!hideAnimation)
                        {
                            slider.Play("Hide_SliderLandScape");
                            player.Play("Hide_LandScapeImage");
                        }
                    }
                    break;
            }
    }

    public void IsOn()
    {
        seeAnimation = true;
        hideAnimation = false;
    }

    public void IsOff()
    {
        seeAnimation = false;
        hideAnimation = true;
    }
}
