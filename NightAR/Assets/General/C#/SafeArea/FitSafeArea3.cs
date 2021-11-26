using UnityEngine;

public class FitSafeArea3 : MonoBehaviour
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

        var anchorMin = new Vector2 (0, 0);
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x = safeArea.position.x / Screen.width;
        anchorMin.y = 0;
        anchorMax.x = (safeArea.position.x + safeArea.size.x) / Screen.width;
        anchorMax.y = 1;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }
}
