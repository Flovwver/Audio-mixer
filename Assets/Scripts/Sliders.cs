using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Events;

public class Sliders : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _buttonsVolume;
    [SerializeField] private Slider _backgroundVolume;

    private UnityAction<float> _setMasterVolume;
    private UnityAction<float> _setButtonsVolume;
    private UnityAction<float> _setMusicVolume;

    private void OnEnable()
    {
        if (_masterVolume != null)
        {
            _setMasterVolume = (value) => SetVolume(AudioMixerData.Parameters.Master, value);
            _masterVolume.onValueChanged.AddListener(_setMasterVolume);
        }

        if (_buttonsVolume != null)
        {
            _setButtonsVolume = (value) => SetVolume(AudioMixerData.Parameters.Buttons, value);
            _buttonsVolume.onValueChanged.AddListener(_setButtonsVolume);
        }

        if (_backgroundVolume != null)
        {
            _setMusicVolume = (value) => SetVolume(AudioMixerData.Parameters.Music, value);
            _backgroundVolume.onValueChanged.AddListener(_setMusicVolume);
        }
    }

    private void OnDisable()
    {
        if (_masterVolume != null)
            _masterVolume.onValueChanged.RemoveListener(_setMasterVolume);

        if (_buttonsVolume != null)
            _buttonsVolume.onValueChanged.RemoveListener(_setButtonsVolume);

        if (_backgroundVolume != null)
            _backgroundVolume.onValueChanged.RemoveListener(_setMusicVolume);
    }

    private void SetVolume(string parameterName, float volume)
    {
        if (_audioMixer != null)
            _audioMixer.SetFloat(parameterName, VolumeConverter.LogarifmizeVolume(volume));
    }
}
