using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (_sound != null)
            _button.onClick.AddListener(_sound.Play);
    }

    private void OnDisable()
    {
        if (_sound != null)
            _button.onClick.RemoveListener(_sound.Play);
    }
}
