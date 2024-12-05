using UnityEngine;
using Vuforia;

public class CameraFocusController : MonoBehaviour
{
    void Start()
    {
        SetCameraFocusMode();
    }

    void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            SetCameraFocusMode();
        }
    }

    void SetCameraFocusMode()
    {
        var vuforia = VuforiaBehaviour.Instance;
        if (vuforia != null)
        {
            bool focusSet = vuforia.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
            if (focusSet)
            {
                Debug.Log("Fokus otomatis diaktifkan.");
            }
            else
            {
                Debug.LogWarning("Fokus otomatis tidak didukung pada perangkat ini.");
            }
        }
        else
        {
            Debug.LogWarning("VuforiaBehaviour tidak ditemukan.");
        }
    }
}
