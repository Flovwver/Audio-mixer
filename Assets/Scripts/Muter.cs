using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Muter : MonoBehaviour
{
    [SerializeField] private AudioListener _audioListener;

    private Button _volumeToogler;

    private void Awake()
    {
        _volumeToogler = GetComponent<Button>();
    }

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
        _audioListener.enabled = _audioListener.enabled == false;
    }
}
