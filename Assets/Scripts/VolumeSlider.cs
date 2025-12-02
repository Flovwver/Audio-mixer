using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioMixerParameters _mixerParameter;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        if (_audioMixer != null)
            _audioMixer.SetFloat(_mixerParameter.ToString(), VolumeConverter.LogarifmizeVolume(volume));
    }
}
