using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;

    [SerializeField] private AudioSource _laserBlastSound;
    [SerializeField] private AudioSource _continiousBeamSound;
    [SerializeField] private AudioSource _laserReloadingSound;

    private UnityAction _playLaserBlast;
    private UnityAction _playContinousBeam;
    private UnityAction _playLaserReloading;

    private void OnEnable()
    {
        if (_button1 != null)
        {
            _playLaserBlast = () => Play(_laserBlastSound);
            _button1.onClick.AddListener(_playLaserBlast);
        }

        if (_button2 != null)
        {
            _playContinousBeam = () => Play(_continiousBeamSound);
            _button2.onClick.AddListener(_playContinousBeam);
        }

        if (_button3 != null)
        {
            _playLaserReloading = () => Play(_laserReloadingSound);
            _button3.onClick.AddListener(_playLaserReloading);
        }
    }

    private void OnDisable()
    {
        if (_button1 != null)
            _button1.onClick.RemoveListener(_playLaserBlast);

        if (_button2 != null)
            _button2.onClick.RemoveListener(_playContinousBeam);

        if (_button3 != null)
            _button3.onClick.RemoveListener(_playLaserReloading);
    }

    private void Play(AudioSource source)
    {
        if (source == null)
            return;

        source.Play();
    }
}
