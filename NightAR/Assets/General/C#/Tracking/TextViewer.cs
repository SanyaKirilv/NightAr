using UnityEngine;
using UnityEngine.UI;

public class TextViewer : MonoBehaviour
{
    public GameObject pageIndexText;
    public GameObject[] pageText;
    private int pageIndex, index;

    private void Start()
    {
        pageIndex = 0;
        PageUpdate();
    }
    public void Page(int n)
    {
        index = pageIndex + n;
        if (index >= 0 && index < pageText.Length) PageUpdate();
    }

    private void PageUpdate()
    {
        pageIndex = index;
        foreach (var page in pageText) page.SetActive(false);
        pageText[pageIndex].SetActive(true);
        pageIndexText.GetComponent<Text>().text = (pageIndex + 1).ToString() + "/" + pageText.Length.ToString();
    }
}
