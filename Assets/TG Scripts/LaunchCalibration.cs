using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCalibration : MonoBehaviour
{


public void LaunchEyeTracking()
{
#if WINDOWS_UWP
    UnityEngine.WSA.Application.InvokeOnUIThread(async () =>
    {
        bool result = await global::Windows.System.Launcher.LaunchUriAsync(new System.Uri("ms-hololenssetup://EyeTracking"));
        if (!result)
        {
            Debug.LogError("Launching URI failed to launch.");
        }
    }, false);
#else
    Debug.LogError("Launching eye tracking not supported Windows UWP");
#endif
}

}
