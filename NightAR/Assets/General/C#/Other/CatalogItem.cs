using UnityEngine;
using UnityEngine.UI;

public class CatalogItem : MonoBehaviour
{
    public Image image;
    public Sprite sprite;
    public Text[] textArea;
    [SerializeField] private string _index,  _name, link;
    
    private void Start()
    {
        image.sprite = sprite;
        textArea[0].text = "Арт.: " + _index;
        textArea[1].text = _name;
        textArea[2].text = "на сайт>>>";
    }

    public void OnClick()
    {
        Debug.Log("Linked");
        Application.OpenURL(link);
    }
}
