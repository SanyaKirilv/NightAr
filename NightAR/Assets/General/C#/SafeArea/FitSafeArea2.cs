using UnityEngine;

public class FitSafeArea2 : MonoBehaviour
{
    public GameObject screenTop;
    public GameObject screenButtom;
    private void Update()
    {
        Change();
    }

    public void Change()
    {
        SafeAreaTop();
        SafeAreaButtom();
    }

    private void SafeAreaButtom()
    {
        var safeArea = Screen.safeArea;
        var myRectTransform = screenButtom.GetComponent<RectTransform>();

        var anchorMin = new Vector2 (0, 0);
        var anchorMax = safeArea.position;

        anchorMax.x = 1;
        anchorMax.y /= Screen.height;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }

    private void SafeAreaTop()
    {
        var safeArea = Screen.safeArea;
        var myRectTransform = screenTop.GetComponent<RectTransform>();

        var anchorMin = safeArea.position + safeArea.size;
        var anchorMax = new Vector2 (1, 1);

        anchorMin.x = 0;
        anchorMin.y /= Screen.height;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }
}
