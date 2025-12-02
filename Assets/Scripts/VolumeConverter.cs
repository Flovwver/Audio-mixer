using UnityEngine;

public class VolumeConverter
{
    private const float MinVolume = 0.0001f;
    private const float MaxVolume = 1f;
    private const float LogBase = 10f;
    private const float LogMultiplier = 20f;

    public static float LogarifmizeVolume(float volume)
    {
        volume = Mathf.Clamp(volume, MinVolume, MaxVolume);
        return Mathf.Log(volume, LogBase) * LogMultiplier;
    }

    public static float UnlogarifmizeVolume(float volume)
    {
        return Mathf.Pow(LogBase, volume / LogMultiplier);
    }
}
