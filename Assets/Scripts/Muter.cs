using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Muter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Button _volumeToogler;
    [SerializeField] private Slider _masterVolume;
    [SerializeField] private float _lastVolumeValue = 1f;
    [SerializeField] private float _mutedVolumeValue = 0f;

    private void OnEnable()
    {
        if (_volumeToogler != null)
            _volumeToogler.onClick.AddListener(ToogleIsMuted);
    }

    private void OnDisable()
    {
        if (_volumeToogler != null)
            _volumeToogler.onClick.RemoveListener(ToogleIsMuted);
    }

    private void ToogleIsMuted()
    {
        if (_masterVolume == null)
            return;

        bool isMuted;

        isMuted = _masterVolume.value == 0;

        isMuted = !isMuted;

        float needVolume = isMuted ? _mutedVolumeValue : _lastVolumeValue;

        if (isMuted)
            _lastVolumeValue = _masterVolume.value;
            
        _masterVolume.value = needVolume;
    }
}
