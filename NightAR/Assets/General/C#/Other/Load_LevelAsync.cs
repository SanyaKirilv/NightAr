using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Load_LevelAsync : MonoBehaviour
{
    public Slider slider;
    public Text loading_text;

    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }
    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("AR");
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            float progress = Mathf.Round(operation.progress * 100);
            loading_text.text = progress.ToString() + "%";
            yield return null;
        }
    }
}
