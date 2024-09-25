using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private string[] _allMixersNames;

    private float _minVolume = -80f;
    private float _maxVolume = 0f;
    private float _sliderDefaultValue = 1f;
    private int _toggleDefaultValue = 0;

    private string _togglePrefsName = "SoundsMuted";

    private Slider[] _sliders;

    public string MixerName { get; private set; }

    private void Awake()
    {
        GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt(_togglePrefsName, _toggleDefaultValue) == _toggleDefaultValue;
        _sliders = GetComponentsInChildren<Slider>();

        for (int i = 0; i < _sliders.Length; i++)
            _sliders[i].value = PlayerPrefs.GetFloat(_allMixersNames[i], _sliderDefaultValue);
    }

    public void ToggleMusic(bool muted)
    {
        if (muted)
            _mixer.audioMixer.SetFloat(MixerName, _minVolume);
        else
            _mixer.audioMixer.SetFloat(MixerName, _maxVolume);

        PlayerPrefs.SetInt(_togglePrefsName, muted ? 0 : 1);
    }

    public void ChangeVolume(float value)
    {
        _mixer.audioMixer.SetFloat(MixerName, Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat(MixerName, value);
    }

    public void SetMixerName(string name) =>
        MixerName = name;
}
