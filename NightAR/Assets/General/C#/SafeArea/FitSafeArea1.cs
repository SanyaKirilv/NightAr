using UnityEngine;

public class FitSafeArea1 : MonoBehaviour
{    
    public GameObject screen;
    private void Update()
    {
       Change();
    }

    public void Change()
    {
        SafeArea();
    }

    private void SafeArea()
    {
        var safeArea = Screen.safeArea;
        var myRectTransform = screen.GetComponent<RectTransform>();

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }
}
