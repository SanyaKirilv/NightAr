using UnityEngine;

public class FitSafeArea4 : MonoBehaviour
{
    public GameObject screenTop, screenButtom;
    private void Update()
    {
        Change();
    }

    public void Change()
    {
        SafeAreaTop();
        SafeAreaButtom();
    }

    private void SafeAreaTop()
    {
        var safeArea = Screen.safeArea;
        var myRectTransform = screenTop.GetComponent<RectTransform>();

        var anchorMin = new Vector2 (0, 0);
        var anchorMax = safeArea.position + safeArea.size;

        anchorMin.x = 0;
        anchorMin.y = 0;
        anchorMax.x = safeArea.position.x / Screen.width;
        anchorMax.y = 1;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }

        private void SafeAreaButtom()
    {
        var safeArea = Screen.safeArea;
        var myRectTransform = screenButtom.GetComponent<RectTransform>();

        var anchorMin = safeArea.position + safeArea.size;
        var anchorMax = new Vector2 (1, 1);

        anchorMin.x = (safeArea.position.x + safeArea.size.x) / Screen.width;
        anchorMin.y = 0;
        anchorMax.x = 1;
        anchorMax.y = 1;

        myRectTransform.anchorMin = anchorMin;
        myRectTransform.anchorMax = anchorMax;
    }
}
