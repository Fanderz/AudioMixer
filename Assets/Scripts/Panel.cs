using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolume = -80f;
    private float _maxVolume = 0f;
    private float _sliderDefaultValue = 1f;
    private int _toggleDefaultValue = 0;

    private string _masterVolumeName = "MasterVolume";
    private string _effectsVolumeName = "EffectsVolume";
    private string _musicVolumeName = "MusicVolume";
    private string _togglePrefsName = "SoundsMuted";

    private Slider[] _sliders;

    private void Awake()
    {
        GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt(_togglePrefsName, _toggleDefaultValue) == _toggleDefaultValue;
        _sliders = GetComponentsInChildren<Slider>();
        int maxIndex = _sliders.Length - 1;

        _sliders[maxIndex].value = PlayerPrefs.GetFloat(_musicVolumeName, _sliderDefaultValue);
        _sliders[--maxIndex].value = PlayerPrefs.GetFloat(_effectsVolumeName, _sliderDefaultValue);
        _sliders[--maxIndex].value = PlayerPrefs.GetFloat(_masterVolumeName, _sliderDefaultValue);
    }

    public void ToggleMusic(bool muted)
    {
        if (muted)
            _mixer.audioMixer.SetFloat(_masterVolumeName, -80);
        else
            _mixer.audioMixer.SetFloat(_masterVolumeName, 0);

        PlayerPrefs.SetInt(_togglePrefsName, muted ? 0 : 1);
    }

    public void ChangeAllVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_masterVolumeName, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(_masterVolumeName, value);
    }

    public void ChangeEffectsVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_effectsVolumeName, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(_effectsVolumeName, value);
    }

    public void ChangeMusicVolume(float value)
    {
        _mixer.audioMixer.SetFloat(_musicVolumeName, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(_musicVolumeName, value);
    }
}
