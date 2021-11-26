using UnityEngine;

public class TransitionController : MonoBehaviour
{
    public void EndTransition()
    {
        gameObject.SetActive(false);
    }
}
