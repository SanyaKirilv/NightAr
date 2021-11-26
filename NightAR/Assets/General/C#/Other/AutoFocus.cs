using Vuforia;

public class AutoFocus : VuforiaMonoBehaviour
{
    void Start()
    {
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
        VuforiaApplication.Instance.OnVuforiaPaused += OnPaused;
    }
    private void OnVuforiaStarted()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        VuforiaBehaviour.Instance.CameraDevice.SetCameraMode(Vuforia.CameraMode.MODE_DEFAULT);
    }
    private void OnPaused(bool paused)
    {
        if (!paused) VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
