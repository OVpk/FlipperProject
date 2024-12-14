using UnityEngine;

public class FpsLimiter : MonoBehaviour
{
    public int targetFps;
    
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFps;
    }
}
