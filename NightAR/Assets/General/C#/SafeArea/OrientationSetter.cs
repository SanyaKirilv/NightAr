using UnityEngine;

public class OrientationSetter : MonoBehaviour
{
    public GameObject[] screen;
    public int ScreenOrientation;
    public bool isAR;

    private void Update()
    {
        switch (ScreenOrientation)
        {
            case 0:
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
                
                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = true;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;
            
            case 1:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                break;

            case 2:
                Screen.orientation = UnityEngine.ScreenOrientation.Landscape;
                Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
                
                Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
                Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
                break;
        }
        if(isAR)
        {
            if(Screen.orientation.ToString() == "Portrait" || Screen.orientation.ToString() == "PortraitUpsideDown")
            {
                screen[0].SetActive(true);
                screen[1].SetActive(true);
                screen[2].SetActive(false);
                screen[3].SetActive(false);
            }
            if(Screen.orientation.ToString() == "LandscapeLeft" || Screen.orientation.ToString() == "LandscapeRight")
            {
                screen[0].SetActive(false);
                screen[1].SetActive(false);
                screen[2].SetActive(true);
                screen[3].SetActive(true);
            }
        }
    }
}
