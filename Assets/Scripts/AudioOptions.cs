using UnityEngine;
using UnityEngine.Audio;

public class AudioOptions : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private float _lastVolumeValue = 1f;

    public void SetMasterVolume(float volume)
    {
        _audioMixer.SetFloat(AudioMixerData.Parameters.Master, LogarifmizeVolume(volume));
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat(AudioMixerData.Parameters.Music, LogarifmizeVolume(volume));
    }

    public void SetButtonsVolume(float volume)
    {
        _audioMixer.SetFloat(AudioMixerData.Parameters.Buttons, LogarifmizeVolume(volume));
    }

    public void OffOnSound()
    {
        if (_audioMixer.GetFloat(AudioMixerData.Parameters.Master, out float value) && value <= LogarifmizeVolume(0f))
            _audioMixer.SetFloat(AudioMixerData.Parameters.Master, LogarifmizeVolume(_lastVolumeValue));
        else
        {
            _lastVolumeValue = UnlogarifmizeVolume(value);
            _audioMixer.SetFloat(AudioMixerData.Parameters.Master, LogarifmizeVolume(0f));
        }
    }

    private float LogarifmizeVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        return Mathf.Log10(volume) * 20;
    }

    private float UnlogarifmizeVolume(float volume)
    {
        return Mathf.Pow(10, volume / 20);
    }
}
