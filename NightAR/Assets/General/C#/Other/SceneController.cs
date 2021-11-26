using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string Main, ARLoader, Information, Catalog;
    public GameObject transition;
    private void Start()
    {
        transition.SetActive(true);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(Main);
    }
    public void GoToAR()
    {
        SceneManager.LoadScene(ARLoader);
    }
    public void GoToInformation()
    {
        SceneManager.LoadScene(Information);
    }
    public void GoToCatalog()
    {
        SceneManager.LoadScene(Catalog);
    }
}
