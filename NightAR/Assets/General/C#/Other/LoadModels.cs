using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadModels : MonoBehaviour
{
    [SerializeField] Text PersentageText, PartText;
    [SerializeField] Slider ProgressSlider;

    [SerializeField] string[] assetBundleLink;
    [SerializeField]private AssetBundle[] assetBundle;
    [HideInInspector] private int downloadIndex, index, reDownload;
    bool isDownloaded = false;
    [SerializeField]private String assetBundleIndex;

    void Awake()
    {
        PersentageText.text = " ";
        if(!PlayerPrefs.HasKey(assetBundleIndex))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt(assetBundleIndex, 0);
        }
        reDownload = PlayerPrefs.GetInt(assetBundleIndex);
        if(reDownload == 0) Caching.ClearCache();
        for(int i = 0; i <= 5; i++) assetBundleLink[i] = "https://drive.google.com/uc?export=download&id=" + assetBundleLink[i];
        Caching.compressionEnabled = false;
        PartText.text = string.Format("Скачано {0}/6 частей", index);
        StartCoroutine(Download());  
    }
    private IEnumerator Download()
    {
        while(!isDownloaded)
        {
            while (!Caching.ready) yield return null;
            yield return GetBundle();
            if (!assetBundle[index - 1])
            {
                Debug.Log("Bundle Failed to Load");
                yield break;
            }
            if(index >= 6) isDownloaded = true;
            PartText.text = string.Format("Скачано {0}/6 частей", index);
        }
        yield return null;
        PlayerPrefs.SetInt(assetBundleIndex, 1);
        SceneManager.LoadScene("Main");
    }

    private IEnumerator GetBundle()
    {
        WWW request = WWW.LoadFromCacheOrDownload(assetBundleLink[index], downloadIndex + index);
        while (!request.isDone)
        {
            ProgressSlider.value = request.progress;
            float persentate = Mathf.Round(request.progress * 100);
            PersentageText.text = persentate.ToString() + "%";
            yield return null;
        }
        if(request.error == null) assetBundle[index] = request.assetBundle;
        else Debug.Log("Error"+request.error);
        index++;
        yield return null;
    }
}
