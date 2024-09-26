using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleChanger : MonoBehaviour
{
    [SerializeField] private string _mixerName;
    [SerializeField] private AudioMixerGroup _mixer;

    private float _minVolume = -80f;
    private float _maxVolume = 0f;

    public void DisableVolume(bool muted)
    {
        if (muted)
            _mixer.audioMixer.SetFloat(_mixerName, _minVolume);
        else
            _mixer.audioMixer.SetFloat(_mixerName, _maxVolume);
    }
}
