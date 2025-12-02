using UnityEngine;

public class VolumeConverter
{
    private static readonly float s_minVolume = 0.0001f;
    private static readonly float s_maxVolume = 1f;
    private static readonly float s_logBase = 10f;
    private static readonly float s_logMultiplier = 20f;

    public static float LogarifmizeVolume(float volume)
    {
        volume = Mathf.Clamp(volume, s_minVolume, s_maxVolume);
        return Mathf.Log(volume, s_logBase) * s_logMultiplier;
    }

    public static float UnlogarifmizeVolume(float volume)
    {
        return Mathf.Pow(s_logBase, volume / s_logMultiplier);
    }
}
