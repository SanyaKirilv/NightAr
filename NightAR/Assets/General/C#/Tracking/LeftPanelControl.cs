using UnityEngine;

public class LeftPanelControl : MonoBehaviour
{
    public Animation[] leftButtons;
    private void Start()
    {
        SwitchButtonsOff();
    }
    public void SwitchButtonsOn()
    {
        leftButtons[0].Play("See_LeftPanel_1");
        leftButtons[1].Play("See_LeftPanel_2");
    }
    public void SwitchButtonsOff()
    {
        leftButtons[0].Play("Hide_LeftPanel_1");
        leftButtons[1].Play("Hide_LeftPanel_2");
    }
}
